using GigaSpaces.Core;
using GigaSpaces.Examples.OrderProcessorWithCSharp.Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace OrderProcessorWithCSharp
{
    class OrderProcessor
    {

        static void Main(string[] args)
        {
            ConcurrentQueue<OrderMsg> orderQueue = new ConcurrentQueue<OrderMsg>();
            ConcurrentQueue<FillMsg> fillQueue = new ConcurrentQueue<FillMsg>();
            List<FillFeeder> fillFeederWorkers = new List<FillFeeder>();
            List<Thread> fillFeederIDs = new List<Thread>();
            List<FillProcessor> fillProcessorWorkers = new List<FillProcessor>();
            List<Thread> fillProcessorIDs = new List<Thread>();
            List<OrderProcessorThread> orderProcessorWorkers = new List<OrderProcessorThread>();
            List<Thread> orderProcessorIDs = new List<Thread>();

            long partionId = 1;
            long ordCnt = 5;
            long totalFills = 0;
            long orderQty = 10;
            int numOrderWorkers = 1;
            int numFillFeederWorkers = 1;
            int numFillProcessorWorkers = 1;

            for (int i = 0; i < args.Length; i++)
            {
                String argVal = args[i];
                Console.WriteLine("Arg idx: {0}  value: {1}", i, Convert.ToInt64(argVal));

                switch (i)
                {
                    case 0:
                        partionId = Convert.ToInt64(argVal);
                        break;
                    case 1:
                        ordCnt = Convert.ToInt64(argVal);
                        break;
                    case 2:
                        orderQty = Convert.ToInt64(argVal);
                        break;
                    case 3:
                        numOrderWorkers = (int)Convert.ToInt64(argVal);
                        break;
                    case 4:
                        numFillProcessorWorkers = (int)Convert.ToInt64(argVal);
                        break;
                }
            }

            totalFills = ordCnt * orderQty;

            String spaceName = "EmbeddedSpace";

            Console.WriteLine("*** Creating embedded space named '" + spaceName + "'...");
            ISpaceProxy spaceProxy = new EmbeddedSpaceFactory(spaceName).Create();

            Console.WriteLine("*** Connected to space.");


            long orderProcesserTotalStartTime = DateTime.Now.Ticks;
            for (int i = 1; i <= numFillFeederWorkers; i++)
            {
                //FillFeeder *fillFeeder = new FillFeeder(i, fillQueueArray[i], orderQueueArray[i]);
                FillFeeder fillFeeder = new FillFeeder(i, fillQueue, orderQueue);
                Thread thread = new Thread(() => new FillFeederThread().threadRun(fillFeeder));
                thread.Start();
                fillFeederIDs.Add(thread);
                fillFeederWorkers.Add(fillFeeder);

            }
            // Process fills in parallel
            if (numFillProcessorWorkers > 1)
            {
                for (int i = 1; i <= numFillProcessorWorkers; i++)
                {

                    //FillProcessor *fillProcessor = new FillProcessor(i, spaceProxyPtr, fillQueueArray[i], totalFills / numFillProcessorWorkers);
                    FillProcessor fillProcessor = new FillProcessor(i, spaceProxy, fillQueue, totalFills / numFillProcessorWorkers);
                    Thread thread = new Thread(() => new FillProcessorThread().threadRun(fillProcessor, spaceProxy));
                    thread.Start();
                    fillProcessorIDs.Add(thread);
                    fillProcessorWorkers.Add(fillProcessor);
                }
            }

            for (int i = 1; i <= numOrderWorkers; i++)
            {
                //OrderProcessorThread *orderProcessorThread = new OrderProcessorThread(i, spaceProxyPtr, orderQueueArray[i], ordCnt / numOrderWorkers, orderQty);
                OrderProcessorThread orderProcessorThread = new OrderProcessorThread(i, spaceProxy, orderQueue, ordCnt / numOrderWorkers, orderQty);
                Thread thread = new Thread(() => new OrderProcessorThreadCB().threadRun(orderProcessorThread, spaceProxy, partionId));
                thread.Start();
                orderProcessorIDs.Add(thread);
                orderProcessorWorkers.Add(orderProcessorThread);
            }
            //    Console.WriteLine("*** wrokerOrderIDs={0}, fillFeederIDs={1}, fillProcessorIDs={2}",
            // orderProcessorIDs.size(), fillFeederIDs.size(), fillProcessorIDs.size());

            ITransactionManager txManager = GigaSpacesFactory.CreateDistributedTransactionManager();
            //  ManualResetEvent evtObj = new ManualResetEvent(false);


            for (int i = 0; i < orderProcessorIDs.Count; i++)
            {
                orderProcessorIDs[i].Join();
            }

            // Add messages to stop thread
            for (int i = 0; i < numFillFeederWorkers; i++)
            {
                OrderMsg orderMsg = new OrderMsg(-1, -1, -1);
                //orderQueueArray[i].push(orderMsg);
                orderQueue.Enqueue(orderMsg);
            }

            for (int i = 0; i < fillFeederIDs.Count; i++)
            {
                fillFeederIDs[i].Join();
            }

            if (numFillProcessorWorkers == 1)
            {

                for (int i = 1; i <= numFillProcessorWorkers; i++)
                {

                    FillProcessor fillProcessor = new FillProcessor(i, spaceProxy, fillQueue, totalFills / numFillProcessorWorkers);
                    Thread thread = new Thread(() => new FillProcessorThread().threadRun(fillProcessor, spaceProxy));
                    thread.Start();
                    fillProcessorIDs.Add(thread);
                    fillProcessorWorkers.Add(fillProcessor);
                }
            }

            // Add messages to stop thread
            for (int i = 0; i < numFillProcessorWorkers; i++)
            {
                FillMsg fillMsg = new FillMsg(-1, -1, -1);
                //fillQueueArray[i].push(fillMsg);
                fillQueue.Enqueue(fillMsg);
            }

            for (int i = 0; i < fillProcessorIDs.Count; i++)
            {
                fillProcessorIDs[i].Join();
            }
            long orderProcesserTotalEndime = DateTime.Now.Ticks;
            Console.WriteLine("Total Time taken  : {0}", ((orderProcesserTotalEndime - orderProcesserTotalStartTime) / TimeSpan.TicksPerMillisecond));

            ordCnt = 0;
            long orderTime = 0;

            long minProcessTime = orderProcessorWorkers[0].processStartTime;
            long maxProcessTime = orderProcessorWorkers[0].processEndTime;
            for (int i = 0; i < orderProcessorWorkers.Count; i++)
            {
                ordCnt += orderProcessorWorkers[i].orderCnt;
                orderTime += orderProcessorWorkers[i].orderTime;
                if (orderProcessorWorkers[i].processStartTime < minProcessTime)
                {
                    minProcessTime = orderProcessorWorkers[i].processStartTime;
                }
                if (orderProcessorWorkers[i].processStartTime > maxProcessTime)
                {
                    maxProcessTime = orderProcessorWorkers[i].processStartTime;
                }
            }
            Console.WriteLine("Test Config: PartitionID:{0}, Orders: {1}, Fills: {2}, OrderThreads: {3},  FillThreads: {4}",
                        partionId, ordCnt, totalFills, numOrderWorkers, numFillProcessorWorkers);
            long orderTimems = (orderTime / TimeSpan.TicksPerMillisecond);
            double avgOrder = 1.0 * orderTimems / ordCnt;
            long orderMsgPerSec = (long)((orderTime == 0) ? -1.0 : 1.0 * ordCnt / orderTimems * 1000);
            Console.WriteLine("Wrote Orders: {0} in {1} ms, average {2} ms, {3} orders in sec, {4} current time ", ordCnt, orderTimems, avgOrder, orderMsgPerSec, DateTime.Now.ToString("h:mm:ss tt"));

            orderTimems = ((maxProcessTime - minProcessTime) / TimeSpan.TicksPerMillisecond);
            avgOrder = 1.0 * orderTimems / ordCnt;
            orderMsgPerSec = (long)((orderTime == 0) ? -1.0 : 1.0 * ordCnt / orderTimems * 1000);
            Console.WriteLine(">>>>>> Updated code : Wrote Orders: {0} in {1} ms, average {2} ms, {3} orders in sec, {4} current time ", ordCnt, orderTimems, avgOrder, orderMsgPerSec, DateTime.Now.ToString("h:mm:ss tt"));

            long fillCnt = 0;
            long fillTime = 0;

            minProcessTime = fillProcessorWorkers[0].processStartTime;
            maxProcessTime = fillProcessorWorkers[0].processEndTime;

            for (int i = 0; i < fillProcessorWorkers.Count; i++)
            {
                fillCnt += fillProcessorWorkers[i].fillCnt;
                fillTime += fillProcessorWorkers[i].fillTime;

                if (fillProcessorWorkers[i].processStartTime < minProcessTime)
                {
                    minProcessTime = fillProcessorWorkers[i].processStartTime;
                }
                if (fillProcessorWorkers[i].processStartTime > maxProcessTime)
                {
                    maxProcessTime = fillProcessorWorkers[i].processStartTime;
                }
            }

            long fillTimems = (fillTime / TimeSpan.TicksPerMillisecond);

            double avgFill = 1.0 * fillTimems / fillCnt;

            long fillMsgPerSec = (long)((fillTime == 0) ? -1.0 : 1.0 * fillCnt / fillTimems * 1000);

            Console.WriteLine("Wrote Fills: {0} in {1} ms, average {2} ms, {3} fills in sec", fillCnt, fillTimems, avgFill, fillMsgPerSec);

            fillTimems = ((maxProcessTime - minProcessTime) / TimeSpan.TicksPerMillisecond);
            avgFill = 1.0 * fillTimems / fillCnt;
            fillMsgPerSec = (long)((fillTime == 0) ? -1.0 : 1.0 * fillCnt / fillTimems * 1000);
            Console.WriteLine(">>>>>> Updated code : Wrote Fills: {0} in {1} ms, average {2} ms, {3} fills in sec", fillCnt, fillTimems, avgFill, fillMsgPerSec);


            Console.WriteLine("Order Processor finished successfully!");
            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }
    }
}
