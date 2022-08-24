using GigaSpaces.Core;
using GigaSpaces.Examples.OrderProcessorWithCSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderProcessorWithCSharp
{
    class OrderProcessorThreadCB
    {
        //long partionId;
        public int threadRun(OrderProcessorThread orderProcessor, ISpaceProxy spaceProxy, long partionId)
        {
            Console.WriteLine("*** Started OrderProcessorThread {0}", orderProcessor.WorkerID);
            Console.WriteLine("*** OrderProcessorThread - Getting txManager ");
            ITransactionManager txManager = GigaSpacesFactory.CreateDistributedTransactionManager();
            Console.WriteLine("*** OrderProcessorThread - Created txManager ");

            //Timer orderTimer;
            GS_Order order = new GS_Order();
            order.OPID = partionId;
            order.Symbol = "IBM";
            order.Quantity = orderProcessor.orderQty;
            order.Price = 10;
            order.CalCumQty = 0;
            order.CalExecValue = 0;

            Console.WriteLine("*** OrderProcessorThread {0}: Adding {1} orders, OrderQty {2}",
                                orderProcessor.WorkerID, orderProcessor.orderCnt, orderProcessor.orderQty);
            long firstOrderID = 1 + ((orderProcessor.WorkerID - 1) * orderProcessor.orderCnt);
            long lastOrderID = firstOrderID + orderProcessor.orderCnt - 1;
            Console.WriteLine("*** OrderProcessorThread {0}: firstOrderID {1}, lastOrderID {2}, {3} current time ", orderProcessor.WorkerID, firstOrderID, lastOrderID, DateTime.Now.ToString("h:mm:ss tt"));

            orderProcessor.processStartTime = DateTime.Now.Ticks;

            for (long i = firstOrderID; i <= lastOrderID; i++)
            {
                long orderTimeElapsed = DateTime.Now.Ticks;
                ITransaction tx1 = txManager.Create();
                order.OrderID = i;

                //Console.WriteLine("Writting Order: {0} {1} ", order.OrderID, order.Symbol);
                spaceProxy.Write(order, tx1, long.MaxValue, 1000 * 60);
                tx1.Commit();
                orderTimeElapsed = DateTime.Now.Ticks - orderTimeElapsed;
                orderProcessor.orderTime += orderTimeElapsed;
                OrderMsg orderMsg = new OrderMsg(order.OrderID.Value, order.Quantity.Value, order.Price.Value);
                /*if (orderMsg == null) {
                    continue;
                }*/
                orderProcessor.orderQueue.Enqueue(orderMsg) ;
            }
            orderProcessor.processEndTime = DateTime.Now.Ticks;

            long orderTimems = (orderProcessor.orderTime / TimeSpan.TicksPerMillisecond);
            double avgOrder = 1.0 * orderTimems / orderProcessor.orderCnt;

            long orderMsgPerSec = (long)(orderTimems == 0 ? -1.0 : 1.0 * orderProcessor.orderCnt / orderTimems * 1000);

            Console.WriteLine("OrderProcessorThread {0} - Wrote Orders: {1} in {2} ms, average {3} ms, {4} fills in sec, {5} current time ",
                orderProcessor.WorkerID, orderProcessor.orderCnt, orderTimems, avgOrder, orderMsgPerSec, DateTime.Now.ToString("h:mm:ss tt"));


            Console.WriteLine("*** Exiting OrderProcessorThread {0}", orderProcessor.WorkerID);
            return 0;
        }
    }
}
