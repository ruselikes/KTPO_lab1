using KTPO4310.Maratkanov.Lib.src.LogAn;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4310.Maratkanov.UnitTest.src.LogAn
{
    internal class LogAnalyzerNSubstituteTests
    {
        public void AfterEachTest()
        {
            ExtensionManagerFactory.SetManager(null);
        }
        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();
            //Настроить объект, чтобы метод возвращал true для заданного значения входного параметра
            fakeExtensionManager.IsValid("validfile.ext").Returns(true);

            ExtensionManagerFactory.SetManager(fakeExtensionManager);

            LogAnalyzer log = new LogAnalyzer();


            bool result = log.IsValidLogFileName("validfile.ext");
            Assert.True(result);
        }

        [Test]
        public void IsValidFileName_NoneSupportedExtension_ReturnsFalse()
        {
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();
            fakeExtensionManager.IsValid("validfile.ext").Returns(true);
            ExtensionManagerFactory.SetManager(fakeExtensionManager);
            LogAnalyzer log = new LogAnalyzer();
            bool result = log.IsValidLogFileName("invalid.ex1");
            Assert.IsFalse(result);
        }
        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();
            fakeExtensionManager.When(x => x.IsValid(Arg.Any<string>()))
                .Do(context => { throw new Exception("fake exception"); });
            ExtensionManagerFactory.SetManager(fakeExtensionManager);
            LogAnalyzer log = new LogAnalyzer();
            Assert.IsFalse(log.IsValidLogFileName("anything"));

        }

        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            IWebService mockWebService = Substitute.For<IWebService>();

            WebServiceFactory.SetService(mockWebService);

            LogAnalyzer log = new LogAnalyzer();

            string tooShortFilename = "abc.ext";

            log.Analyze(tooShortFilename);

            mockWebService.Received().LogError("Имя файла слишком короткое: abc.ext");//ождиаемое

        }
        [Test]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            IWebService mockWebService = Substitute.For<IWebService>();

            WebServiceFactory.SetService(mockWebService);

            mockWebService.When(x => x.LogError(Arg.Any<string>()))
                .Do(context => { throw new Exception("это подделка"); });
            IEmailService mockEmail = Substitute.For<IEmailService>();
            EmailServiceFactory.SetService(mockEmail);

            LogAnalyzer log = new LogAnalyzer();

            string tooShortFilename = "abc.ext";

            log.Analyze(tooShortFilename);

            mockEmail.Received().SendEmail("somewhere@mail.com", "Невозможно вызвать веб-сервис","это подделка");//ождиаемое
        }

    }
}
