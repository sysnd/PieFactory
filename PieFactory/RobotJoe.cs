using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PieFactory
{
    public class RobotJoe
    {
        public int Fill()
        {
            Thread.Sleep(10);
            return 100;
        }

        //public int SetFilling()
        //{
        //    Thread.Sleep(25);
        //    return 250;
        //}

        //public int SetFlavor()
        //{
        //    Thread.Sleep(1);
        //    return 10;
        //}

        //public int SetTopping()
        //{
        //    Thread.Sleep(10);
        //    return 100;
        //}
    }
}
