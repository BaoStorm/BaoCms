using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BaoCMS.Framework.Queries;
using BaoCMS.Reporting.Users;
using BaoCMS.Reporting.Users.Queries;

namespace BaoCMS.Data.Reporting.Users
{
    public class QueryUserModelHandler: IQueryHandlerAsync<QueryUserModel,UserModel>
    {
        public Task<UserModel> RetrieveAsync(QueryUserModel query)
        {
            throw new NotImplementedException();
        }
    }
}
