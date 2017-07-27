using System;
using BaoCMS.Domain.Users.Entities;
using BaoCMS.Framework.Domain;

namespace BaoCMS.Domain.Users.Rules
{
    public interface IUserRules : IRules<User>
    {
        bool IsUserNameUnique(string name, Guid userId = new Guid());
        bool IsUserEmailUnique(string email, Guid userId = new Guid());
    }
}
