#pragma once

#include <windows.h>

#include "pch.h"
#include "Queue.h"
#include "FillMsg.h"
#include "OrderMsg.h"

DWORD WINAPI FillFeederThread(PVOID p);

class FillFeeder
{
public:
	FillFeeder(int workerID, Queue<FillMsg> &FillQueue, Queue<OrderMsg> &OrderQueue)
	: WorkerID (workerID), fillQueue(FillQueue), orderQueue(OrderQueue) {}

	int WorkerID;
	Queue<FillMsg> &fillQueue;
	Queue<OrderMsg> &orderQueue;
};

typedef FillFeeder * FillFeederPtr;

