using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalSolutions.Domain;

namespace DigitalSolutions.Services
{
    public static partial class QueryServiceExtensions
    {
        public static IQueryable<CustomerEntryDTO> SelectCustomerDTO(this IQueryable<CustomerEntry> query)
        {
            return query.Select(b => new CustomerEntryDTO()
            {

                ID = b.ID,
                name = b.name,

                company = b.company,
                email = b.email,

                phoneNumber = b.phoneNumber,
                message = b.message,
                enabled = b.enabled,
                createDate = b.createDate
            });
        }
    }
}
