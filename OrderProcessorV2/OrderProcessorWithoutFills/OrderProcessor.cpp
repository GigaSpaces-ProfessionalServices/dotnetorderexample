#include "pch.h"
#include <vector>
#include "Queue.h"
#include "GS_Order.h"
#include "GS_Fill.h"
#include "OrderMsg.h"
#include "FillMsg.h"
#include "FillProcessor.h"
#include "FillFeeder.h"
#include "OrderProcessorThread.h"
#include "NewOrderListner.h"
#include "Timer.h"
#include "Logger.h"
#include <array>



using namespace System;
using namespace System::Runtime::InteropServices;
//using namespace System::Runtime::InteropServices;
using namespace GigaSpaces::Core;
using namespace GigaSpaces::Core::Events;

Queue<OrderMsg> orderQueue;
Queue<FillMsg> fillQueue;

Queue<OrderMsg> orderQueueArray[10];
Queue<FillMsg> fillQueueArray[10];



long partionId = 1;
long ordCnt = 5;
long totalFills = 0;
long orderQty = 10;
int numOrderWorkers = 1;
int numFillFeederWorkers = 1;
int numFillProcessorWorkers = 1;


std::vector<OrderProcessorThreadPtr> orderProcessorWorkers;
std::vector<FillFeederPtr> fillFeederWorkers;
std::vector<FillProcessorPtr> fillProcessorWorkers;

std::vector<HANDLE> orderProcessorIDs;
std::vector<HANDLE> fillFeederIDs;
std::vector<HANDLE> fillProcessorIDs;

int main(array<System::String ^> ^args)
{
	Logger::init();

	Logger::log("Order Processor");

	Console::WriteLine("Number of args:" + args->Length);

	for (int i = 0; i < args->Length; i++)
	{
		String^ argVal = args[i];
		Console::WriteLine("Arg idx: {0}  value: {1}", i, Convert::ToInt64(argVal));

		switch (i)
		{
		case 0:
			partionId = Convert::ToInt64(argVal);
			break;
		case 1:
			ordCnt = Convert::ToInt64(argVal);
			break;
		case 2:
			orderQty = Convert::ToInt64(argVal);
			break;
		case 3:
			numOrderWorkers = Convert::ToInt64(argVal);
			break;
		case 4:
			numFillProcessorWorkers = Convert::ToInt64(argVal);
			break;
		}

	}
	

	totalFills = ordCnt * orderQty;

	String^ spaceName = "EmbeddedSpace";

	ISpaceProxy^ spaceProxy;

	Console::WriteLine("*** Creating embedded space named '" + spaceName + "'...");
	EmbeddedSpaceFactory embeddedSpaceFactory(spaceName);
	//ClusterInfo^  clinfo;
	//clinfo = gcnew ClusterInfo("partitioned",0,0,2,1);

	//embeddedSpaceFactory.Clustered = true;

	//embeddedSpaceFactory.ClusterInfo=clinfo;
	spaceProxy = embeddedSpaceFactory.Create();

	Console::WriteLine("*** Connected to space.");


	GCHandle handle = GCHandle::Alloc(spaceProxy);
	IntPtr pointer = GCHandle::ToIntPtr(handle);
	void* spaceProxyPtr = pointer.ToPointer();


	Timer orderTimer;
	unsigned __int64  orderProcesserTotalStartTime = orderTimer.GetCurrentTimer();

	for (int i = 1; i <= numFillFeederWorkers; i++)
	{
		//FillFeeder *fillFeeder = new FillFeeder(i, fillQueueArray[i], orderQueueArray[i]);
		FillFeeder* fillFeeder = new FillFeeder(i, fillQueue, orderQueue);
		DWORD fillFeederId;
		HANDLE hFillFeeder = CreateThread(NULL, 0, FillFeederThread, (PVOID)fillFeeder, 0, &fillFeederId);
		fillFeederIDs.push_back(hFillFeeder);
		fillFeederWorkers.push_back(fillFeeder);
	}
	// Process fills in parallel
	if (numFillProcessorWorkers > 1)
	{

		for (int i = 1; i <= numFillProcessorWorkers; i++)
		{
			break;
			//FillProcessor *fillProcessor = new FillProcessor(i, spaceProxyPtr, fillQueueArray[i], totalFills / numFillProcessorWorkers);
			FillProcessor* fillProcessor = new FillProcessor(i, spaceProxyPtr, fillQueue, totalFills / numFillProcessorWorkers);
			DWORD id;
			HANDLE hFillProcessor1 = CreateThread(NULL, 0, FillProcessorThread, (PVOID)fillProcessor, 0, &id);
			fillProcessorIDs.push_back(hFillProcessor1);
			fillProcessorWorkers.push_back(fillProcessor);
		}
	}


	for (int i = 1; i <= numOrderWorkers; i++)
	{
		//OrderProcessorThread *orderProcessorThread = new OrderProcessorThread(i, spaceProxyPtr, orderQueueArray[i], ordCnt / numOrderWorkers, orderQty);
		OrderProcessorThread* orderProcessorThread = new OrderProcessorThread(i, spaceProxyPtr, orderQueue, ordCnt / numOrderWorkers, orderQty);

		DWORD orderProcessorId;
		HANDLE hOrderProcessor = CreateThread(NULL, 0, OrderProcessorThreadCB, (PVOID)orderProcessorThread, 0, &orderProcessorId);
		orderProcessorIDs.push_back(hOrderProcessor);
		orderProcessorWorkers.push_back(orderProcessorThread);
	}


	Console::WriteLine("*** wrokerOrderIDs={0}, fillFeederIDs={1}, fillProcessorIDs={2}",
		orderProcessorIDs.size(), fillFeederIDs.size(), fillProcessorIDs.size());

	ITransactionManager^ txManager = GigaSpacesFactory::CreateDistributedTransactionManager();


	for (int i = 0; i < orderProcessorIDs.size(); i++)
	{
		WaitForSingleObject(orderProcessorIDs[i], INFINITE);
	}

	// Add messages to stop thread
	for (int i = 0; i < numFillFeederWorkers; i++)
	{
		OrderMsg orderMsg(-1, -1, -1);
		//orderQueueArray[i].push(orderMsg);
		orderQueue.push(orderMsg);
	}

	for (int i = 0; i < fillFeederIDs.size(); i++)
	{
		WaitForSingleObject(fillFeederIDs[i], INFINITE);
	}

	if (numFillProcessorWorkers == 1)
	{
	
		for (int i = 1; i <= numFillProcessorWorkers; i++)
		{
			break;

			//FillProcessor *fillProcessor = new FillProcessor(i, spaceProxyPtr, fillQueueArray[i], totalFills / numFillProcessorWorkers);
			FillProcessor* fillProcessor = new FillProcessor(i, spaceProxyPtr, fillQueue, totalFills / numFillProcessorWorkers);
			DWORD id;
			HANDLE hFillProcessor1 = CreateThread(NULL, 0, FillProcessorThread, (PVOID)fillProcessor, 0, &id);
			fillProcessorIDs.push_back(hFillProcessor1);
			fillProcessorWorkers.push_back(fillProcessor);
		}
	}


	

	// Add messages to stop thread
	for (int i = 0; i < numFillProcessorWorkers; i++)
	{
		FillMsg fillMsg(-1, -1, -1);
		//fillQueueArray[i].push(fillMsg);
		fillQueue.push(fillMsg);
	}



	for (int i = 0; i < fillProcessorIDs.size(); i++)
	{
		WaitForSingleObject(fillProcessorIDs[i], INFINITE);
	}

	unsigned __int64  orderProcesserTotalEndime = orderTimer.GetCurrentTimer();
	Console::WriteLine("Total Time taken  : {0}",((orderProcesserTotalEndime - orderProcesserTotalStartTime)/10000));

	ordCnt = 0;
	unsigned __int64 orderTime = 0;

	unsigned __int64 minProcessTime = orderProcessorWorkers[0]->processStartTime;
	unsigned __int64 maxProcessTime = orderProcessorWorkers[0]->processEndTime;
	for (int i = 0; i < orderProcessorWorkers.size(); i++)
	{
		ordCnt += orderProcessorWorkers[i]->orderCnt;
		orderTime += orderProcessorWorkers[i]->orderTime;
		if (orderProcessorWorkers[i]->processStartTime < minProcessTime) {
			minProcessTime = orderProcessorWorkers[i]->processStartTime;
		}
		if (orderProcessorWorkers[i]->processStartTime > maxProcessTime) {
			maxProcessTime = orderProcessorWorkers[i]->processStartTime;
		}
	}

	Console::WriteLine("Test Config: PartitionID:{0}, Orders: {1}, Fills: {2}, OrderThreads: {3},  FillThreads: {4}", 
						partionId, ordCnt, totalFills, numOrderWorkers, numFillProcessorWorkers);
	unsigned __int64 orderTimems = (orderTime / 10000);
	double avgOrder = 1.0* orderTimems / ordCnt;
	long orderMsgPerSec = (orderTime == 0) ? -1.0 : 1.0*ordCnt / orderTimems * 1000;
	Console::WriteLine("Wrote Orders: {0} in {1} ms, average {2} ms, {3} orders in sec, {4} current time ", ordCnt, orderTimems, avgOrder, orderMsgPerSec, DateTime::Now.ToString("h:mm:ss tt"));
	
	orderTimems = ((maxProcessTime - minProcessTime) / 10000);
	avgOrder = 1.0 * orderTimems / ordCnt;
	orderMsgPerSec = (orderTime == 0) ? -1.0 : 1.0 * ordCnt / orderTimems * 1000;
	Console::WriteLine(">>>>>> Updated code : Wrote Orders: {0} in {1} ms, average {2} ms, {3} orders in sec, {4} current time ", ordCnt, orderTimems, avgOrder, orderMsgPerSec, DateTime::Now.ToString("h:mm:ss tt"));

//	Console::WriteLine(">>>>>> Total time taken for order processing {0} ms ",((maxProcessTime-minProcessTime) / 10000));

	long fillCnt = 0;
	unsigned __int64 fillTime = 0;

	minProcessTime = fillProcessorWorkers[0]->processStartTime;
	maxProcessTime = fillProcessorWorkers[0]->processEndTime;

	for (int i = 0; i < fillProcessorWorkers.size(); i++)
	{
		fillCnt += fillProcessorWorkers[i]->fillCnt;
		fillTime += fillProcessorWorkers[i]->fillTime;
		
		if (fillProcessorWorkers[i]->processStartTime < minProcessTime) {
			minProcessTime = fillProcessorWorkers[i]->processStartTime;
		}
		if (fillProcessorWorkers[i]->processStartTime > maxProcessTime) {
			maxProcessTime = fillProcessorWorkers[i]->processStartTime;
		}
	}

	unsigned __int64 fillTimems = (fillTime / 10000);

	double avgFill = 1.0* fillTimems /fillCnt;
	
	long fillMsgPerSec = (fillTime == 0) ? -1.0 : 1.0*fillCnt / fillTimems *1000;

	Console::WriteLine("Wrote Fills: {0} in {1} ms, average {2} ms, {3} fills in sec", fillCnt, fillTimems, avgFill, fillMsgPerSec);

	fillTimems = ((maxProcessTime - minProcessTime) / 10000);
	avgFill = 1.0 * fillTimems / fillCnt;
	fillMsgPerSec = (fillTime == 0) ? -1.0 : 1.0 * fillCnt / fillTimems * 1000;
	Console::WriteLine(">>>>>> Updated code : Wrote Fills: {0} in {1} ms, average {2} ms, {3} fills in sec", fillCnt, fillTimems, avgFill, fillMsgPerSec);
//	Console::WriteLine(">>>>>> Total time taken for fills processing {0} ms, {1} fills in sec ", fillTimemsUpdated, (fillCnt/ ((maxProcessTime - minProcessTime) / 10000000)));

	// Read 100 orders
	/*
	array<GS_Order^> ^orderresults = spaceProxy->ReadMultiple(gcnew GS_Order(), 20);
	Console::WriteLine("Read {0} Fills", orderresults->Length);

	for (int i = 0; i < orderresults->Length; i++)
	{
		GS_Order^ gsOrder = orderresults[i];
		Console::WriteLine("GS_Order: {0} {1} {2} {3} {4}", gsOrder->OrderID, gsOrder->Quanity, gsOrder->Price, gsOrder->CalCumQty, gsOrder->CalExecValue);

	}

	// Read 100 fills
	GS_Fill^ gsFillCondition =gcnew GS_Fill();
	gsFillCondition->OrderID = 1;
	array<GS_Fill^> ^results = spaceProxy->ReadMultiple(gsFillCondition, 20);
	Console::WriteLine("Read {0} Fills", results->Length);

	for (int i = 0; i < results->Length; i++)
	{
		GS_Fill^ gsFill = results[i];
		Console::WriteLine("GS_Fill: {0} {1} {2} {3}", gsFill->FillID, gsFill->OrderID, gsFill->LastShares, gsFill->LastPrice);
		
	}
	*/

	//spaceProxy->Dispose();
	Console::WriteLine("Order Processor finished successfully!");
	Console::WriteLine("Press ENTER to exit.");
	Console::ReadLine();



    return 0;
}
