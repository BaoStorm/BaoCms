using System;
using System.Collections.Generic;
using System.Text;

namespace BaoCMS.Framework.Resolver
{
    public interface IResolver
    {
        T Resolve<T>();
        IEnumerable<T> ResolveAll<T>();
    }
}
