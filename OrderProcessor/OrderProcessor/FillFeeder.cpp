#include "pch.h"
#include "FillFeeder.h"
#include "Timer.h"
#include "GS_Order.h"
#include "GS_Fill.h"
#include "OrderMsg.h"
#include "FillMsg.h"

using namespace System;
using namespace System::Runtime::InteropServices;

using namespace GigaSpaces::Core;

extern long partionId;


DWORD WINAPI FillFeederThread(PVOID ptr)
{

	
	FillFeeder *fillFeeder = (FillFeeder *)ptr;
	Console::WriteLine("*** Started FillFeederThread {0}", fillFeeder->WorkerID);
	long fillMsgCnt = 0;

	while (true)
	{
		if (fillFeeder->orderQueue.Empty())
		{
			Sleep(500);
			continue;
		}
		OrderMsg newOrderMsg = fillFeeder->orderQueue.pop();

		// Done with processing
		if (newOrderMsg.OrderID == -1)
		{
			break;
		}
		//Console::WriteLine("newOrderMsg: {0} {1} {2}", newOrderMsg.OrderID, newOrderMsg.Quanity, newOrderMsg.Price);
		long lastShares = 1;

		for (long i = 1; i <= newOrderMsg.Quanity; i++)
		{
			FillMsg fillMsg(newOrderMsg.OrderID, lastShares, newOrderMsg.Price);
			fillFeeder->fillQueue.push(fillMsg);
			fillMsgCnt++;
		}
	}

	Console::WriteLine("FillFeederThread {0} - Wrote {1} FillMsg",
					fillFeeder->WorkerID, fillMsgCnt);

	return 0;

}