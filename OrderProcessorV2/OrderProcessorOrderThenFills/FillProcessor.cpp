#include "pch.h"
#include "FillProcessor.h"
#include "Timer.h"
#include "GS_Order.h"
#include "GS_Fill.h"
#include "OrderMsg.h"
#include "FillMsg.h"

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

	GS_Fill^ fill = gcnew GS_Fill();
	fill->OPID = partionId;
	long nextFillID = 1 + ((fillProcessor->WorkerID - 1)*fillProcessor->fillCnt);
	long lastFillID = nextFillID + fillProcessor->fillCnt - 1;
	Console::WriteLine("*** FillProcessorThread {0}: nextFillID {1}, lastFillID {2}, {3} current time", fillProcessor->WorkerID, nextFillID, lastFillID, DateTime::Now.ToString("h:mm:ss tt"));
	
	ICollection<String^>^ projections = gcnew List<String^>;
	projections->Add(gcnew String("OrderID"));
	projections->Add(gcnew String("Symbol"));
	projections->Add(gcnew String("CalExecValue"));
	projections->Add(gcnew String("CalCumQty"));
	GS_Order^ orderWrite = gcnew GS_Order();
	ChangeSet^ orderChange = gcnew ChangeSet();

	fillProcessor->fillCnt = 0;

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

		//Console::WriteLine("newFillMsg: {0} {1} {2}", newFillMsg.OrderID, newFillMsg.LastShares, newFillMsg.LastPrice);


		fillTimer.StartTimer();

// commented transactions		ITransaction^ tx2 = txManager->Create();
		/*
		Need Sample code to read GS_Order with Primary Key OrderID and read only Quanity and Price fields.
		*/
		//GS_Order^ orderRead = spaceProxy->ReadById<GS_Order^>(newFillMsg.OrderID, nullptr, tx2, 1000*60, ReadModifiers::ExclusiveReadLock);
		
		
//		IdQuery<GS_Order^> ^idQuery = gcnew IdQuery<GS_Order^>(newFillMsg.OrderID);
//		idQuery->Projections = projections;

//		GS_Order^ orderRead = spaceProxy->Read<GS_Order^>(idQuery, tx2, 1000 * 60);
		
		fillTimer.StopTimer();
		fillProcessor->processReadTime += fillTimer.Elapsed();
		fillTimer.StartTimer();

		//GS_Order^ orderRead = spaceProxy->Read<GS_Order^>(idQuery, tx2,LONG_MAX);
		

		//Console::WriteLine("FillProcessorThread {0} - Order Read: {1} {2} {3} {4}",
		//					fillProcessor->WorkerID, orderRead->OrderID, orderRead->Symbol,
		//	orderRead->CalCumQty, orderRead->CalExecValue);


		//Console::WriteLine("Order Read: {0} {1} {2} {3}", orderRead->OrderID, orderRead->Symbol,
		//					orderRead->CalCumQty, orderRead->CalExecValue);
		/*
		Need Sample code to update GS_Order with Primary Key OrderID and pass only CalCumQty and CalExecValue fields to update these two fields.
		*/

		fill->FillID = nextFillID++;
		fill->OrderID = newFillMsg.OrderID;
		fill->LastShares = newFillMsg.LastShares;
		fill->LastPrice = newFillMsg.LastPrice;

		//Console::WriteLine("Writting Order: {0} {1} ", order->OrderID, order->Symbol);
//		 spaceProxy->Write(fill,tx2 ,LONG_MAX,1000);
		 spaceProxy->Write(fill);

		 fillTimer.StopTimer();
		 fillProcessor->processWriteTime += fillTimer.Elapsed();
		 fillTimer.StartTimer();

		//spaceProxy->Write(fill, tx2);
		//Console::WriteLine("FillProcessorThread {0} - added fill", fillProcessor->WorkerID );



		orderWrite->OrderID = nextFillID;// orderRead->OrderID;
		/*
		orderWrite->CalCumQty = (orderRead->CalCumQty.Value)  + newFillMsg.LastShares;
		orderWrite->CalExecValue = (orderRead->CalExecValue.Value) + (newFillMsg.LastPrice * newFillMsg.LastShares);
		//Console::WriteLine("FillProcessorThread {0} - updating order ", fillProcessor->WorkerID );
		spaceProxy->Write(orderWrite, tx2, LONG_MAX, 1000);
		*/

		orderChange->Increment("CalCumQty", newFillMsg.LastShares);
		orderChange->Increment("CalExecValue", (newFillMsg.LastPrice * newFillMsg.LastShares));
		//IChangeResult<GS_Order ^>  ^orderChangeResults =
		//	 spaceProxy->Change<GS_Order ^>(orderWrite, orderChange, tx2, 1000, ChangeModifiers::MemoryOnlySearch);
//		 IChangeResult<GS_Order^>^ orderChangeResults =
//			spaceProxy->Change<GS_Order^>(orderWrite, orderChange);

		//  spaceProxy->Change<GS_Order ^>(orderWrite, orderChange, tx2,LONG_MAX);
		//Console::WriteLine("FillProcessorThread {0} - commiting  tx ", fillProcessor->WorkerID );
		fillTimer.StopTimer();
		fillProcessor->processChangesetTime += fillTimer.Elapsed();
		//Console::WriteLine("processChangesetTime :{0}", fillProcessor->processChangesetTime);

		// commented tx2->Commit(1000 * 60);

		//Console::WriteLine("FillProcessorThread {0} - commited  tx ", fillProcessor->WorkerID);
		//fillTimer.StopTimer();
		fillProcessor->fillTime += fillProcessor->processReadTime + fillProcessor->processWriteTime + fillProcessor->processChangesetTime;//fillTimer.Elapsed();
		fillProcessor->fillCnt++;

		//tx2->Dispose();


		/*
		if (orderRead->CalCumQty == orderRead->Quanity)
		{
			GS_Order^ orderRead2 = spaceProxy->ReadById<GS_Order^>(orderRead->OrderID);
			Console::WriteLine("Order Filed CumValues: {0} {1} {2} {3}", orderRead2->OrderID, orderRead2->Symbol,
				orderRead2->CalCumQty, orderRead2->CalExecValue);

		}
		*/
		if (nextFillID % 200 == 0) {
			Console::WriteLine("FillProcessorThread {0} -> nextFillID {1} -> lastFillID {2} ", fillProcessor->WorkerID, nextFillID, lastFillID);
		}
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