using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSolutions.Domain
{
    public interface ICustomerCommandService : ICanHandleMessage<CreateCustomerEntryCommand>
    {

    }
    public sealed class CustomerCommandService : ICustomerCommandService
    {
        private readonly IDbContext _context;

        public CustomerCommandService(IDbContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(CreateCustomerEntryCommand cmd)
        {
            CustomerEntry customer = new CustomerEntry(cmd.name,
                cmd.company, cmd.email, cmd.phoneNumber, cmd.message);
            _context.Add(customer);

            await _context.SaveChangesAsync();
        }
    }
}

