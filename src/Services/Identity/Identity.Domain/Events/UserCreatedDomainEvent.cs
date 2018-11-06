using Identity.Domain.AggregatesModel.UserAggregate;

using MediatR;

namespace Identity.Domain.Events
{
    /// <summary>
    /// 用户创建领域事件
    /// </summary>
    public class UserCreatedDomainEvent:INotification
    {
        public User User { get; }

        public UserCreatedDomainEvent(User user)
        {
            User = user;
        }
    }
}
