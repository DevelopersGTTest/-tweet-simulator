using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace TwCmdLiner.Mock
{
    class MockData
    {
        List<User> users = new List<User>();

        public List<User> SetDefaultUsers() {
            users.Add(new User() { nickname = "hackobo", password = "hck" });
            users.Add(new User() { nickname = "sam", password = "123" });
            return users;
        }

        public void showDataMock() {
            foreach (User u in users) {
                Console.WriteLine("nick =" + u.nickname);
                Console.WriteLine("pass =" + u.password);
            }
        }

    }
}
