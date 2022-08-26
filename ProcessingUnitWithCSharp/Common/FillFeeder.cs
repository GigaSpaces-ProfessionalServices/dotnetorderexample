using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using GigaSpaces.Core.Metadata;

namespace GigaSpaces.Examples.ProcessingUnit.Common
{
    public class FillFeeder
    {
        public int WorkerID;
        public ConcurrentQueue<FillMsg> fillQueue;
        public ConcurrentQueue<OrderMsg> orderQueue;

        public FillFeeder(int workerID, ConcurrentQueue<FillMsg> FillQueue, ConcurrentQueue<OrderMsg> OrderQueue)
        {
            WorkerID = workerID;
            fillQueue = FillQueue;
            orderQueue = OrderQueue;
        }

    }
}
