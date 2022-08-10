#pragma once
#include "pch.h"


using namespace System;
//using namespace System::Collections::Generic;
using namespace System::Threading;

using namespace GigaSpaces::Core;
using namespace GigaSpaces::Core::Metadata;
using namespace GigaSpaces::XAP::Events;
using namespace GigaSpaces::XAP::Events::Polling;
using namespace GigaSpaces::XAP::Remoting;
using namespace GigaSpaces::Examples::ProcessingUnit::Common;

namespace OrderProcessingUnit {

	[PollingEventDriven(Name = "OrderProcessor", MinConcurrentConsumers = 1, MaxConcurrentConsumers = 1)]
	[SpaceRemotingService]
	public ref class OrderProcessor
	{
		private:
			static bool firstEvent = true;
		public:
			[EventTemplate]
			GigaSpaces::Examples::ProcessingUnit::Common::Data^ UnprocessedData()
			{ 
				GigaSpaces::Examples::ProcessingUnit::Common::Data^ data;
				data =gcnew GigaSpaces::Examples::ProcessingUnit::Common::Data();
				data->Processed = false;
				return data;
			}

			[DataEventHandler]
			GigaSpaces::Examples::ProcessingUnit::Common::Data^ ProcessData(GigaSpaces::Examples::ProcessingUnit::Common::Data^ data)
			{
				Console::WriteLine("OrderProcessingUnit - Took element with info:");
				Thread::Sleep(100);
				data->Processed = true;
				Console::WriteLine("OrderProcessingUnit - done");

				if (firstEvent) {
					Console::WriteLine("OrderProcessingUnit - first event");
					firstEvent = false;
				}
				return data;
			}

	};
}
