using System;
using System.Collections.Generic;
using GigaSpaces.Examples.StockSba.Commons;

namespace GigaSpaces.Examples.StockSba.Feeder
{

    /// <summary>
    /// Fills feeder config
    /// </summary>
	public class FillsFeederConfig
	{
        #region Defaults
        private const int numOfFillsDefault = 15 * 1000;
        private const int blockSizeDefault = 50;
        private const int retrySleepTimeDefault = 2000;
        private const int maxReconnectionsRetryDefault = 4;
        private const int feedingThrottleDefault = 200;

        #endregion

        #region Fields       
        /// <summary>
        /// The number of feels to feed to the space
        /// </summary>
        private readonly int _numOfFills;
        /// <summary>
        /// The amount of fills to write on each WriteMultiple operation to the space
        /// </summary>
        private readonly int _blockSize;
        /// <summary>
        /// The sleep time between failed connection attempts to the space
        /// </summary>
        private readonly int _retrySleepTime;
        /// <summary>
        /// Max reconnections retries to the space
        /// </summary>
        private readonly int _maxReconnectionsRetry;
        /// <summary>
        /// Sleep time between every feed
        /// </summary>
        private readonly int _feedingThrottle;

        #endregion

        public FillsFeederConfig(IDictionary<string, string> properties)
	    {
            _numOfFills = numOfFillsDefault;
            _blockSize = blockSizeDefault;
            _retrySleepTime = retrySleepTimeDefault;
            _maxReconnectionsRetry = maxReconnectionsRetryDefault;
            _feedingThrottle = feedingThrottleDefault;            

            try
            {
                string tempVal;

                properties.TryGetValue("NumOfFills", out tempVal);
                if (!string.IsNullOrEmpty(tempVal))
                    _numOfFills = int.Parse(tempVal);

                properties.TryGetValue("BlockSize", out tempVal);
                if (!string.IsNullOrEmpty(tempVal))
                    _blockSize = int.Parse(tempVal);

                properties.TryGetValue("RetrySleepTimeMs", out tempVal);
                if (!string.IsNullOrEmpty(tempVal))
                    _retrySleepTime = int.Parse(tempVal);

                properties.TryGetValue("MaxReconnectionsRetry", out tempVal);
                if (!string.IsNullOrEmpty(tempVal))
                    _maxReconnectionsRetry = int.Parse(tempVal);

                properties.TryGetValue("FeedingThrottle", out tempVal);
                if (!string.IsNullOrEmpty(tempVal))
                    _feedingThrottle = int.Parse(tempVal);


            }
            catch (Exception ex)
            {
                Reporter.Report("Error parsing configuration - Using defaults");
                Reporter.Report(ex.Message);
                Reporter.Report(ex.StackTrace);
            }
            
            Reporter.Report("Configuration loaded:");
            Reporter.Report(this);
	    }

        #region Properties       

        /// <summary>
        /// The number of feels to feed to the space
        /// </summary>
        public int NumOfFills
        {
            get { return _numOfFills; }
        }

        /// <summary>
        /// The amount of fills to write on each WriteMultiple operation to the space
        /// </summary>
        public int BlockSize
        {
            get { return _blockSize; }
        }

        /// <summary>
        /// The sleep time between failed connection attempts to the space
        /// </summary>
        public int RetrySleepTimeMs
        {
            get { return _retrySleepTime; }
        }

        /// <summary>
        /// Max reconnections retries to the space
        /// </summary>
        public int MaxReconnectionsRetry
        {
            get { return _maxReconnectionsRetry; }
        }

        /// <summary>
        /// Sleep time between every feed
        /// </summary>
        public int FeedingThrottle
        {
            get { return _feedingThrottle; }
        }

        #endregion

        public override string ToString()
		{
			return "FillsFeederConfig:" + Environment.NewLine +				
				"* NumOfFills = " + NumOfFills + Environment.NewLine +
				"* BlockSize = " + BlockSize + Environment.NewLine +
                "* RetrySleepTimeMs = " + RetrySleepTimeMs + Environment.NewLine +
                "* MaxReconnectionsRetry = " + MaxReconnectionsRetry + Environment.NewLine +
                "* FeedingThrottle = " + FeedingThrottle + Environment.NewLine +
				"End of FillsFeederConfig." + Environment.NewLine;
		}
	}
}