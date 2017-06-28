using System;
using System.Collections.Generic;
using System.Text;

namespace BaoCMS.Framework.Domain
{
    public interface IRepository<T> where T : IAggregateRoot
    {

    }
}
