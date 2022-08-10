#pragma once


class Timer
{
public:
	Timer()
		: startTime(0), endTime(0), elapsed(0), currentTime(0) {}
	void StartTimer();
	void StopTimer();
	unsigned __int64 Elapsed();
	unsigned __int64 GetCurrentTimer();

private:
	unsigned __int64 startTime;
	unsigned __int64 endTime;
	unsigned __int64 elapsed;
	unsigned __int64 currentTime;

};

