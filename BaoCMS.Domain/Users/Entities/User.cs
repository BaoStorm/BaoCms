using BaoCMS.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using BaoCMS.Domain.Users.Commands;
using BaoCMS.Domain.Users.Events;
using FluentValidation;

namespace BaoCMS.Domain.Users.Entities
{
    public class User : AggregateRoot
    {
        public string UserName { set; get; }
        public string Password { set; get; }
        public string Email { set; get; }
        public bool EmailConfirmed { set; get; }
        public string PhoneNumber { set; get; }
        public bool PhoneNumberConfirmed { set; get; }
        public User() { }

        private User(CreateUser cmd) : base(cmd.Id)
        {
            Email = cmd.Email;
            UserName = cmd.UserName;
            Password = cmd.Password;
            PhoneNumber = cmd.PhoneNumber;

            AddEvent(new UserCreated
            {
                AggregateRootId = Id,
                Email = Email,
                UserName = UserName,
                PhoneNumber = PhoneNumber
            });
        }

        public static User CreateNew(CreateUser cmd, IValidator<CreateUser> validator)
        {
            validator.ValidateCommand(cmd);

            return new User(cmd);
        }
    }
}
