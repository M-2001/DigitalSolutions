using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSolutions
{
    public interface IServiceBus
    {
        Task SendCommandAsync<T>(T command) where T : IMessage;
        Task RaiseEventAsync<T>(T theEvent) where T : IEvent;
    }

}
