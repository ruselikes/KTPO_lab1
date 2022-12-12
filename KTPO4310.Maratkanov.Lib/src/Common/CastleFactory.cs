using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4310.Maratkanov.Lib.src.Common
{
    public static class CastleFactory
    {
        ///Контейнер///
        public static IWindsorContainer container { get; private set; }

        static CastleFactory()
        {
            //создание обьект контейнер
            container = new WindsorContainer();
        }
    }
}
