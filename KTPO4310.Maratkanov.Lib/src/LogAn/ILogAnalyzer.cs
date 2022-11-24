namespace KTPO4310.Maratkanov.Lib.src.LogAn
{
    public interface ILogAnalyzer
    {
        event LogAnalyzerAction Analyzed;

        void Analyze(string fileName);
        bool IsValidLogFileName(string fileName);
    }
}