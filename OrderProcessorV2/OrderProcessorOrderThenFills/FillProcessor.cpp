#include "pch.h"
#include "FillProcessor.h"
#include "Timer.h"
#include "GS_Order.h"
#include "GS_Fill.h"
#include "OrderMsg.h"
#include "FillMsg.h"
#include "CustomTransaction.cpp"

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;

using namespace GigaSpaces::Core;
using namespace GigaSpaces::Core;

extern long partionId;


DWORD WINAPI FillProcessorThread(PVOID ptr)
{


	FillProcessor *fillProcessor = (FillProcessor *)ptr;
	Console::WriteLine("*** Started FillProcessorThread {0}", fillProcessor->WorkerID);
	// Convert void* to Object^
	IntPtr pointer(fillProcessor->p);
	GCHandle handle = GCHandle::FromIntPtr(pointer);
	//Object^ obj = (Object^)handle.Target;

	ISpaceProxy^ spaceProxy = (ISpaceProxy^)handle.Target;
	Console::WriteLine("*** FillProcessorThread - Getting txManager ");
	ITransactionManager^ txManager = GigaSpacesFactory::CreateDistributedTransactionManager();
	Console::WriteLine("*** FillProcessorThread - Created txManager ");
	
	Timer fillTimer;

	long nextFillID = 1 + ((fillProcessor->WorkerID - 1)*fillProcessor->fillCnt);
	long lastFillID = nextFillID + fillProcessor->fillCnt - 1;
	Console::WriteLine("*** FillProcessorThread {0}: nextFillID {1}, lastFillID {2}, {3} current time", fillProcessor->WorkerID, nextFillID, lastFillID, DateTime::Now.ToString("h:mm:ss tt"));
	
	ChangeSet^ orderChange = gcnew ChangeSet();

	int batchSize = 200;
	array< GS_Fill^ >^ fillArray = gcnew array< GS_Fill^ >(batchSize);
	array< GS_Order^ >^ orderWriteArray = gcnew array< GS_Order^ >(batchSize);
	array< ChangeSet^ >^ changeSetArray = gcnew array< ChangeSet^ >(batchSize);

	int initializeArr;
	fillProcessor->fillCnt = 0;
	int arrayCount = 0;
	
	fillProcessor->processStartTime = fillTimer.GetCurrentTimer();

	while (nextFillID <= lastFillID)
	{
		if (fillProcessor->fillQueue.Empty())
		{
			//Console::WriteLine(" >>>>>>>>>>>>>>>>>>>> sleep 500 nextFillID : {0}, lastFillID: {1}", nextFillID, lastFillID);
			Sleep(500);
			continue;
		}
		
		FillMsg newFillMsg = fillProcessor->fillQueue.pop();
		// Done with processing
		if (newFillMsg.OrderID == -1)
		{
			break;
		}
		
		GS_Fill^ fill = gcnew GS_Fill();
		fill->OPID = partionId;

		fill->FillID = nextFillID++;
		fill->OrderID = newFillMsg.OrderID;
		fill->LastShares = newFillMsg.LastShares;
		fill->LastPrice = newFillMsg.LastPrice;
		
		fillArray[arrayCount] = fill;
		
		//caching changeset 
		GS_Order^ orderWrite = gcnew GS_Order();
		orderWrite->OrderID = newFillMsg.OrderID;
		ChangeSet^ orderChange = gcnew ChangeSet();
		orderChange->Increment("CalCumQty", newFillMsg.LastShares); //newFillMsg is dynamic per order so cannot be applied to range of orders
		orderChange->Increment("CalExecValue", (newFillMsg.LastPrice * newFillMsg.LastShares));

		orderWriteArray[arrayCount] = orderWrite;
		changeSetArray[arrayCount] = orderChange;
		
		arrayCount++;
		// write and apply changeset as per batchsize 
		if (arrayCount % batchSize == 0) {
			fillTimer.StartTimer();

			// with transactions
			ITransaction^ tx2 = txManager->Create();
			spaceProxy->WriteMultiple(fillArray, tx2);

			for (int i = 0; i < batchSize; i++) {
				orderWrite = orderWriteArray[i];
				orderChange = changeSetArray[i];
				spaceProxy->Change<GS_Order^>(orderWrite, orderChange, tx2, LONG_MAX, ChangeModifiers::MemoryOnlySearch);
			}
			tx2->Commit();
			// end transaction

			fillTimer.StopTimer();
			fillProcessor->fillTime += fillTimer.Elapsed();
			arrayCount = 0;
		}
		
		fillProcessor->fillCnt++;

	}
	fillProcessor->processEndTime = fillTimer.GetCurrentTimer();

	unsigned __int64 fillTimems = (fillProcessor->fillTime / 10000);
	unsigned __int64 processReadTime = (fillProcessor->processReadTime / 10000);
	unsigned __int64 processWriteTime = (fillProcessor->processWriteTime / 10000);
	unsigned __int64 processChangesetTime = (fillProcessor->processChangesetTime / 10000);
	double avgFill = 1.0* fillTimems / fillProcessor->fillCnt;

	long fillMsgPerSec = (fillTimems == 0) ? -1.0 : 1.0*fillProcessor->fillCnt / fillTimems * 1000;

	Console::WriteLine("FillProcessorThread {0} - Wrote Fills: {1} in {2} ms, average {3} ms, {4} fills in sec, {5} current time, processReadTime :{6} , processWriteTime :{7},processChangesetTime : {8}",
						fillProcessor->WorkerID, fillProcessor->fillCnt, fillTimems, avgFill, fillMsgPerSec, DateTime::Now.ToString("h:mm:ss tt"), processReadTime, processWriteTime,processChangesetTime);


	Console::WriteLine("*** Exiting FillProcessorThread {0}", fillProcessor->WorkerID);
	return 0;

}