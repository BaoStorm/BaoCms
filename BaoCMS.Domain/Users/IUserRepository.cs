using BaoCMS.Domain.Users.Entities;
using BaoCMS.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaoCMS.Domain.Users
{
    public interface IUserRepository : IRepository<User>
    {
        User GetById(Guid id);
        User GetByEmail(string email);
        User GetByUserName(string userName);
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        Task AddToRoleAsync(Guid id, string roleName);
        Task RemoveFromRoleAsync(Guid id, string roleName);
    }
}
