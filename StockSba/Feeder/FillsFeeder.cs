using System;
using System.Diagnostics;
using System.Threading;
using GigaSpaces.Core;
using GigaSpaces.Examples.StockSba.Commons.Entities;
using GigaSpaces.Examples.StockSba.Commons;
using GigaSpaces.XAP.ProcessingUnit.Containers.BasicContainer;

namespace GigaSpaces.Examples.StockSba.Feeder
{
    /// <summary>
    /// The Fills Feeder process imitates the external system that write raw data to the cluster.
    /// This process writes fills to the space. 
    /// </summary>
    [BasicProcessingUnitComponent(Name = "FillsFeeder")]
    public class FillsFeeder : IDisposable
    {

        #region Members
        private int _seqOrderId = 0;

        private FillsFeederConfig _config;
        private StockFill[] _fills;
        private ISpaceProxy _proxy;
		private Thread _feederThread;
        private volatile bool _continueFeeding;
        #endregion        

		[ContainerInitialized]
		public void Initialize(BasicProcessingUnitContainer container)
		{
			Reporter.Report("Starting FillsFeeder");

			_proxy = container.GetSpaceProxy("stock");
			_config = new FillsFeederConfig(container.Properties);
			_continueFeeding = true;

			_fills = new StockFill[_config.NumOfFills];
			_seqOrderId = GetLastOrderId(_config.NumOfFills);

			GenerateFills(_fills);
			_proxy.Snapshot(new StockFill());

			_feederThread = new Thread(Feed);
			_feederThread.Start();			
		}

        /// <summary>
        /// This method breaks the generated fills collections to blocks of a configured size
        ///  and feeds them (WriteMultiple) to the space by blocks.
        /// </summary>
        public void Feed()
        {
            try
            {                
                Reporter.Report("Starting Stock Fills Feeder...");

                //Stopwatch is used to measure feed time.
                Stopwatch stopWatch = new Stopwatch();

                int blocks = _fills.Length / _config.BlockSize;
                StockFill[] buffer = new StockFill[_config.BlockSize];

                Reporter.Report("Start feeding " + _fills.Length + " fills at: " + DateTime.Now.ToShortTimeString());

                stopWatch.Start();
                for (int block = 0; block < blocks; block++)
                {
                    //Copy the current fiils block
                    int offset = block * _config.BlockSize;
                    Array.Copy(_fills, offset, buffer, 0, buffer.Length);

                    //Write the current block to the space
                    _proxy.WriteMultiple(buffer);

                    Thread.Sleep(_config.FeedingThrottle);

                    //Report feed status every defined number of iterations
                    if ((block + 1) % 100 == 0)
                        Reporter.Report("Injected:" + (offset + _config.BlockSize) + " rate:" +
                                          (offset + _config.BlockSize) / stopWatch.Elapsed.TotalSeconds + "/sec");
                    if (!_continueFeeding)
                        break;
                }
                stopWatch.Stop();
                Reporter.Report("Finished feeding. Elapsed time: " + stopWatch.Elapsed);
            }
            catch (Exception ee)
            {
                Reporter.Report("Feeder exception: " + ee.Message);
                Reporter.Report(ee.StackTrace);
            }
        }

		/// <summary>
		/// Stops the feeding process on dispose (Automatically invoked when the hosting container is disposing)
		/// </summary>
		public void Dispose()
		{
			Reporter.Report("FillsFeeder Shutdown");
			Stop();
			if (_feederThread != null)
			{
				_feederThread.Join(_config.FeedingThrottle + 5000);
				_feederThread = null;
			}			
		}

        private void Stop()
        {
            _continueFeeding = false;
        }

        private int GetLastOrderId(int numOfFills)
        {

            int seqOrderId;
            StatusRecord statusTemplate = new StatusRecord();

            //Read the status record
            // look for an existing status record in the space:
            StatusRecord statusRecord = _proxy.Take(statusTemplate, 5000);

            // If there's no status record in space, create a new one:
            if (statusRecord == null)
            {
                //get the last used Order Id
                seqOrderId = 0;

                //update the last used Order Id
                statusRecord = new StatusRecord();
                statusRecord.LastOrderId = numOfFills + 1;
            }
            else
            {
                //get the last used Order Id
                seqOrderId = statusRecord.LastOrderId.Value + 1;

                //update the last used Order Id
                statusRecord.LastOrderId = statusRecord.LastOrderId + numOfFills + 1;
            }
            _proxy.Write(statusRecord);
            return seqOrderId;

        }

        private void GenerateFills(StockFill[] fills)
        {
            Random rnd = new Random(DateTime.Now.GetHashCode());

            for (int i = 0; i < fills.Length; i++)
            {
                StockFill fill = new StockFill();
                fill.OrderID = GetNextOrderID().ToString();
                fill.InvestmentID = TestDataHelper.Symbols[rnd.Next(TestDataHelper.Symbols.Length)];
                fill.Quantity = rnd.Next(100, 1000);
                fill.StartPrice = (double) rnd.Next(100, 1000)/100;
                fill.ExecutionPrice = (double)rnd.Next(100, 1000) / 100;
                fill.Action = TestDataHelper.Actions[rnd.Next(TestDataHelper.Actions.Length)];
                fill.DateTrade = DateTime.Now.AddSeconds(-rnd.Next(3600));
                fill.ExecutionTime = DateTime.Now;
                fill.PriceCurrency = TestDataHelper.Currency[rnd.Next(TestDataHelper.Currency.Length)];
                fill.Processed = false;
                fills[i] = fill;
            }
        }

        private int GetNextOrderID()
        {
            return _seqOrderId++;
        }    	
    }
}