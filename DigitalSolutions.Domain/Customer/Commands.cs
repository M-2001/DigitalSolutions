using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSolutions.Domain
{
    public class CreateCustomerEntryCommand : IMessage
    {
        public string name { get; set; }
        public string company { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string message { get; set; }
        public bool enabled { get; set; }
        public DateTime createDate { get; set; }
    }

    public class UpdateCustomerEntryCommand: CreateCustomerEntryCommand
    {
        public int ID { get; set; }
    }
}
