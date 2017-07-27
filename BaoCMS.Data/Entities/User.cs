using BaoCMS.Data.Entities.Base;

namespace BaoCMS.Data.Entities
{
    public class User : EntitiesBase
    {
        public string UserName { set; get; }
        public string Password { set; get; }
        public string Email { set; get; }
        public bool EmailConfirmed { set; get; }
        public string PhoneNumber { set; get; }
        public bool PhoneNumberConfirmed { set; get; }

    }
}
