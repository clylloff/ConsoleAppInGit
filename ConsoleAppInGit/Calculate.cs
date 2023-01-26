using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppInGit
{
    internal class Calculate
    {
        public event EventHandler? HalfDone;
        public int doCalculation(int id)
        {
            Console.WriteLine($"DoCalculation {id} started on Thread {Thread.CurrentThread.ManagedThreadId}");

            int noOfChecks =0;
            //4 sec of dummy work
            var endTime1 = DateTime.Now.AddSeconds(2);
            while (DateTime.Now < endTime1)
            {
                noOfChecks++;
            }

            HalfDone?.Invoke(this, new EventArgs());

            var endTime2 = DateTime.Now.AddSeconds(2);
            while (DateTime.Now < endTime2)
            {
                noOfChecks++;
            }
            Console.WriteLine($"DoCalculation {id} Ended on Thread {Thread.CurrentThread.ManagedThreadId}");
            return noOfChecks;
        }
    }
}
