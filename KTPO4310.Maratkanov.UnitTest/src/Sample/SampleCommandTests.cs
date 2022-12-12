using KTPO4310.Maratkanov.Lib.src.LogAn;
using KTPO4310.Maratkanov.Lib.src.SampleCommands;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4310.Maratkanov.UnitTest.src.Sample
{
    [TestFixture]

    public class SampleCommandTests
    {
        [Test]
        public void IsFirstCommand_ReturnsCorrectText()
        {
            //Подготовка теста
            IView mockView = Substitute.For<IView>();
            FirstCommand firstCommand = new FirstCommand(mockView);

            //Воздействие на тестируемый объект
            firstCommand.Execute();
            int iExecute = 1;

            //Проверка теста
            mockView.Received().Render(firstCommand.GetType().ToString() + "\niExecute = " + iExecute++);
        }

        [Test]
        public void IsSampleCommandDecorator_CallsSampleCommand()
        {
            //Подготовка теста
            IView mockView = Substitute.For<IView>();
            ISampleCommand mockSampleCommand = Substitute.For<ISampleCommand>();
            SampleCommandDecorator sampleCommandDecorator = new SampleCommandDecorator(mockSampleCommand, mockView);

            //Воздействие на тестируемый объект
            sampleCommandDecorator.Execute();

            //Проверка теста
            mockSampleCommand.Received().Execute();
        }

        [Test]
        public void IsSampleCommandDecorator_ReturnsCorrectText()
        {
            //Подготовка теста
            IView mockView = Substitute.For<IView>();
            ISampleCommand mockSampleCommand = Substitute.For<ISampleCommand>();
            SampleCommandDecorator sampleCommandDecorator = new SampleCommandDecorator(mockSampleCommand, mockView);

            //Воздействие на тестируемый объект
            sampleCommandDecorator.Execute();

            //Проверка теста
            mockView.Received().Render("Начало: " + sampleCommandDecorator.GetType().ToString());
            mockView.Received().Render("Конец: " + sampleCommandDecorator.GetType().ToString());
        }

        [Test]
        public void IsExceptionCommandDecorator_CallsSampleCommand()
        {
            //Подготовка теста
            IView mockView = Substitute.For<IView>();
            ISampleCommand mockSampleCommand = Substitute.For<ISampleCommand>();
            ExceptionCommandDecorator exceptionCommandDecorator = new ExceptionCommandDecorator(mockSampleCommand, mockView);

            //Воздействие на тестируемый объект
            exceptionCommandDecorator.Execute();

            //Проверка теста
            mockSampleCommand.Received().Execute();
        }

        [Test]
        public void IsExceptionCommandDecorator_CallsException()
        {
            //Подготовка теста
            IView mockView = Substitute.For<IView>();
            ISampleCommand mockSampleCommand = Substitute.For<ISampleCommand>();
            
            mockSampleCommand.When(x => x.Execute()).Do(context => {  throw new Exception(); });
            ExceptionCommandDecorator exceptionCommandDecorator = new ExceptionCommandDecorator(mockSampleCommand, mockView);

            //Воздействие на тестируемый объект
            exceptionCommandDecorator.Execute();

            //Проверка теста
            mockView.Received().Render("Перехват исключений: " + this.GetType().ToString());
        }
        
        }
    }

