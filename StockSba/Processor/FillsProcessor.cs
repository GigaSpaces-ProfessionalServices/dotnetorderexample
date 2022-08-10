 using GigaSpaces.Core;
 using GigaSpaces.Examples.StockSba.Commons;
 using GigaSpaces.Examples.StockSba.Commons.Entities;
 using GigaSpaces.XAP.Events;
 using GigaSpaces.XAP.Events.Polling;

namespace GigaSpaces.Examples.StockSba.Processor
{
	/// <summary>
	/// Process given data from cluster and write the processed data back to the cluster.
	/// </summary>
	[PollingEventDriven(Name="FillsProcessor", MinConcurrentConsumers = 1, MaxConcurrentConsumers = 4)]
    public class FillsProcessor 
    {        
		[EventTemplate]
        public StockFill UnprocessedFillTemplate
        {
            get
            {
				// Create unprocessed fill template:
				StockFill unprocessedFill = new StockFill();
				unprocessedFill.Processed = false;
            	return unprocessedFill;
            }
        }

        /// <summary>
        /// This method contains the business logic executed over the space.
        /// Process an existing Fill data to create a new Order.
        /// </summary>
        /// <param name="fill">The StockFill to process</param>
        /// <param name="spaceProxy">Space proxy the event came from</param>
        /// <param name="transaction">Transaction context for the operation is exists</param>
        /// <returns>A processed StockOrder</returns>
        [DataEventHandler]
        public StockOrder CreateOrder(StockFill fill, ISpaceProxy spaceProxy, ITransaction transaction)
        {
            // Perform calculations based on the Fills data.
            // Create a StockOrder 
            StockOrder order = new StockOrder();

            order.Action = fill.Action;
            order.OrderID = fill.OrderID;
            order.Quantity = fill.Quantity;

            ///////////////////////////////////////////
            //Enrich the raw data of StockOrder
            //Processing logic implemented here
            /////////////////////////////////////////// 

            //Calculate sub total – only for sold stock
            if (fill.Action == TestDataHelper.ActionSell)
                order.SubTotal = (fill.ExecutionPrice - fill.StartPrice)*fill.Quantity;
            else
                order.SubTotal = null;
            //Calculate percentage change
            order.PercentageChange = (fill.ExecutionPrice - fill.StartPrice) / fill.StartPrice * 100;

            ////////////////////////////////////////////

            // Change fill status and order status
            fill.Processed = true;
            order.Done = true;

			//Write back the updated fill to the space
        	spaceProxy.Write(fill, transaction);

            return order;
        }
    }
}