using GigaSpaces.Examples.ProcessingUnit.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GigaSpaces.Examples.ProcessingUnit.Processor
{
    class FillFeederThread
    {
        private int processBuffer(List<OrderMsg> buffer, FillFeeder fillFeeder)
        {
            int fillQty = (int)buffer.First().Quanity;
            int fillMsgCnt = 0;
            long lastShares = 1;
            for (int i = 0; i < fillQty; i++)
            {
                foreach (var order in buffer)
                {
                    fillFeeder.fillQueue.Enqueue(new FillMsg(order.OrderID, lastShares, order.Price));
                    fillMsgCnt++;
                }
            }
            buffer.Clear();
            return fillMsgCnt;
        }


        public int threadRun(FillFeeder fillFeeder, int numFillProcessorWorkers)
        {
            //	FillFeeder fillFeeder = (FillFeeder*)ptr;
            Console.WriteLine("** Started FillFeederThread {0}", fillFeeder.WorkerID);
            long fillMsgCnt = 0;
            //int bufferSize = numFillProcessorWorkers * 2;
            int bufferSize = numFillProcessorWorkers * 3;
            List<OrderMsg> ordersBuffer = new List<OrderMsg>();

            while (true)
            {
                if (fillFeeder.orderQueue.Count <= 0)
                {
                    Thread.Sleep(500);
                    continue;
                }

                OrderMsg newOrderMsg;
                fillFeeder.orderQueue.TryDequeue(out newOrderMsg);

                if (newOrderMsg == null)
                {
                    continue;
                }
                // Done with processing
                if (newOrderMsg.OrderID == -1)
                {
                    if (ordersBuffer.Any())
                    {
                        fillMsgCnt += processBuffer(ordersBuffer, fillFeeder);
                    }
                    break;
                }

                ordersBuffer.Add(newOrderMsg);
                if (ordersBuffer.Count == bufferSize)
                {
                    fillMsgCnt += processBuffer(ordersBuffer, fillFeeder);
                }
            }

            Console.WriteLine("FillFeederThread {0} - Wrote {1} FillMsg",
                            fillFeeder.WorkerID, fillMsgCnt);

            return 0;
        }
    }
}
