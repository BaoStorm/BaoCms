using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BaoCMS.Domain.Users.Commands;
using BaoCMS.Domain.Users.Entities;
using BaoCMS.Framework.Commands;
using BaoCMS.Framework.Events;
using FluentValidation;

namespace BaoCMS.Domain.Users.Handlers
{
    public class CreateUserHandler : ICommandHandlerAsync<CreateUser>
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<CreateUser> _validator;

        public CreateUserHandler(IUserRepository userRepository, IValidator<CreateUser> validator)
        {
            _userRepository = userRepository;
            _validator = validator;
        }

        public async Task<IEnumerable<IEvent>> HandleAsync(CreateUser command)
        {
            var user = User.CreateNew(command, _validator);

            await _userRepository.CreateAsync(user);

            return user.Events;
        }
    }
}
