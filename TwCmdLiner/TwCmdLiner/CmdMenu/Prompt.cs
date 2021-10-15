using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("1. Users");
            Console.WriteLine("2. Tweets");

            opt = Int16.Parse(Console.ReadLine());

            if (Enum.IsDefined(typeof(Types), opt)) {
                showMenuBySelection(opt);
            } else {
                Console.WriteLine("Action not finded....");
            }
        }

        public void showMenuBySelection(int selection) {
            if (selection == (int) Types.USERS) {
                Console.WriteLine("you have selected user");
            } else {
                Console.WriteLine("you have selected tweet");
            }
        }

    }
}
