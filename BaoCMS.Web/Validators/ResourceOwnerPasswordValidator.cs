using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaoCMS.Data.Entities;
using BaoCMS.Framework.Queries;
using BaoCMS.Reporting.Users;
using BaoCMS.Reporting.Users.Queries;
using IdentityModel;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;

namespace BaoCMS.Web.Validators
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public ResourceOwnerPasswordValidator(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var query = new GetLoginUserModel
            {
                UserName=context.UserName,
                Password=context.Password
            };
            var result = await _queryDispatcher.DispatchAsync<GetLoginUserModel, LoginUserModel>(query);
            if (result != null)
            {
                context.Result = new GrantValidationResult(result.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
            }
        }
    }
}
