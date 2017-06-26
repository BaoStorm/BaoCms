using System;
using System.Collections.Generic;
using System.Text;

namespace BaoCMS.Framework.Events
{
    public interface IEvent
    {
        DateTime TimeStamp { get; set; }
        Guid UserId { get; set; }
    }
}
