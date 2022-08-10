#include "pch.h"

using namespace System;
using namespace GigaSpaces::Core;
using namespace GigaSpaces::Core::Events;

#include "GS_Order.h"



void
Space_OrderChanged(SpaceDataEventArgs<GS_Order^> ^e)
{
	GS_Order^ gsOrder = e->Object;
		
	Console::WriteLine("GS_Order: {0} {1} {2} {3} {4}", gsOrder->OrderID, gsOrder->Quantity, gsOrder->Price, gsOrder->CalCumQty, gsOrder->CalExecValue);

}


void registerOrderListner(ISpaceProxy^ spaceProxy)
{
	IDataEventSession^ dataEventSession = spaceProxy->DefaultDataEventSession;
	GS_Order^ orderTemplate = gcnew GS_Order();
	//IEventRegistration^ eventRegistration = dataEventSession->AddListener(orderTemplate, Space_OrderChanged, DataEventType::Write);
	//IEventRegistration^ eventRegistration = dataEventSession->AddListener(orderTemplate, Space_OrderChanged, DataEventType::Write, 100);
}
