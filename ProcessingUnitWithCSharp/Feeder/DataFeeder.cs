using System;
using System.Threading;
using GigaSpaces.Core;
using GigaSpaces.Core.Exceptions;
using GigaSpaces.Examples.ProcessingUnit.Common;
using GigaSpaces.XAP.ProcessingUnit.Containers.BasicContainer;
using GigaSpaces.XAP.Remoting.Executors;

namespace GigaSpaces.Examples.ProcessingUnit.Feeder
{
	/// <summary>
	/// Data feeder feeds new data to the space that needs to be processed
	/// </summary>
	[BasicProcessingUnitComponent(Name = "DataFeeder")]
	public class DataFeeder : IDisposable
	{
		#region Members
		/// <summary>
		/// Delay between the feeds in miliseconds
		/// </summary>
		private const string FeedDelayProperty = "FeedDelay";

		/// <summary>
		/// States if this processing unit was stopped
		/// </summary>
		private volatile bool _started;
        /// <summary>
        /// The proxy to the cluster
        /// </summary>
		private ISpaceProxy _proxy;
        /// <summary>
        /// The thread that will do the actual feed
        /// </summary>
		private Thread _feedingThread;
        /// <summary>
        /// Delay between the feeds
        /// </summary>
		private int _feedDelay;	   

	    private const int DefaultFeedDelay = 1000;
		private const int DataTypesCount = 5;
		private const int PrintStatisticIterCount = 5;
		#endregion		

		/// <summary>
		/// Starts the feeding process once the container is initialized.
		/// </summary>
		/// <param name="container">Managing container.</param>
		[ContainerInitialized]
		private void StartFeeding(BasicProcessingUnitContainer container)
		{
			//Get feed delay from the custom properties, if none found uses the default one
			string feedDelayStr;
			container.Properties.TryGetValue(FeedDelayProperty, out feedDelayStr);
			_feedDelay = (String.IsNullOrEmpty(feedDelayStr) ? DefaultFeedDelay : int.Parse(feedDelayStr));			        	
			//Gets the proxy to the processing grid
			_proxy = container.GetSpaceProxy("dataExampleSpace");
			//Set the started state to true
			_started = true;
			//Create a working thread
			_feedingThread = new Thread(Feed);
			//Starts the working thread
			_feedingThread.Start();
		}

		///<summary>
        ///Destroys the processing unit, any allocated resources should be cleaned up in this method
        ///</summary>
        public void Dispose()
        {
            //Set the started state to false
            _started = false;
            if (_feedingThread != null)
            {
                //Wait for the working thread to finish its work
                _feedingThread.Join();
            }
        }
        		
		/// <summary>
		/// Generates and feeds data to the space
		/// </summary>
		private void Feed()
		{
			try
			{				
				//Create a proxy to the remote service which provide processing statistics
				ExecutorRemotingProxyBuilder<IProcessorStatisticsProvider> builder = new ExecutorRemotingProxyBuilder<IProcessorStatisticsProvider>(_proxy);
				IProcessorStatisticsProvider processorStatisticsProvider = builder.CreateProxy();
				int iteration = 0;
				Random random = new Random();
				while (_started)
				{
					//Create a new data object with random info and random type
					GS_Fills data = new Data(Guid.NewGuid().ToString(), random.Next(DataTypesCount));
					Console.WriteLine("Added data object with info {0} and type {1}", data.Info, data.Type);
					//Feed the data into the cluster
					_proxy.Write(data);
					Thread.Sleep(_feedDelay);
					//Check if should print statistics
					if (++iteration % PrintStatisticIterCount == 0)
					{
						Console.WriteLine("Asking processor of type " + data.Type.Value + " how many objects of that type it has processed");
						int processedTypes = processorStatisticsProvider.GetProcessObjectCount(data.Type.Value);
						Console.WriteLine("Received total processed object of type " + data.Type.Value + " is " + processedTypes);
					}
				}
			}
			catch(SpaceException e)
			{
				Console.WriteLine("Space Error has occured - " + e);
			}
			catch(Exception e)
			{
				Console.WriteLine("Error has occured - " + e);
			}
		}
        
	}
}
