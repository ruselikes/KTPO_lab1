using KTPO4310.Maratkanov.Lib.src.LogAn;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KTPO4310.Maratkanov.Lib;

namespace KTPO4310.Maratkanov.UnitTest.src.LogAn
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidLogFileName_BadExtension_ReturnsFalse()
        {
            //Подготовка теста
            LogAnalyzer analyzer = new LogAnalyzer();
            //Воздействие на тестируемый объект
            bool result = analyzer.IsValidLogFileName("file.maratkanovrd6");
            //Проверка ожидаемого результата
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidLogFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            //Воздействие на тестируемый объект
            bool result = analyzer.IsValidLogFileName("file.maratkanovrd");
            //Проверка ожидаемого результата
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidLogFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            //Воздействие на тестируемый объект
            bool result = analyzer.IsValidLogFileName("file.MARATKANOVRD");
            //Проверка ожидаемого результата
            Assert.IsTrue(result);
        }
        [TestCase("file.MARATKANOVRD")]
        [TestCase("file.maratkanovrd")]
        public void IsValidLogFileName_ValidExtension_ReturnsTrue(string file)
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            //Воздействие на тестируемый объект
            bool result = analyzer.IsValidLogFileName(file);
            //Проверка ожидаемого результата
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidFileName_EmptyName_Throws()
        {
            //Подготовка теста
            LogAnalyzer analyzer = new LogAnalyzer();
            //Ункция перехватывает и возвращает исключение
            var ex = Assert.Catch<Exception>(() => analyzer.IsValidLogFileName(""));

            StringAssert.Contains("имя файла должно быть задано", ex.Message);

        }

        [TestCase("badfile.foo",false)]
        [TestCase("goodfile.maratkanovrd",true)]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(string file,bool expected)
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            analyzer.WasLastFileNameValid = !expected;

            analyzer.IsValidLogFileName(file);

            Assert.AreEqual(expected,analyzer.WasLastFileNameValid);
        }
    }
}
