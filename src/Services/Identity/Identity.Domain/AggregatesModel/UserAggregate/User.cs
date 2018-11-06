using Identity.Domain.Events;
using Identity.Domain.SeedWork;

namespace Identity.Domain.AggregatesModel.UserAggregate
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User : Entity, IAggregateRoot
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { private set; get; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { private set; get; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { private set; get; }
        /// <summary>
        /// 角色类型
        /// </summary>
        public RoleType RoleType { private set; get; }

        private int _roleTypeId;

        protected User()
        {
        }

        public User(string name, string password, string email, RoleType roleType)
        {
            Name = name;
            Password = password;
            RoleType = roleType;
            _roleTypeId = roleType.Id;
            Email = email;

            AddUserCreatedDomainEvent();
        }

        private void AddUserCreatedDomainEvent()
        {
            var userCreateDomainEvent = new UserCreatedDomainEvent(this);

            AddDomainEvent(userCreateDomainEvent);
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public void SetRoleType(RoleType roleType)
        {
            RoleType = roleType;
        }
    }
}
