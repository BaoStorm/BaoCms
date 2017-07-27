using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BaoCMS.Domain.Users;
using BaoCMS.Domain.Users.Entities;
using UserDbEntity = BaoCMS.Data.Entities.User;

namespace BaoCMS.Data.Domain
{
    public class UserRepository : IUserRepository
    {
        private readonly IContextFactory _dbContextFactory;
        private readonly IMapper _mapper;
        public User GetById(Guid id)
        {
            using (var context = _dbContextFactory.Create())
            {
                var dbEntity = context.Users
                    .FirstOrDefault(x => x.Id == id && x.IsDelete==false);

                return dbEntity != null ? _mapper.Map<User>(dbEntity) : null;
            }
        }

        public User GetByEmail(string email)
        {
            using (var context = _dbContextFactory.Create())
            {
                var dbEntity = context.Users
                    .FirstOrDefault(x => x.Email == email && x.IsDelete == false);

                return dbEntity != null ? _mapper.Map<User>(dbEntity) : null;
            }
        }

        public User GetByUserName(string userName)
        {
            using (var context = _dbContextFactory.Create())
            {
                var dbEntity = context.Users
                    .FirstOrDefault(x => x.UserName == userName && x.IsDelete == false);

                return dbEntity != null ? _mapper.Map<User>(dbEntity) : null;
            }
        }

        public Task CreateAsync(User user)
        {
            using (var context = _dbContextFactory.Create())
            {
                var dbEntity = _mapper.Map<UserDbEntity>(user);
                context.Add(dbEntity);
                return context.SaveChangesAsync();
            }
        }

        public Task UpdateAsync(User user)
        {
            using (var context = _dbContextFactory.Create())
            {
                var dbEntity = _mapper.Map<UserDbEntity>(user);
                context.Update(dbEntity);
                return context.SaveChangesAsync();
            }
        }

        public Task AddToRoleAsync(Guid id, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(Guid id, string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
