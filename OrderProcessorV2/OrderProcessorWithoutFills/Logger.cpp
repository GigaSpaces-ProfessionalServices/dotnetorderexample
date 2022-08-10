#include "pch.h"

#include <stdio.h>
#include <time.h>
#include <string.h>
#include <windows.h>
#include "Logger.h"
#include "Queue.h"


class LogReuest
{
public:
	LogReuest(string TimeStr, string LogText) : timeStr(TimeStr), logtext(LogText) { }
	LogReuest(const char *TimeStr, const char *LogText) : timeStr(TimeStr), logtext(LogText) { }
	string timeStr;
	string logtext;

};

typedef LogReuest * LogReuestPtr;

Queue<LogReuestPtr> logQueue;
bool isInit = false;

void getmstime(char *buf, int bufsize)
{
	SYSTEMTIME slocalTime;
	GetLocalTime(&slocalTime);

	sprintf_s(buf, bufsize,
		"%04d%02d%02d %02d:%02d:%02d.%03d",
		slocalTime.wYear, slocalTime.wMonth, slocalTime.wDay,
		slocalTime.wHour, slocalTime.wMinute, slocalTime.wSecond, slocalTime.wMilliseconds);
}
DWORD WINAPI Logger::FileLoggerThread(PVOID p)
{
	FILE *fp;
	std::string filename = "C:/\GigaSpaces/\smart-cache.net-16.1.1-x64/\NET v4.0/\Examples/\OrderProcessor/\OrderProcessor/\logs/\OrderProcessor.log";
	fp = fopen(filename.c_str(), "w+");

	char LocalTransactTime[22];

	getmstime(LocalTransactTime, sizeof(LocalTransactTime));

	fprintf(fp,  "%s Logger Started OrderProcessor ...\n", LocalTransactTime);
	fflush(fp);
	while (true)
	{
		if (logQueue.Empty())
		{
			Sleep(500);
			continue;
		}
		LogReuestPtr logReq = logQueue.pop();

		fprintf(fp, "%s %s\n", logReq->timeStr.c_str(), logReq->logtext.c_str());
		fflush(fp);

		delete logReq;
	}


	fclose(fp);

	return 0;

}


void Logger::init()
{
	if (isInit)
		return;

	DWORD fillFeederId;
	HANDLE hFillFeeder = CreateThread(NULL, 0, Logger::FileLoggerThread, (PVOID)0, 0, &fillFeederId);
	isInit = true;

}

void Logger::log(string logStr)
{
	char LocalTransactTime[22];

	getmstime(LocalTransactTime, sizeof(LocalTransactTime));
	logQueue.push(new LogReuest(LocalTransactTime, logStr));
}

void Logger::log(const char *logStr)
{
	char LocalTransactTime[22];

	getmstime(LocalTransactTime, sizeof(LocalTransactTime));
	logQueue.push(new LogReuest(LocalTransactTime, logStr));
}


