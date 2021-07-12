using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwCmdLiner.CmdMenu
{
    class Login
    {
        string nickname;
        string password;
        public void AccessUser() {
            Mock.MockData mock = new Mock.MockData();
            // fill a defaults objects...
            mock.SetDefaultUsers();

            Console.WriteLine("type your nickname");
            nickname = Console.ReadLine();

            Console.WriteLine("type your password");
            password = Console.ReadLine();

            Console.WriteLine(" your typing nick " + nickname + " your passs " + password);

            Console.ReadKey();
        }
    }
}
