using Quartz;
using Quartz.Impl;

namespace WebJobScheduler6._0.Works
{
    public class SchedulerTask
    {
        //Below I give you some examples
        //Every Second : * * * ? * *
        //Every Minute : 0 * * ? * *
        //Every Day noon 12 pm : 0 0 12 * * ?
        // Every 5 min in between 8am to 11pm : 0 0/5 8-23 ? * * *
        //Custom schedule create https://www.freeformatter.com/cron-expression-generator-quartz.html
        private static readonly string ScheduleCronExpression = "* * * ? * *";
        public static async System.Threading.Tasks.Task StartAsync()
        {
            try
            {
                var scheduler = await StdSchedulerFactory.GetDefaultScheduler();
                if (!scheduler.IsStarted)
                {
                    await scheduler.Start();
                }
                var job1 = JobBuilder.Create<Work>().WithIdentity("ExecuteTaskServiceCallJob1", "group1").Build();
                var trigger1 = TriggerBuilder.Create().WithIdentity("ExecuteTaskServiceCallTrigger1", "group1").WithCronSchedule(ScheduleCronExpression).Build();
                await scheduler.ScheduleJob(job1, trigger1);
            }
            catch (Exception ex) { }
        }
    }
}
