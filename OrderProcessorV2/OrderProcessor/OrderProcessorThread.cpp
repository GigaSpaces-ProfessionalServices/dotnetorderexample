#include "pch.h"
#include "OrderProcessorThread.h"
#include "Timer.h"
#include "GS_Order.h"
#include "GS_Fill.h"
#include "OrderMsg.h"
#include "FillMsg.h"
#include "Logger.h"

using namespace System;
using namespace System::Runtime::InteropServices;

using namespace GigaSpaces::Core;

extern long partionId;

DWORD WINAPI OrderProcessorThreadCB(PVOID ptr)
{

	char logtext[256];
	OrderProcessorThread *orderProcessor = (OrderProcessorThread *)ptr;
	Console::WriteLine("*** Started OrderProcessorThread {0}", orderProcessor->WorkerID);
	IntPtr pointer(orderProcessor->p);
	GCHandle handle = GCHandle::FromIntPtr(pointer);

	ISpaceProxy^ spaceProxy = (ISpaceProxy^)handle.Target;
	Console::WriteLine("*** OrderProcessorThread - Getting txManager ");
	ITransactionManager^ txManager = GigaSpacesFactory::CreateDistributedTransactionManager();
	Console::WriteLine("*** OrderProcessorThread - Created txManager ");

	Timer orderTimer;
	GS_Order^ order = gcnew GS_Order();
	order->OPID = partionId;
	order->Symbol = "IBM";
	order->Quantity = orderProcessor->orderQty;
	order->Price = 10;
	order->CalCumQty = 0;
	order->CalExecValue = 0;

	Console::WriteLine("*** OrderProcessorThread {0}: Adding {1} orders, OrderQty {2}",
						orderProcessor->WorkerID, orderProcessor->orderCnt, orderProcessor->orderQty);
	long firstOrderID = 1 + ((orderProcessor->WorkerID - 1)*orderProcessor->orderCnt);
	long lastOrderID = firstOrderID + orderProcessor->orderCnt - 1;
	Console::WriteLine("*** OrderProcessorThread {0}: firstOrderID {1}, lastOrderID {2}, {3} current time ", orderProcessor->WorkerID, firstOrderID, lastOrderID, DateTime::Now.ToString("h:mm:ss tt"));

	orderProcessor->processStartTime = orderTimer.GetCurrentTimer();

	for (long i = firstOrderID; i <= lastOrderID; i++)
	{
		orderTimer.StartTimer();
		ITransaction^ tx1 = txManager->Create();

		order->OrderID = i;

		//Console::WriteLine("Writting Order: {0} {1} ", order->OrderID, order->Symbol);
		spaceProxy->Write(order, tx1, LONG_MAX, 1000*60);
		tx1->Commit();
		//tx1->Dispose();

		orderTimer.StopTimer();
		orderProcessor->orderTime += orderTimer.Elapsed();
		//sprintf_s(logtext, sizeof(logtext), "New Order GSpace Time %d", orderTimer.Elapsed());
		//Logger::log(logtext);

		OrderMsg orderMsg(order->OrderID.Value, order->Quantity.Value,  order->Price.Value);
		orderProcessor->orderQueue.push(orderMsg);
	}

	orderProcessor->processEndTime = orderTimer.GetCurrentTimer();


	unsigned __int64 orderTimems = (orderProcessor->orderTime / 10000);
	double avgOrder = 1.0* orderTimems / orderProcessor->orderCnt;

	long orderMsgPerSec = (orderTimems == 0) ? -1.0 : 1.0*orderProcessor->orderCnt / orderTimems * 1000;

	Console::WriteLine("OrderProcessorThread {0} - Wrote Orders: {1} in {2} ms, average {3} ms, {4} fills in sec, {5} current time ",
		orderProcessor->WorkerID, orderProcessor->orderCnt, orderTimems, avgOrder, orderMsgPerSec, DateTime::Now.ToString("h:mm:ss tt"));


	Console::WriteLine("*** Exiting OrderProcessorThread {0}", orderProcessor->WorkerID);
	return 0;

}