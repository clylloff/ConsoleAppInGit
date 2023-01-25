using System;
using System.Runtime.CompilerServices;

namespace ConsoleApp5
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Run sync START");
            DoSomething(1);
            DoSomething(2);
            DoSomething(3);
            DoSomething(4);
            DoSomething(5);
            Console.WriteLine("Run sync END");

            Console.WriteLine("----------------------------------------");

            //Console.WriteLine("Run async START");

            //Task doSomethingAsyncTask = DoSomethingAsync(1);
            //Console.WriteLine($"Continuation - main forsætter.  Task ID {doSomethingAsyncTask.Id} igang");
            //Console.WriteLine("Nået til AWAIT");
            //await doSomethingAsyncTask;
            //Console.WriteLine("Efter AWAIT, async metodekald færdigt");

            //Console.WriteLine("Run async END");

            //Console.WriteLine("----------------------------------------");

            //Console.WriteLine("Run async Many tasks START");

            //Task doSomethingAsyncTask1 = DoSomethingAsync(1);
            //Task doSomethingAsyncTask2 = DoSomethingAsync(2);
            //Task doSomethingAsyncTask3 = DoSomethingAsync(3);


            //Console.WriteLine($"Continuation - main forsætter.  Task IDs {doSomethingAsyncTask1.Id},{doSomethingAsyncTask2.Id},{doSomethingAsyncTask3.Id} igang");
            //Console.WriteLine("Nået til AWAIT");
            //Task.WaitAll(doSomethingAsyncTask1, doSomethingAsyncTask2, doSomethingAsyncTask3);
            //Console.WriteLine("Efter AWAIT ALL, Alle metodekald færdige");

            //Console.WriteLine("Run async Many tasks START");

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Run parralel fuld skrue START");
            Parallel.Invoke(
            () => DoSomething(1),
            () => DoSomething(2),
            () => DoSomething(3),
            () => DoSomething(4),
            () => DoSomething(5),
            () => DoSomething(6),
            () => DoSomething(7),
            () => DoSomething(8),
            () => DoSomething(9)
            );
            Console.WriteLine("Run parralel fuld skrue END");

            Console.WriteLine("----------------------------------------");

            //Console.WriteLine("Run parralel på 2 tråde START");
            //Parallel.Invoke(
            //new ParallelOptions { MaxDegreeOfParallelism = 2 },
            //() => DoSomething(1),
            //() => DoSomething(2),
            //() => DoSomething(3),
            //() => DoSomething(4),
            //() => DoSomething(5)
            //);
            //Console.WriteLine("Run parralel på 2 tråde START");
        }

        static void DoSomething(int number)
        {
            Console.WriteLine($"DoSomeTask {number} started on Thread {Thread.CurrentThread.ManagedThreadId}");
            //5 sec of dummy work
            var endTime = DateTime.Now.AddSeconds(5);
            while (DateTime.Now < endTime)
            {
            }
            Console.WriteLine($"DoSomeTask {number} completed on Thread {Thread.CurrentThread.ManagedThreadId}");
        }



        static async Task DoSomethingAsync(int number)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"DoSomeTask {number} started on Thread {Thread.CurrentThread.ManagedThreadId}");
                //5 sec of dummy work
                var endTime = DateTime.Now.AddSeconds(5);
                while (DateTime.Now < endTime)
                {
                }
                Console.WriteLine($"DoSomeTask {number} completed on Thread {Thread.CurrentThread.ManagedThreadId}");

            });
        }



    }
}
