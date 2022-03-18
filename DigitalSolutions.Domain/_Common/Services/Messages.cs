using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSolutions
{
    public interface IMessage { }
    public interface IEvent { }


    public interface ICanHandleMessage<T> where T : IMessage
    {
        Task HandleAsync(T command);
    }

    public interface ICanHandleEvent<T> where T : IEvent
    {
        Task HandleAsync(T theEvent);
    }


}
