using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AuthService
{
    [DataContract]
    public class User
    {        
        public int Id { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Name { get; set; }
        public string Password { get; set; }
        [DataMember]
        public string Description { get; set; }

    }
}