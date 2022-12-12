using KTPO4310.Maratkanov.Lib.src.LogAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4310.Maratkanov.Lib.src.SampleCommands
{
    public class FirstCommand : ISampleCommand
    {
        private readonly IView view;
        private int iExecute = 0;
        public FirstCommand(IView view)
        {
            this.view = view;
        }
        public void Execute()
        {
            iExecute++;
            view.Render(this.GetType().ToString() + "\niExecute = " + iExecute);
        }

    }
}
