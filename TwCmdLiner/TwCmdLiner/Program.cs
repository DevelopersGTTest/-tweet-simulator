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
            mock.GetUsers();
            mock.showDataMock();
            Console.ReadKey();
        }
    }
}
