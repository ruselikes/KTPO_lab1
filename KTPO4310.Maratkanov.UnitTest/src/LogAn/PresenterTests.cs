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
    public class PresenterTests
    {
        [Test]
        public void ctor_WhenAnalyzed_CallsViewRender()
        {
            IView mockView = Substitute.For<IView>();//создание подставки
            FakeLogAnalyzer stubLogAnalyzer = new FakeLogAnalyzer();//создание заглушки

            Presenter presenter = new(stubLogAnalyzer, mockView);
            stubLogAnalyzer.CallRaiseAnalyzedEvent();// вызов метода заглушки генерации события


            mockView.Received().Render("Обработка завершена");//Проверка, что для подставки IView вызван метод Render и его параметр содержит значение «Обработка завершена» 

        }
        [Test]
        public void ctor_WhenAnalyzed_CallsViewRender_NSubstitute()
        {

            IView mockView = Substitute.For<IView>();
            ILogAnalyzer stubLogAnalyzer = Substitute.For<ILogAnalyzer>();

            Presenter presenter = new(stubLogAnalyzer, mockView);
            stubLogAnalyzer.Analyzed += Raise.Event<LogAnalyzerAction>();


            mockView.Received().Render("Обработка завершена");
            
        }
    }

    
    class FakeLogAnalyzer : LogAnalyzer
    {
        public void CallRaiseAnalyzedEvent()
        {
            base.RaiseAnalyzedEvent();

        }

    }
}
