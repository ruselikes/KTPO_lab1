using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4310.Maratkanov.Lib.src.LogAn
{
    public static class WebServiceFactory
    {
        private static IWebService customService = null;
        public static IWebService Create()
        {
            if (customService != null)
            {
                return customService;
            }
            return new WebService();
        }
        public static void SetService(IWebService srvс)
        {
            customService = srvс;
        }
    }
}
