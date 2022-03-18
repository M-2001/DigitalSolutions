using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyPage.WebPortal
{
    public sealed class BlogController : Controller
    {
        [HttpGet]
        [ChildActionOnly]
        [Route("blog/thumbnail")]
        public ActionResult BlogThumbnail()
        {
            return View("BlogThumbnail");
        }
    }
}