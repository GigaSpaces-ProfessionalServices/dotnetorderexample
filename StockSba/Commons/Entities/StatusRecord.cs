using System;
using GigaSpaces.Core.Metadata;

namespace GigaSpaces.Examples.StockSba.Commons.Entities
{
    [SpaceClass(Persist = true)]
    public class StatusRecord
    {
        public StatusRecord()
        {
            statusRecordType = "LastUsedOrderId";
        }

        private string statusRecordType;

        private Nullable<int> lastOrderId;

        [SpaceID]
        public string StatusRecordType
        {
            get { return statusRecordType; }
            set { statusRecordType = value; }
        }

        //The last used OrderId 
        public Nullable<int> LastOrderId
        {
            get { return lastOrderId; }
            set { lastOrderId = value; }
        }
    }
}