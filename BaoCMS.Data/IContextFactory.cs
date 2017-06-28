using System;
using System.Collections.Generic;
using System.Text;

namespace BaoCMS.Data
{
    public interface IContextFactory
    {
        DbContext Create();
    }
}
