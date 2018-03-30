using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PieFactory
{
    public class Program
    {
        public static int filling = 2000;
        public static int flavor = 2000;
        public static int topping = 2000;
        public static bool outOfSomething = false;
        public static Random rand = new Random();

        public static AutoResetEvent areLucy = new AutoResetEvent(false);
        public static AutoResetEvent areBelt = new AutoResetEvent(false);

        public static object obj = new object();
        public static void Belt()
        {
            int count = 1;
            while (true)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                if (outOfSomething)
                {
                    Console.WriteLine("-----------------------------I'm STOPPED");
                    areBelt.WaitOne();
                }
                Console.WriteLine("Pie crust #{0}", count);
                areLucy.Set();
                watch.Stop();
                if ((50 - (int)watch.ElapsedMilliseconds) > 0)
                {
                    Thread.Sleep(50 - (int)watch.ElapsedMilliseconds);
                }
                count++;
                // areBelt.WaitOne();
            }
        }
        public static void LucyWorker()
        {
            RobotLucy lucy = new RobotLucy();
            while (true)
            {
                if (filling <= 250 || flavor <= 10 || topping <= 100)
                {
                    outOfSomething = true;
                    continue;
                }
                outOfSomething = false;
                areBelt.Set();
                areLucy.WaitOne();
                lock (obj)
                {
                    filling -= lucy.getFilling();
                    Console.WriteLine("filling = {0} gr ", filling);
                }
                lock (obj)
                {
                    flavor -= lucy.getFlavor();
                    Console.WriteLine("flavor = {0} gr ", flavor);
                }
                lock (obj)
                {
                    topping -= lucy.getTopping();
                    Console.WriteLine("topping = {0} gr ", topping);
                }
            }
        }
        public static void JoeWorker()
        {
            RobotJoe joe = new RobotJoe();

            while (true)
            {

                if (filling <= 1900)
                {
                    while (filling < 2000)
                    {
                        filling += joe.Fill();
                    }
                }
                if (flavor <= 1900)
                {
                    while (flavor < 2000)
                    {
                        flavor += joe.Fill();
                    }
                }
                if (topping <= 1900)
                {
                    while (topping < 2000)
                    {
                        topping += joe.Fill();
                    }
                }
                Thread.Sleep(rand.Next(0, 50));

            }
        }
        static void Main(string[] args)
        {
            Task BeltThread = Task.Factory.StartNew(Belt);
            Thread lucyThread = new Thread(LucyWorker);
            Thread joeThread = new Thread(JoeWorker);
            lucyThread.Start();
            joeThread.Start();
            Console.ReadLine();
        }
    }
}