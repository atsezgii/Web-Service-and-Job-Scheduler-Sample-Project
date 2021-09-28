using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CmesSapEntegration.Helpers
{
    public class SapGetConicColorScheduler
    {
        public async void Start()
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = await schedulerFactory.GetScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<SapGetConicColorsJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()


                .WithIdentity("SapGetConicColorsJob ", "GreetingGroup")
                .StartNow()
                .WithSimpleSchedule(x => x
                .WithIntervalInSeconds(60)
                .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);

        }
    }
}