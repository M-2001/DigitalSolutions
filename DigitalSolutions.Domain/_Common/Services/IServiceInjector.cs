using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSolutions
{
    public interface IServiceInjector
    {
        object Get(Type type);
        List<Type> GetTypes();
        void Bind<Intf, Impl>() where Impl : Intf;
        void BindConst<Intf, Impl>(Impl impl) where Impl : Intf;
    }


}
