using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json;


namespace Digital.Solutions
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Web API routes
            config.MapHttpAttributeRoutes();

            //Configure json formatter
            config.Formatters.Add(new BrowserJsonFormatter());
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }
    }


    /// <summary>
    /// Json formatter for displaying friendly json string thru browser requests
    /// </summary>
    public sealed class BrowserJsonFormatter : JsonMediaTypeFormatter
    {
        public BrowserJsonFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            base.SerializerSettings.Formatting = Formatting.Indented;
            base.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }

        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
    }

}
