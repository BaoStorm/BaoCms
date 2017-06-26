using BaoCMS.Framework.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoCMS.Framework.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        IEnumerable<IEvent> Handle(TCommand command);
    }
}
