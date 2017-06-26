using System;
using System.Collections.Generic;
using System.Text;

namespace BaoCMS.Framework.Domain
{
    public interface IRules<T> where T : IAggregateRoot
    {
    }
}
