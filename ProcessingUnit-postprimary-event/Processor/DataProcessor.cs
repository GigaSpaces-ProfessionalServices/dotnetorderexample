using System;
using System.Collections.Generic;
using System.Threading;
using GigaSpaces.Examples.ProcessingUnit.Common;
using GigaSpaces.XAP.Events;
using GigaSpaces.XAP.Events.Polling;
using GigaSpaces.XAP.Remoting;

namespace GigaSpaces.Examples.ProcessingUnit.Processor
{
    /// <summary>
    /// This class contain the processing logic, marked as polling event driven.
    /// </summary>
    [PollingEventDriven(Name="DataProcessor", MinConcurrentConsumers = 1, MaxConcurrentConsumers = 4)]
	[SpaceRemotingService]
    public class DataProcessor : IProcessorStatisticsProvider
	{
		/// <summary>
		/// Holds processed types count for statistic purposes
		/// </summary>
    	private readonly IDictionary<int, int> _processedTypes = new Dictionary<int, int>();

		#region Template
		/// <summary>
		/// Gets an unprocessed data
		/// </summary>
		[EventTemplate]
    	public Data UnprocessedData
    	{
    		get
			{ 
				Data template = new Data();
				template.Processed = false;
				return template;
			}
		}
		#endregion

		#region Processing methods
		/// <summary>
        /// Fake delay that represents processing time
        /// </summary>
        private const int ProcessingTime = 100;
        /// <summary>
        /// Receives a data and process it
        /// </summary>
        /// <param name="data">Data received</param>
        /// <returns>Processed data</returns>
        [DataEventHandler]
        public Data ProcessData(Data data)
        {
            Console.WriteLine("**** processing - Took element with info: " + data.Info);
            //Process data...			
            Thread.Sleep(ProcessingTime);
			//Accumulate total processing time        	
            //Set data state to processed
            data.Processed = true;
            Console.WriteLine("**** processing - done");
        	UpdateStatistics(data);

            return data;
        }

		/// <summary>
		/// Update statistics
		/// </summary>
		/// <param name="data"></param>
    	private void UpdateStatistics(Data data)
    	{
    		int processedType = data.Type.Value;
			lock(_processedTypes)
			{
				int currentProcessed = 0;
				_processedTypes.TryGetValue(processedType, out currentProcessed);
				_processedTypes[processedType] = ++currentProcessed;
			}
    	}

    	#endregion


		#region IProcessorStatisticsProvider Members

		public int GetProcessObjectCount(int type)
		{
			//Synchronize because we can have concurrent consumers, obviously not a very
			//concurrent implementation but suffice for example purposes
			lock(_processedTypes)
			{
				int result = 0;
				_processedTypes.TryGetValue(type, out result);
				return result;
			}
		}

		#endregion
	}
}
