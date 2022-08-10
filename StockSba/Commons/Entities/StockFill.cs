using System;
using GigaSpaces.Core.Metadata;

namespace GigaSpaces.Examples.StockSba.Commons.Entities
{
    /// <summary>
    /// The StockFill class
    /// </summary>
    [SpaceClass(Persist = true)]
    public class StockFill
    {

        private string _fillID;

        private string _orderID;

        private string _investmentID;

        private string _action;

        private Nullable<long> _quantity;

        private Nullable<DateTime> _executionTime;

        private Nullable<DateTime> _dateTrade;

        private Nullable<double> _startPrice;

        private Nullable<double> _executionPrice;

        private string _priceCurrency;

        private bool _processed;


        [SpaceID(AutoGenerate = true)]
        public string FillID
        {
            get { return _fillID; }
            set { _fillID = value; }
        }

        [SpaceIndex]
        [SpaceRouting]
        public string OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }

        public string InvestmentID
        {
            get { return _investmentID; }
            set { _investmentID = value; }
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

        public Nullable<DateTime> ExecutionTime
        {
            get { return _executionTime; }
            set { _executionTime = value; }
        }

        public Nullable<DateTime> DateTrade
        {
            get { return _dateTrade; }
            set { _dateTrade = value; }
        }

        public Nullable<double> StartPrice
        {
            get { return _startPrice; }
            set { _startPrice = value; }
        }

        public Nullable<double> ExecutionPrice
        {
            get { return _executionPrice; }
            set { _executionPrice = value; }
        }

        public string PriceCurrency
        {
            get { return _priceCurrency; }
            set { _priceCurrency = value; }
        }

        [SpaceIndex]
        public bool Processed
        {
            get { return _processed; }
            set { _processed = value; }
        }
    }
}