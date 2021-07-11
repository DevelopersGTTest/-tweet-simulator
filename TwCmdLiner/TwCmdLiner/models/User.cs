using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwCmdLiner
{
    class User : IEquatable<User>
    {
        public string nickname { get; set; }
        public string password { get; set; }

        public bool Equals(User other)
        {
            throw new NotImplementedException();
        }
    }
}
