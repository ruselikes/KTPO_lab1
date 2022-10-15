using KTPO4310.Maratkanov.Lib.src.LogAn;


LogAnalyzer loger = new LogAnalyzer();

string rightfile = "rightfile.ext";
string falsefile = "falsefile.exe";

Console.WriteLine("Проверка на валидность у " + rightfile + ": " + loger.IsValidLogFileName(rightfile));
Console.WriteLine("Проверка на валидность у " + falsefile + ": " + loger.IsValidLogFileName(falsefile));