#pragma once
#include <windows.h>

#include "pch.h"
#include "Queue.h"
#include "OrderMsg.h"

DWORD WINAPI OrderProcessorThreadCB(PVOID p);

class OrderProcessorThread
{
public:
	OrderProcessorThread(int workerID, PVOID ptr, Queue<OrderMsg> &queue, long OrderCnt, long OrderQty)
		: WorkerID(workerID), p(ptr), orderQueue(queue), orderCnt(OrderCnt), orderQty(OrderQty),
		orderTime(0) {}

	int WorkerID;
	PVOID p;
	Queue<OrderMsg> &orderQueue;
	unsigned __int64 orderTime;
	long orderCnt;
	long orderQty;
	unsigned __int64 processStartTime;
	unsigned __int64 processEndTime;
};

typedef OrderProcessorThread *OrderProcessorThreadPtr;

