using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwCmdLiner
{
    class User
    {
        private string _nickname;
        private string _password;

        public User(string vNickname, string vPassword) {
            _nickname = vNickname;
            _password = vPassword;
        }

        public string GetNickname() {
            return _nickname;
        }

        public void SetNickname(string vNickName) {
            _nickname = vNickName;
        }

        public string GetPassword() {
            return _password;
        }

        public void SetPassword(string vPassword) {
            _password = vPassword;
        }
    }
}
