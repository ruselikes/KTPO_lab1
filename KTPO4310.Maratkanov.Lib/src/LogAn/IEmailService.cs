namespace KTPO4310.Maratkanov.Lib.src.LogAn
{
    public interface IEmailService
    {
        void SendEmail(string to, string subject, string body);
    }
}