using KTPO4310.Maratkanov.Lib.src.LogAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4310.Maratkanov.Lib.src.SampleCommands
{
    public class SecondCommand : ISampleCommand
    {
        private readonly IView view;
        private int iExecute = 0;
        private Exception _exception = null;
        public SecondCommand(IView view)
        {
            this.view = view;

        }
        public void Execute()
        {
            if (_exception == null) { _exception = new Exception();throw _exception; }
            iExecute++;
            view.Render(this.GetType().ToString() + "\niExecute = " + iExecute);
        }
    }
}
