using CmesSapEntegration.Controllers;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CmesSapEntegration.Helpers
{
    public class SapGetConicColorsJob : IJob
    {
         async Task IJob.Execute(IJobExecutionContext context)
        {
            HomeController controller = new HomeController();
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            controller.Example2();
            //await Console.Out.WriteLineAsync("Greetings from HelloJob!");
            //Task taskA = new Task(() => Console.WriteLine("Hello from task at {0}", DateTime.Now.ToString()));
            //taskA.Start();
            //return taskA;
        }
    }
}