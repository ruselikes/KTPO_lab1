using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KTPO4310.Maratkanov.Lib.src.LogAn
{
    ///<summary>Анализатор лог.файлов</summary>
    public class LogAnalyzer
    {
        /// <summary> Проверка правильности имени к файлу</summary>
        /// 
        public IExtensionManager mrg;
        public IWebService srvc;
        public LogAnalyzer()
        {
            mrg = ExtensionManagerFactory.Create();
            srvc = WebServiceFactory.Create();

            IEmailService  ems = new EmailService()
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                try
                {
                    //передать внешней службе сообщение об ошибке
                    srvc = WebServiceFactory.Create();
                    srvc.LogError("Имя файла слишком короткое: " + fileName);
                }

                catch (Exception e)
                {
                    //отправить сообщение по эл. почте
                    //email.SendEmail("somewhere@mail.com", "Невозможно вызвать веб-сервис", e.Message);
                }
        }
            email = EmailServiceFactory.Create();
            email.SendEmail("somewhere@mail.com", "Unable to call webservice", e.Message);

            public bool IsValidLogFileName(string fileName)
        {
            try
            {
                IExtensionManager IExtMan = ExtensionManagerFactory.Create();
                return IExtMan.IsValid(fileName);

            }
           catch(Exception)
            {
                return false;
            }

            /* WasLastFileNameValid = false;
             if (string.IsNullOrEmpty(fileName))
             {
                 throw new ArgumentException("имя файла должно быть задано");
             }
             if (!fileName.EndsWith(".MARATKANOVRD", StringComparison.CurrentCultureIgnoreCase))
             {
                 return false;
        }


             return true;*/


    }


    }
}
