using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PieFactory
{
    public class RobotLucy
    {        public int getFilling()
        {
            Console.WriteLine("The pie has filling");
            Thread.Sleep(10);
            return 250;
        }

        public int getFlavor()
        {
            Console.WriteLine("The pie has flavor");
            Thread.Sleep(10);
            return 10;
        }

        public int getTopping()
        {
            Console.WriteLine("The pie has topping");
            Thread.Sleep(10);
            return 100;
        }
    }
}
