using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4310.Maratkanov.Lib.src.LogAn
{
    public static class ExtensionManagerFactory

    {
        private static IExtensionManager customManager = null;
        public static IExtensionManager Create()
        {
            if (customManager != null)
            {
                return customManager;
            }
            return new FileExtensionManager();
        }
        public static void SetManager(IExtensionManager mgr)
        {
            customManager = mgr;
        }

    }
}
