using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSolutions.Services
{
    public sealed class GetCustomersListRequest
    {
        public string searchText { get; set; }

        public int start { get; set; }
        public int length { get; set; }
    }
}
