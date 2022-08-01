using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebJobScheduler6._0.Works
{
    public class Work:IJob
    {
        public  Task Execute(IJobExecutionContext context)
        {
            var task = Task.Run(() => logfile(DateTime.Now));
            return task;
        }
        public void logfile(DateTime time)
        {
            string path = "C:\\log\\sample2.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(time);
                writer.Close();
            }
        }
    }
}
