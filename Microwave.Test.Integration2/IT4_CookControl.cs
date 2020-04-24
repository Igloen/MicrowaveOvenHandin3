using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Microwave.Test.Integration2
{
    [TestFixture]
    public class IT4_CookControl
    {
        private ICookController _cookController;
        private IPowerTube _powerTube;
        private IDisplay _display;
        private IOutput _output;
        private ITimer _timer;
        private StringWriter _writer;

        [SetUp]
        public void SetUp()
        {
            _output = new Output();
            _powerTube = new PowerTube(_output);
            _display = new Display(_output);
            _timer = Substitute.For<ITimer>();
            _cookController = new CookController(_timer, _display, _powerTube);
            _writer = new StringWriter();
        }


        #region PowerTube

        [TestCase(50)]
        public void TestCookController_StartCooking_PowerTubeIntegration(int power)
        {
            Console.SetOut(_writer);

            _cookController.StartCooking(power, 20);

            string ConsoleOutput = _writer.ToString();

            Assert.That(ConsoleOutput, Is.EqualTo($"PowerTube works with {power}\r\n"));
        }


        [Test]
        public void TestCookController_Stop_PowerTubeIntegration()
        {
            _cookController.StartCooking(50, 20);

            Console.SetOut(_writer);

            _cookController.Stop();

            string ConsoleOutput = _writer.ToString();

            Assert.That(ConsoleOutput, Is.EqualTo($"PowerTube turned off\r\n"));
        }

        #endregion


        #region Display

        [TestCase(50)]
        public void TestCookController_OnTimerTick_DisplayIntegration(int remainingTime)
        {
            Console.SetOut(_writer);

            _timer.TimeRemaining.Returns(remainingTime);

            _timer.TimerTick += Raise.EventWith(new EventArgs());

            string ConsoleOutput = _writer.ToString();

            int min = remainingTime / 60;
            int sec = remainingTime % 60;

            Assert.That(ConsoleOutput, Is.EqualTo($"Display shows: {min:D2}:{sec:D2}\r\n"));
        }

        #endregion



    }
}
