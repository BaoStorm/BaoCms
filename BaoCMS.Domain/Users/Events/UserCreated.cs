using System;
using System.Collections.Generic;
using System.Text;
using BaoCMS.Framework.Domain;

namespace BaoCMS.Domain.Users.Events
{
    public class UserCreated : DomainEvent
    {
        public string UserName { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string PhoneNumber { set; get; }
    }
}
