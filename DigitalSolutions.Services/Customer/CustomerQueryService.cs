using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using DigitalSolutions.Domain;

namespace DigitalSolutions.Services
{
    public interface ICustomerQueryService
    {
        Task<List<CustomerEntryDTO>> GetCustomersEntries(GetCustomersListRequest request);
        Task<CustomerEntryDTO> GetCustomerByID(int customerID);
    }
    public sealed class CustomerQueryService : ICustomerQueryService
    {
        private readonly IDbContext _context;

        public CustomerQueryService(IDbContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerEntryDTO>> GetCustomersEntries(GetCustomersListRequest request)
        {
            IQueryable<CustomerEntry> query = _context.CustomerEntries().OrderByDescending(c => c.ID);

            if (request != null)
            {
                if (!string.IsNullOrEmpty(request.searchText))
                {
                    query = query.Where(b => b.company.Contains(request.searchText) || b.name.Contains(request.searchText));
                }
                if (request.start > 0)
                    query = query.Skip(request.start);

                if (request.length > 0 )
                    query = query.Take(request.length);
                
            }
            return await query.SelectCustomerDTO().ToListAsync();
        }

        public async Task<CustomerEntryDTO>GetCustomerByID(int customerID)
        {
            return await _context.CustomerEntries().HavingID(customerID).SelectCustomerDTO().FirstOrDefaultAsync();
        }
    }
}
