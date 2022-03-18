using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

using MyPage.Services;

namespace MyPage.WebPortal
{
    /// <summary>
    /// Our main Blog WebAPI controller
    /// </summary>
    public sealed class BlogApiController : ApiController
    {
        private readonly IBlogQueryService _queryService;


        /// <summary>
        /// Constructor from IOC
        /// </summary>
        public BlogApiController(IBlogQueryService queryService)
        {
            _queryService = queryService;
        }


        /// <summary>
        /// Return list of blog entries
        /// </summary>
        [HttpGet]
        [Route("api/blog")]
        public async Task<IHttpActionResult> GetBlogEntries([FromUri]GetBlogEntryListRequest request)
        {
            return Ok(await _queryService.GetBlogEntries(request));
        }

        /// <summary>
        /// Return list of blog entries
        /// </summary>
        [HttpPost]
        [Route("api/blog")]
        public async Task<IHttpActionResult> CreateBlogEntry(BlogEntryDTO blogEntry)
        {
            return Ok();
        }

    }
}
