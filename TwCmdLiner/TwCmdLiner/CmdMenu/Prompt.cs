using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwCmdLiner.Enums;

namespace TwCmdLiner.CmdMenu
{
    class Prompt
    {
        int opt = 0;

        enum Types {
            USERS = 1,
            TWEET = 2
        }

        public void ReceivedData(User user) {
            Console.WriteLine("hello there..." + user.nickname );
            Console.WriteLine("Select your operation");
            Console.WriteLine("2. Users");
            Console.WriteLine("3. Tweets");

            opt = Int16.Parse(Console.ReadLine());

            if (Enum.IsDefined(typeof(Types), opt)) {
                Console.WriteLine("IS VALID.....");
            } else {
                Console.WriteLine("not finded");
            }

            Console.WriteLine("OPT SELECTED IS " + opt);
        }

    }
}
