using System;
using System.Collections.Generic;
using System.Text;

namespace BaoCMS.Reporting.Users
{
    public class LoginUserModel
    {
        public Guid Id { set; get; }
        public string UserName { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
    }
}
