using System;
using System.IO;
using GigaSpaces.XAP.ProcessingUnit.Containers;

namespace PUDebugExecuter
{
    class Program
    {
        static void Main(string[] args)
        {     
            Console.WriteLine("Press enter to start the processing units and press enter again to stop the processing units");
            Console.ReadLine();

			String deployPath = Path.GetFullPath(@"..\..\..\Deploy");
			ProcessingUnitContainerHost processorContainerHost = new ProcessingUnitContainerHost(Path.Combine(deployPath, "DataProcessor"), null, null);
			ProcessingUnitContainerHost feederContainerHost = new ProcessingUnitContainerHost(Path.Combine(deployPath, "DataFeeder"), null, null);         
                                    
            Console.ReadLine();
            feederContainerHost.Dispose();
            processorContainerHost.Dispose();
        }
    }
}
