using ConsoleAppInGit;
using System;
using System.Runtime.CompilerServices;

namespace ConsoleApp5
{
    internal class Program
    {
        public event EventHandler? ThresholdReached;
        static async Task Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
                Console.ReadLine();
            }           
        }

        static void Sync()
        {
            Console.WriteLine("Run sync START");
            DoSomething(1);
            DoSomething(2);
            DoSomething(3);
            DoSomething(4);
            DoSomething(5);
            Console.WriteLine("Run sync END");
        }

        static async void AsyncTAP()
        {
            Console.WriteLine("Run async START");

            Task doSomethingAsyncTask = DoSomethingAsync(1);
            Console.WriteLine($"Continuation - main forsætter.  Task ID {doSomethingAsyncTask.Id} igang");
            Console.WriteLine("Nået til AWAIT");
            await doSomethingAsyncTask;
            Console.WriteLine("Efter AWAIT, async metodekald færdigt");

            Console.WriteLine("Run async END");
        }

        static void AsyncWaitAll()
        {
            Console.WriteLine("Run async Many tasks START");

            Task doSomethingAsyncTask1 = DoSomethingAsync(1);
            Task doSomethingAsyncTask2 = DoSomethingAsync(2);
            Task doSomethingAsyncTask3 = DoSomethingAsync(3);

            Console.WriteLine($"Continuation - main forsætter.  Task IDs {doSomethingAsyncTask1.Id},{doSomethingAsyncTask2.Id},{doSomethingAsyncTask3.Id} igang");
            Console.WriteLine("Nået til AWAIT");
            Task.WaitAll(doSomethingAsyncTask1, doSomethingAsyncTask2, doSomethingAsyncTask3);
            Console.WriteLine("Efter AWAIT ALL, Alle metodekald færdige");

            Console.WriteLine("Run async Many tasks END");
        }

        static void ParallelMaxThreads()
        {
            Console.WriteLine("Run parallel fuld skrue START");
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
        }

        static void Parallel2Threads()
        {
            Console.WriteLine("Run parralel på 2 tråde START");
            Parallel.Invoke(
            new ParallelOptions { MaxDegreeOfParallelism = 2 },
            () => DoSomething(1),
            () => DoSomething(2),
            () => DoSomething(3),
            () => DoSomething(4),
            () => DoSomething(5)
            );
            Console.WriteLine("Run parralel på 2 tråde START");
        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Sync");
            Console.WriteLine("2) Async TAP");
            Console.WriteLine("3) Async Wait.All");
            Console.WriteLine("4) Parallel max threads");
            Console.WriteLine("5) Parallel 2 threads");
            Console.WriteLine("6) Threads and Events");

            Console.WriteLine("0) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Sync();
                    return true;
                case "2":
                    AsyncTAP();
                    return true;
                case "3":
                    AsyncWaitAll();
                    return true;
                case "4":
                    ParallelMaxThreads();
                    return true;
                case "5":
                    Parallel2Threads();
                    return true;
                case "6":
                    ThreadEvents();
                    return true;
                case "0":
                    return false;
                default:
                    return true;
            }

        }

        static void ThreadEvents()
        {
            var calculate = new Calculate();
            calculate.HalfDone += Calculate_HalfDone;

            int calculateResult1 = 0;
            int calculateResult2 = 0;
            int calculateResult3 = 0;

            Parallel.Invoke(
                () => calculateResult1 = calculate.doCalculation(1),
                () => calculateResult2 = calculate.doCalculation(2),
                () => calculateResult3 = calculate.doCalculation(3));

            Console.WriteLine($"Result 1: {calculateResult1}");
            Console.WriteLine($"Result 2: {calculateResult2}");
            Console.WriteLine($"Result 3: {calculateResult3}");
        }

        private static void Calculate_HalfDone(object? sender, EventArgs e)
        {
            Console.WriteLine($"HalfDoneEvnetHandler trigged! on Thread {Thread.CurrentThread.ManagedThreadId}");
        }

 
        static void DoSomething(int number)
        {
            Console.WriteLine($"DoSomeTask {number} started on Thread {Thread.CurrentThread.ManagedThreadId}");
            //4 sec of dummy work
            var endTime1 = DateTime.Now.AddSeconds(2);
            while (DateTime.Now < endTime1)
            {
            }

            var endTime2 = DateTime.Now.AddSeconds(2);
            while (DateTime.Now < endTime2)
            {
            }
            Console.WriteLine($"DoSomeTask {number} completed on Thread {Thread.CurrentThread.ManagedThreadId}");
        }


        static async Task DoSomethingAsync(int number)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"DoSomeTask {number} started on Thread {Thread.CurrentThread.ManagedThreadId}");
                //4 sec of dummy work
                var endTime1 = DateTime.Now.AddSeconds(2);
                while (DateTime.Now < endTime1)
                {
                }
                var endTime2 = DateTime.Now.AddSeconds(2);
                while (DateTime.Now < endTime2)
                {
                }
                Console.WriteLine($"DoSomeTask {number} completed on Thread {Thread.CurrentThread.ManagedThreadId}");

            });
        }



    }
}
