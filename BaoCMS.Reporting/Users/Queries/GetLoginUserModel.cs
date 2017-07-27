using BaoCMS.Framework.Queries;

namespace BaoCMS.Reporting.Users.Queries
{
    public class GetLoginUserModel:IQuery
    {
        public string UserName { set; get; }
        public string Password { set; get; }
    }
}
