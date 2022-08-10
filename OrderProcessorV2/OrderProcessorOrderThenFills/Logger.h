
#include "pch.h"

#include <windows.h>
#include <string>
using std::string;

class  Logger
{
public:
	
	static void init();
	static void log(string logStr);
	static void log(const char *logStr);

private:


	static DWORD WINAPI FileLoggerThread(PVOID p);
};

