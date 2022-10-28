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
  
      
    
      
        public LogAnalyzer()
        {
            
        }
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
