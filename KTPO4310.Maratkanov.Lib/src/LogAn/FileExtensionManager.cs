using System.Configuration;
namespace KTPO4310.Maratkanov.Lib.src.LogAn
{/// <summary>
 /// Менеджер расширений файлов
 /// </summary>
    public class FileExtensionManager : IExtensionManager
    {

        public bool IsValid(string filename)
        {
            string[] extensions = ConfigurationManager.AppSettings["AccaptableExtensions"].Split(" ");
            string extstr = Path.GetExtension(filename);

            if (extensions == null)
            {
                Console.WriteLine("Ваш файл не имеет соответствующего значения конфигурации!");
                throw new NotImplementedException();
            }

            return Array.IndexOf(extensions, extstr) != -1;

        }
    }
}