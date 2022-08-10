using System;
using System.Collections.Generic;
using System.Threading;
using GigaSpaces.Examples.ProcessingUnit.Common;
using GigaSpaces.XAP.Events;
using GigaSpaces.XAP.Events.Polling;
using GigaSpaces.XAP.ProcessingUnit.Containers.BasicContainer;
using GigaSpaces.XAP.Remoting;
using GigaSpaces.Core;
using GigaSpaces.Core.Admin;
using GigaSpaces.Core.Admin.ServiceGrid;
using GigaSpaces.Core.Admin.ServiceGrid.Space;
using GigaSpaces.Core.XAP.ProcessingUnit.Containers.BasicContainer;

namespace GigaSpaces.Examples.ProcessingUnit.Processor
{
    [BasicProcessingUnitComponent]
    class MyComponent
    {

        public MyComponent()
        {
            Console.WriteLine(">>>>> Hello World");

        }

       
        [PostPrimaryAttribute]
        public void StartMonitoring(ISpaceProxy proxy)
        {
            Console.WriteLine(">>>>> post primary -> startmonitoring " + proxy.Name);
        }


        [BeforePrimary]
        public void beforePrimaryEvent(ISpaceProxy proxy, SpaceMode spaceMode)
        {
            Console.WriteLine(">>>>> before primary -> beforePrimaryEvent " + proxy.Name + ", spaceMode: " + spaceMode.ToString());
        }

        [PostPrimary]
        public void postPrimaryEvent(ISpaceProxy proxy, SpaceMode spaceMode)
        {
            Console.WriteLine(">>>>> post primary -> postPrimaryEvent " + proxy.Name + ", spaceMode: " + spaceMode.ToString());
        }

        [BeforeBackup]
        public void beforeBackupEvent(ISpaceProxy proxy, SpaceMode spaceMode)
        {
            Console.WriteLine(">>>>> before backup -> beforeBackupEvent " + proxy.Name + ", spaceMode: " + spaceMode.ToString());
        }

        [PostBackup]
        public void postBackupEvent(ISpaceProxy proxy, SpaceMode spaceMode)
        {
            Console.WriteLine(">>>>> post backup -> postBackupEvent " + proxy.Name + ", spaceMode: " + spaceMode.ToString());
        }



    }
}
