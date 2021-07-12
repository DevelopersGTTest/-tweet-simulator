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
            CmdMenu.Login login = new CmdMenu.Login();
            login.AccessUser();
        }
    }
}
