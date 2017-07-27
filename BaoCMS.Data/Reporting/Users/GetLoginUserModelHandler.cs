using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BaoCMS.Framework.Queries;
using BaoCMS.Reporting.Users;
using BaoCMS.Reporting.Users.Queries;
using Microsoft.EntityFrameworkCore;

namespace BaoCMS.Data.Reporting.Users
{
    public class GetLoginUserModelHandler : IQueryHandlerAsync<GetLoginUserModel, LoginUserModel>
    {
        private readonly IContextFactory _contextFactory;
        private readonly IMapper _mapper;

        public GetLoginUserModelHandler(IContextFactory contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }
        public async Task<LoginUserModel> RetrieveAsync(GetLoginUserModel query)
        {
            using (var context = _contextFactory.Create())
            {
                var entity = await context.Users.FirstOrDefaultAsync(x => x.UserName == query.UserName && x.Password == query.Password);
                if (entity == null)
                    return null;
                
                var model = _mapper.Map<LoginUserModel>(entity);

                return model;
            }
        }
    }
}
