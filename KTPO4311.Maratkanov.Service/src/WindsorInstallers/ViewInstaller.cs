using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using KTPO4310.Maratkanov.Lib.src.LogAn;
using KTPO4310.Maratkanov.Lib.src.SampleCommands;
using KTPO4311.Maratkanov.Service.src.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4311.Maratkanov.Service.src.WindsorInstallers
{
    /// <summary>
    ///  класс для конфигурирования «представления»
    /// </summary>
    public class ViewInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IView>().ImplementedBy<ConsoleView>().LifeStyle.Transient);
        }
    }
}
