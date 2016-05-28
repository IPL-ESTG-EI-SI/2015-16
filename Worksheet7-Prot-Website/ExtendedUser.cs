using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.AuthService;

namespace Website
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
            return this.Name + "<br>" + this.Description;
        }
    }
}