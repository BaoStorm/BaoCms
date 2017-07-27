using System;
using System.Collections.Generic;
using System.Text;
using BaoCMS.Framework.Commands;

namespace BaoCMS.Domain.Users.Commands
{
    public class CreateUser : ICommand
    {
        public Guid Id { set; get; }
        public string UserName { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string PhoneNumber { set; get; }
    }
}
