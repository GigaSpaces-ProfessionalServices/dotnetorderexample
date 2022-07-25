#include "pch.h"
#include <windows.h>
#include "Timer.h"

using namespace System;

void Timer::StartTimer()
{
	FILETIME ct;
	GetSystemTimeAsFileTime(&ct);
	startTime = (((unsigned __int64)ct.dwLowDateTime +
		(((unsigned __int64)ct.dwHighDateTime) << 32)));
}
void Timer::StopTimer()
{
	FILETIME ct;
	GetSystemTimeAsFileTime(&ct);
	endTime = (((unsigned __int64)ct.dwLowDateTime +
		(((unsigned __int64)ct.dwHighDateTime) << 32)));

	elapsed = endTime - startTime;
}

unsigned __int64
Timer::Elapsed()
{
	return elapsed;
}


unsigned __int64
Timer::GetCurrentTimer()
{
	FILETIME ct;
	GetSystemTimeAsFileTime(&ct);
	return (((unsigned __int64)ct.dwLowDateTime +
		(((unsigned __int64)ct.dwHighDateTime) << 32)));
}