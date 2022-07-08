using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace ThreadPerformance
{
    internal class Program
    {

        public static void IncreamentCounter1()
        {
            long count = 0;
            for(long i = 0; i <= 10000000; i++)
            {
                count++;    
            }
            Console.WriteLine("Count 1 = "+count);
        }

        public static void IncreamentCounter2()
        {
            long count = 0;
            for (long i = 0; i <= 10000000; i++)
            {
                count++;
            }
            Console.WriteLine("Count 2 = " + count);
        }
        static void Main(string[] args)
        {

            //Multi threaded
            Thread t1 = new Thread(IncreamentCounter1);
            Thread t2 = new Thread(IncreamentCounter2);

            Console.WriteLine("Multithread");
           Stopwatch sw2 = new Stopwatch();
            sw2.Start();

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            sw2.Stop();
            //Elapsed time of multithreaded = 00:00:00.0016533 - by single threaded
            Console.WriteLine("Elapsed time of multithreaded = " + sw2.Elapsed);



            //Single threaded 
           
           Stopwatch sw1 = new Stopwatch();
            sw1.Start();

            IncreamentCounter1();
            IncreamentCounter2();

            sw1.Stop();
            //Elapsed time = 00:00:00.0848906 - by single threaded
            Console.WriteLine("Elapsed time single threaded = " + sw1.Elapsed);

            Console.WriteLine("Elapsed time diff = " + (sw1.Elapsed-sw2.Elapsed) );

            Console.ReadLine();
        }
    }
}
