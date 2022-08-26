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
        public int threadRun(FillFeeder fillFeeder)
        {
            //	FillFeeder fillFeeder = (FillFeeder*)ptr;
            Console.WriteLine("** Started FillFeederThread {0}", fillFeeder.WorkerID);
            long fillMsgCnt = 0;

            while (true)
            {

                //				if (!fillFeeder.orderQueue.Any())
                if (fillFeeder.orderQueue.Count <= 0)
                {
                    Thread.Sleep(500);
                    continue;
                }
                //Console.WriteLine(fillFeeder.orderQueue.Count); 

                OrderMsg newOrderMsg;
                fillFeeder.orderQueue.TryDequeue(out newOrderMsg);

                if (newOrderMsg == null)
                {
                    continue;
                }
                // Done with processing
                if (newOrderMsg.OrderID == -1)
                {
                    break;
                }
                //Console.WriteLine("newOrderMsg: {0} {1} {2}", newOrderMsg.OrderID, newOrderMsg.Quanity, newOrderMsg.Price);
                long lastShares = 1;

                for (long i = 1; i <= newOrderMsg.Quanity; i++)
                {
                    //FillMsg fillMsg(newOrderMsg.OrderID, lastShares, newOrderMsg.Price);
                    fillFeeder.fillQueue.Enqueue(new FillMsg(newOrderMsg.OrderID, lastShares, newOrderMsg.Price));
                    fillMsgCnt++;
                }
            }

            Console.WriteLine("FillFeederThread {0} - Wrote {1} FillMsg",
                            fillFeeder.WorkerID, fillMsgCnt);

            return 0;
        }
    }
}
