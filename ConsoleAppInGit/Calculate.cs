using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppInGit
{
    internal class Calculate
    {
        private object doCalculation(object obj)
        {
            var endTime = DateTime.Now.AddSeconds(5);

            while (DateTime.Now < endTime)
            {
            }
 
            return obj;
        }
    }
}
