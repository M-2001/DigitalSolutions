using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DigitalSolutions.Domain;

namespace DigitalSolutions.Services
{
    public sealed class CustomerEntryDTO
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string message { get; set; }
        public bool enabled { get; set; }
        public DateTime createDate { get; set; }

        public CreateCustomerEntryCommand ToCreateCmd()
        {
            CreateCustomerEntryCommand cmd = new CreateCustomerEntryCommand();
            ApplyCommonBinding(cmd);
            return cmd;
        }

        private void ApplyCommonBinding(CreateCustomerEntryCommand cmd)
        {
            cmd.name = name;
            cmd.company = company;
            cmd.email = email;
            cmd.phoneNumber = phoneNumber;
            cmd.message = message;
            cmd.enabled = enabled;
            cmd.createDate = createDate;
        }
    }
}
