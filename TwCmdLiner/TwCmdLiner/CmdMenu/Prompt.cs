using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwCmdLiner.CmdMenu
{
    class Prompt
    {
        public void ReceivedData(User user) {
            Console.WriteLine("hello there..." + user.nickname );
            Console.WriteLine("Select your operation");
            Console.WriteLine("1. Users");
            Console.WriteLine("1. Tweets");
        }

    }
}
