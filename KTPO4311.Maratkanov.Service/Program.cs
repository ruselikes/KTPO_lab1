using KTPO4310.Maratkanov.Lib.src.Common;
using KTPO4310.Maratkanov.Lib.src.LogAn;
using KTPO4310.Maratkanov.Lib.src.SampleCommands;
using KTPO4311.Maratkanov.Service.src.WindsorInstallers;

/*namespace KTPO4311.Maratkanov.Service
{
    public class Program
    {
        static void Main(string[] args)
        {*/
            CastleFactory.container.Install(
                new SampleCommandInstaller(), new ViewInstaller());


            for (int i = 0; i < 3; i++)

            {
                ISampleCommand someCommand = CastleFactory.container.Resolve<ISampleCommand>();
                someCommand.Execute();
            }

/*LogAnalyzer loger = new LogAnalyzer();

string rightfile = "rightfile.ext";
string falsefile = "falsefile.exe";

Console.WriteLine("Проверка на валидность у " + rightfile + ": " + loger.IsValidLogFileName(rightfile));
Console.WriteLine("Проверка на валидность у " + falsefile + ": " + loger.IsValidLogFileName(falsefile));
}

}
}*/