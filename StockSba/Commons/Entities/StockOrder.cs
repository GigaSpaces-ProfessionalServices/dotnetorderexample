using System;
using GigaSpaces.Core.Metadata;

namespace GigaSpaces.Examples.StockSba.Commons.Entities
{
    /// <summary>
    /// The StockOrder class
    /// </summary>
    [SpaceClass(Persist = true)]
    public class StockOrder
    {

        private string _orderID;

        private string _action;

        private Nullable<long> _quantity;

        private Nullable<double> _subTotal;

        private Nullable<double> _percentageChange;
        
        private bool _done;


        [SpaceID]
        [SpaceRouting]
        public string OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }

        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }

        public Nullable<long> Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public Nullable<double> SubTotal
        {
            get { return _subTotal; }
            set { _subTotal = value; }
        }

        public Nullable<double> PercentageChange
        {
            get { return _percentageChange; }
            set { _percentageChange = value; }
        }

        public bool Done
        {
            get { return _done; }
            set { _done = value; }
        }
    }
}