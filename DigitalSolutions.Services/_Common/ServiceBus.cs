using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DigitalSolutions.Services
{
    /// <summary>
    /// Service bus is reponsible on directing messages and events to the correct target
    /// </summary>
    public sealed class ServiceBus : IServiceBus
    {
        private readonly IServiceInjector _Injector;
        public ServiceBus(IServiceInjector injector)
        {
            _Injector = injector;
        }


        /// <summary>
        /// Get list of assignable services from injector
        /// </summary>
        private List<T> GetAssignableServices<T>() where T : class
        {
            Type lookType = typeof(T);
            List<T> lst = new List<T>();
            foreach (Type type in _Injector.GetTypes())
            {
                if (lookType.IsAssignableFrom(type))
                {
                    lst.Add(_Injector.Get(type) as T);
                }
            }

            return lst;
        }



        /// <summary>
        /// Send command
        /// </summary>
        public async Task SendCommandAsync<T>(T command) where T : IMessage
        {
            List<ICanHandleMessage<T>> services = GetAssignableServices<ICanHandleMessage<T>>();
            if (services.Count == 0)
            {
                throw new InvalidOperationException(string.Format(
                    "No services found to handle message {0} ", typeof(T).FullName));
            }

            foreach (ICanHandleMessage<T> svc in services)
            {
                await svc.HandleAsync(command);
            }
        }


        /// <summary>
        /// Raise an event
        /// </summary>
        public async Task RaiseEventAsync<T>(T theEvent) where T : IEvent
        {
            List<ICanHandleEvent<T>> services = GetAssignableServices<ICanHandleEvent<T>>();
            foreach (ICanHandleEvent<T> svc in services)
            {
                await svc.HandleAsync(theEvent);
            }
        }


    }
}
