using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKSixDegreesOfSeparation;
using VKSixDegreesOfSeparationTests;

namespace ConsoleApplicationTest
{
    public class Program
    {


        static void Main(string[] args)
        {
            MainFormAdapter ad = new MainFormAdapter();
            ad._fetchUserInfo();
        }
    }
}
