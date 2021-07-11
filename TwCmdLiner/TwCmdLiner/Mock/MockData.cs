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
        public List<User> parts = new List<User>();

        public List<User> GetUsers() {
            parts.Add(new User() { nickname = "hackobo", password = "hck" });
            parts.Add(new User() { nickname = "sam", password = "123" });
            return parts;
        }

    }
}
