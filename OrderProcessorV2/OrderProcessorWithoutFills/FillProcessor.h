#pragma once

#include <windows.h>

#include "pch.h"
#include "Queue.h"
#include "FillMsg.h"

DWORD WINAPI FillProcessorThread(PVOID p);

class FillProcessor
{
public:
	FillProcessor(int workerID, PVOID ptr, Queue<FillMsg> &queue, long FillCnt )
		: WorkerID(workerID), p(ptr), fillQueue(queue), fillTime(0),  fillCnt(FillCnt){}

	int WorkerID;
	PVOID p;
	Queue<FillMsg> &fillQueue;
	unsigned __int64 fillTime;
	long fillCnt;
	unsigned __int64 processStartTime;
	unsigned __int64 processEndTime;
};

typedef FillProcessor * FillProcessorPtr;

