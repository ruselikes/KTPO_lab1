using KTPO4310.Maratkanov.Lib.src.LogAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4311.Maratkanov.Service.src.Views
{
    class ConsoleView : IView
    {
        public void Render(string text)
        {
            Console.WriteLine(text); 
        }
    }
}
