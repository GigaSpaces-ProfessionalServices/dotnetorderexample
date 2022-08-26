using GigaSpaces.Core;
using GigaSpaces.Examples.ProcessingUnit.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GigaSpaces.Examples.ProcessingUnit.Processor
{
    class FillProcessorThread
    {

        public int threadRun(FillProcessor fillProcessor, ISpaceProxy spaceProxy, ClusterInfo clusterInfo)
        {
            Console.WriteLine("*** Started FillProcessorThread {0}", fillProcessor.WorkerID);

            Console.WriteLine("*** FillProcessorThread - Getting txManager ");
            ITransactionManager txManager = GigaSpacesFactory.CreateDistributedTransactionManager();
            Console.WriteLine("*** FillProcessorThread - Created txManager ");
            long partionId = (long)(clusterInfo.InstanceId - 1);
            GS_Fill fill = new GS_Fill();
            fill.OPID = partionId;

            long nextFillID = partionId * fillProcessor.fillCnt + 1;
            long lastFillID = nextFillID + fillProcessor.fillCnt - 1;


            // long nextFillID = 1 + ((fillProcessor.WorkerID - 1) * fillProcessor.fillCnt);
            // long lastFillID = nextFillID + fillProcessor.fillCnt - 1;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("*** Start FillProcessorThread {0}: nextFillID {1}, lastFillID {2}, {3} Ticks, {4} current time", partionId, nextFillID, lastFillID, DateTime.Now.Ticks, DateTime.Now.ToString("h:mm:ss tt"));
            Console.ResetColor();
            fillProcessor.fillCnt = 0;

            fillProcessor.processStartTime = DateTime.Now.Ticks;
            while (nextFillID <= lastFillID)
            {
                //   Console.WriteLine(fillProcessor.fillQueue.Count);
                //                if (!fillProcessor.fillQueue.Any())
                if (fillProcessor.fillQueue.Count <= 0)
                {
                    Thread.Sleep(500);
                    continue;
                }

                FillMsg newFillMsg;
                fillProcessor.fillQueue.TryDequeue(out newFillMsg);


                //  Console.WriteLine(newFillMsg);
                // Done with processing
                if (newFillMsg.OrderID == -1)
                {
                    break;
                }

                // fillTimer.StartTimer();
                long fillTImeElapsed = DateTime.Now.Ticks;
                ITransaction tx2 = txManager.Create();

                ICollection<String> projections = new List<String>();
                projections.Add(new String("OrderID".ToCharArray()));
                projections.Add(new String("Symbol".ToCharArray()));
                projections.Add(new String("CalExecValue".ToCharArray()));
                projections.Add(new String("CalCumQty".ToCharArray()));
                IdQuery<GS_Order> idQuery = new IdQuery<GS_Order>(newFillMsg.OrderID);
                idQuery.Projections = projections;

                GS_Order orderRead = spaceProxy.Read<GS_Order>(idQuery, tx2, 1000 * 60, ReadModifiers.ExclusiveReadLock);
                //GS_Order orderRead = spaceProxy.Read<GS_Order>(idQuery, tx2);

                fill.FillID = nextFillID++;
                fill.OrderID = newFillMsg.OrderID;
                fill.LastShares = newFillMsg.LastShares;
                fill.LastPrice = newFillMsg.LastPrice;

                //Console.WriteLine("Writting Order: {0} {1} ", order.OrderID, order.Symbol);
                spaceProxy.Write(fill, tx2, long.MaxValue, 1000);
                //Console.WriteLine("FillProcessorThread {0} - added fill", fillProcessor.WorkerID );

                GS_Order orderWrite = new GS_Order();


                orderWrite.OrderID = orderRead.OrderID;

                ChangeSet orderChange = new ChangeSet();
                orderChange.Increment("CalCumQty", newFillMsg.LastShares);
                orderChange.Increment("CalExecValue", (newFillMsg.LastPrice * newFillMsg.LastShares));
                IChangeResult<GS_Order> orderChangeResults =
                      spaceProxy.Change<GS_Order>(orderWrite, orderChange, tx2, 1000, ChangeModifiers.MemoryOnlySearch);
                tx2.Commit(1000 * 60);

                ///   fillTimer.StopTimer();
                //  fillProcessor.fillTime += fillTimer.Elapsed();
                fillTImeElapsed = DateTime.Now.Ticks - fillTImeElapsed;
                fillProcessor.fillTime += fillTImeElapsed;
                fillProcessor.fillCnt++;
            }

            fillProcessor.processEndTime = DateTime.Now.Ticks;

            long fillTimems = (fillProcessor.fillTime / TimeSpan.TicksPerMillisecond);
            double avgFill = 1.0 * fillTimems / fillProcessor.fillCnt;

            long fillMsgPerSec = (long)((fillTimems == 0) ? -1.0 : 1.0 * fillProcessor.fillCnt / fillTimems * 1000);

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("*** End FillProcessorThread {0} - Wrote Fills: {1} in {2} ms, average {3} ms, {4} fills in sec, {5} Ticks, {6} current time",
                                partionId, fillProcessor.fillCnt, fillTimems, avgFill, fillMsgPerSec, DateTime.Now.Ticks, DateTime.Now.ToString("h:mm:ss tt"));
            Console.ResetColor();


            Console.WriteLine("*** Exiting FillProcessorThread {0}", fillProcessor.WorkerID);
            return 0;
        }
    }
}
