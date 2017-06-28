using AutoMapper;
using BaoCMS.Domain.Users.Entities;
using UserDbEntity = BaoCMS.Data.Entities.User;

namespace BaoCMS.Data.Domain
{
    public class DomainAutoMapperProfile : Profile
    {
        public DomainAutoMapperProfile()
        {
            
            CreateMap<User, UserDbEntity>();
            CreateMap<UserDbEntity, User>().ConstructUsing(x => new User());
        }
    }
}
