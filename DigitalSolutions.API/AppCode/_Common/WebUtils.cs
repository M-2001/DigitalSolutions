using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalSolutions
{
    public static class WebUtils
    {
        public static string ClientDateFilter
        {
            get
            {
                return "date:'" + System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern + "'";
            }
        }

    }
}