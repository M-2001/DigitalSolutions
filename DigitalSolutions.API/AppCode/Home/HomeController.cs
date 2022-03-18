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
    public sealed class HomeApiController : ApiController
    {
        private readonly ICustomerQueryService _queryService;
        private readonly IServiceBus _serviceBus;


        /// <summary>
        /// Constructor from IOC
        /// </summary>
        public HomeApiController(ICustomerQueryService queryService)
        {
            _queryService = queryService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetCustomer([FromUri]GetCustomersListRequest request)
        {
            return Ok(await _queryService.GetCustomersEntries(request));
        }


    }
}
