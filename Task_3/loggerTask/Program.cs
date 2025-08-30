using System;
using System.Management;
using System.Runtime.Versioning;
using System.Threading;
using FileLogger;
using SystemDetailsCollector;

[SupportedOSPlatform("windows")]
class Program
{
    static void Main()
    {
        Console.WriteLine("System Information Collector Running");
        Console.WriteLine("===========================");
        Console.WriteLine();

        var systemInfoCollector = new SystemInfoCollector();
        var periodicFileLogger = new PeriodicFileLogger();

        while (true)
        {
            string comprehensiveInfo = systemInfoCollector.GetComprehensiveSystemInfo();
            periodicFileLogger.AppendWithTimestamp(comprehensiveInfo);
            Thread.Sleep(TimeSpan.FromMinutes(1));
        }
    }
}
// Thread.Sleep(TimeSpan.FromMinutes(1));
