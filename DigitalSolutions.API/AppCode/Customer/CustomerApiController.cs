using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

using DigitalSolutions.Services;

namespace DigitalSolutions
{
    /// <summary>
    /// Our main Blog WebAPI controller
    /// </summary>
    public sealed class CustomerApiController : ApiController
    {
        private readonly ICustomerQueryService _queryService;
        private readonly IServiceBus _serviceBus;


        /// <summary>
        /// Constructor from IOC
        /// </summary>
        public CustomerApiController(ICustomerQueryService queryService, IServiceBus serviceBus)
        {
            _queryService = queryService;
            _serviceBus = serviceBus;
        }


        /// <summary>
        /// Return list of blog entries
        /// </summary>
        [HttpGet]
        [Route("api/customer")]
        public async Task<IHttpActionResult> GetCustomerEntries([FromUri]GetCustomersListRequest request)
        {
            return Ok(await _queryService.GetCustomersEntries(request));
        }

        [HttpGet]
        [Route("api/customer/{customerID:int}")]
        public async Task<IHttpActionResult>GetCustomerByID([FromUri] int customerID)
        {
            var customer = await _queryService.GetCustomerByID(customerID);
            if (customer != null)
                return Ok(customer);
            else
                return NotFound();
        }


        /// <summary>
        /// Return list of blog entries
        /// </summary>
        [HttpPost]
        [Route("api/customer")]
        public async Task<IHttpActionResult> CreateCustomerEntry([FromBody]CustomerEntryDTO customerEntry)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           
            await _serviceBus.SendCommandAsync(customerEntry.ToCreateCmd());
            
            return Ok("Customer Created");
        }

    }
}
