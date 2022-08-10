#pragma once


#include <windows.h>

#include <queue>

template <typename T>
class Queue
{
private:
	CRITICAL_SECTION              d_mutex;
	CONDITION_VARIABLE			d_condition;
	std::queue<T>				d_queue;

public:

	Queue()
	{
		InitializeCriticalSection(&d_mutex);
		InitializeConditionVariable(&d_condition);

	}
	void push(T const& value) {
		{

			EnterCriticalSection(&d_mutex);
			d_queue.push(value);
			LeaveCriticalSection(&d_mutex);
		}
		WakeConditionVariable(&d_condition);
	}
	T pop(DWORD waitTime = INFINITE) {
		EnterCriticalSection(&d_mutex);
		if (d_queue.empty())
		{
			SleepConditionVariableCS(&d_condition, &d_mutex, waitTime);
		}

		T rc(d_queue.front());
		d_queue.pop();
		LeaveCriticalSection(&d_mutex);
		return rc;
	}


	bool Empty()
	{

		EnterCriticalSection(&d_mutex);
		bool r = d_queue.empty();
		LeaveCriticalSection(&d_mutex);

		return r;
	}

};

