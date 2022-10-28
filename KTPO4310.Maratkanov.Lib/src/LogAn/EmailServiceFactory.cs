using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4310.Maratkanov.Lib.src.LogAn
{
    public static class EmailServiceFactory
    {
        private static IEmailService customEmailService = null;

        public static IEmailService Create()
        {
            if (customEmailService != null)
            {
                return customEmailService;
            }

            throw new NotImplementedException();
        }

        public static void SetService(IEmailService srvc)
        {
            customEmailService = srvc;
        }
    }
}
