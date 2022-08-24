using System;
using System.Collections.Generic;
using GigaSpaces.Core.Metadata;

namespace GigaSpaces.Examples.OrderProcessorWithCSharp.Common
{


    public class FillMsg
    {
        public long OrderID;
        public long LastShares;
        public double LastPrice;

        public FillMsg(long orderID, long lastShares, double lastPrice)
        {
            OrderID = orderID;
            LastShares = lastShares;
            LastPrice = lastPrice;
        }

    }
}