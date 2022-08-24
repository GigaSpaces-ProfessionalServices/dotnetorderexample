using System;
using System.Collections.Generic;
using GigaSpaces.Core.Metadata;

namespace GigaSpaces.Examples.OrderProcessorWithCSharp.Common
{


    public class OrderMsg
    {

        public long OrderID;
        public long Quanity;
        public double Price;

        public OrderMsg(long orderID, long quanity, double price)
        {
            OrderID = orderID;
            Quanity = quanity;
            Price = price;
        }

    }
}