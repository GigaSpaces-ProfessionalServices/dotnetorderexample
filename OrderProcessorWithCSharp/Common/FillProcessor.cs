using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using GigaSpaces.Core;
using GigaSpaces.Core.Metadata;

namespace GigaSpaces.Examples.OrderProcessorWithCSharp.Common
{


    public class FillProcessor
    {
        public int WorkerID;

        public ConcurrentQueue<FillMsg> fillQueue;
        public long fillTime;
        public long fillCnt;
        public long processStartTime;
        //PVOID p;
        public long processEndTime;
        public ISpaceProxy spaceProxy;

        public FillProcessor(int workerID, ISpaceProxy SpaceProxy, ConcurrentQueue<FillMsg> queue, long FillCnt)
        {
            WorkerID = workerID;
            fillQueue = queue;
            fillTime = 0;
            fillCnt = FillCnt;
            spaceProxy = SpaceProxy;
        }

    }
}