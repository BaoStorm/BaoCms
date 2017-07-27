using System;
using System.Collections.Generic;
using System.Text;

namespace BaoCMS.Data.Entities.Base
{
    public class EntitiesBase
    {
        public Guid Id { set; get; }
        public Guid CreateUserId { set; get; }
        public DateTime CreateDateTime { set; get; }
        public Guid UpdateUserId { set; get; }
        public DateTime UpdateDateTime { set; get; }
        public bool IsDelete { set; get; }
    }
}
