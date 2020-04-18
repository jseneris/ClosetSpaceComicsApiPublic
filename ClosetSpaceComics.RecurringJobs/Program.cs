using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace ClosetSpaceComics.RecurringJobs
{
	// To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
	class Program
	{
		static void Main(string[] args)
		{
			var hostConfig = new JobHostConfiguration();
			hostConfig.UseTimers();

			var host = new JobHost(hostConfig);
			host.RunAndBlock();
		}
	}
}
