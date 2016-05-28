using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsClient.AuthService;

namespace WindowsClient
{
    class ExtendedUser : User
    {
        public ExtendedUser(User user)
        {
            this.Description = user.Description;
            this.Login = user.Login;
            this.Name = user.Name;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
