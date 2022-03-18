using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSolutions.Domain
{
    public class CustomerEntry : Aggregate
    {
        public string name { get; protected  set; }
        public string company { get; protected set; }
        public string email { get; protected set; }
        public string phoneNumber{ get; protected set; }
        public string message { get; protected set; }
        public bool enabled { get; protected set; }
        public DateTime createDate { get; protected set; }

        /// <summary>
        /// Constructor for a new customer
        /// </summary>
        protected CustomerEntry() { }

        public CustomerEntry(string name, string company, string email, string phoneNumber, string message)
        {
            this.SetName(name);
            this.SetCompany(company);
            this.SetEmail(email);
            this.SetPhoneNumber(phoneNumber);
            this.SetMessage(message);

            this.enabled = true;
            this.createDate = DateTime.Now;

        }

        public void SetName(string name) 
        {
            Validate.NotNullEmpty(name, "Name is required");
            this.name = name;
        }

        public void SetCompany(string company)
        {
            Validate.NotNullEmpty(company, "Company is required");
            this.company = company;
        }

        public void SetEmail(string email)
        {
            Validate.NotNullEmpty(email, "Email is required");
            this.email = email;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            Validate.NotNullEmpty(phoneNumber, "Phone number is required");
            this.phoneNumber = phoneNumber;
        }

        public void SetMessage(string message)
        {
            Validate.NotNullEmpty(message, "Message number is required");
            this.message = message;
        }
    }
}
