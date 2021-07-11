using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TwCmdLiner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello world.....");
            Mock.MockData mock = new Mock.MockData();
            // fill a defaults objects...
            mock.SetDefaultUsers();
            
            //build login functionality

            Console.ReadKey();
        }
    }
}
