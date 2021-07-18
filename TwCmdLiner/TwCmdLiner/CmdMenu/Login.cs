using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwCmdLiner.CmdMenu
{
    class Login
    {
        string vNickname;
        string vPassword;
        public void AccessUser() {
            Mock.MockData mock = new Mock.MockData();
            // fill a defaults objects...
            mock.SetDefaultUsers();

            Console.WriteLine("type your nickname");
            vNickname = Console.ReadLine();

            Console.WriteLine("type your password");
            vPassword =  Console.ReadLine();

            User usrFind = mock.SetDefaultUsers()
                .Where(u => u.nickname == vNickname)
                .Where(u => u.password == vPassword)
                .FirstOrDefault();

            if (usrFind != null ) {
                Prompt prm = new Prompt();
                prm.ReceivedData(usrFind);
            } else {
                Console.WriteLine("not finded...");
            }
            Console.ReadKey();
        }
    }
}
