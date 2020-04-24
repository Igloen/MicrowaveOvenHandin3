using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Interfaces;
using NUnit.Framework;

namespace Microwave.Test.Integration2
{
    [TestFixture]
    public class IT1_2_3_PowerTubeDisplayLight
    {
        private IOutput _output;
        private IPowerTube _powerTube;
        private ILight _light;
        private IDisplay _display;
        private StringWriter _writer;
        

        [SetUp]
        public void Setup()
        {
            _output = new Output();
            _powerTube = new PowerTube(_output);
            _light = new Light(_output);
            _display = new Display(_output);
            _writer = new StringWriter();

        }

        #region PowerTube

        [TestCase(50)]
        [TestCase(100)]
        [TestCase(1)]
        public void TestPowertube_OutputInRangeTurnOn(int power)
        {
            
            Console.SetOut(_writer);

            _powerTube.TurnOn(power);

            string ConsoleOutput = _writer.ToString();
            
            Assert.That(ConsoleOutput,Is.EqualTo($"PowerTube works with {power}\r\n"));
         
            
        }

        [Test]
        public void TestPowertube_OutputTurnOff()
        {
            _powerTube.TurnOn(50);

            Console.SetOut(_writer);

            _powerTube.TurnOff();

            string ConsoleOutput = _writer.ToString();

            Assert.That(ConsoleOutput, Is.EqualTo("PowerTube turned off\r\n"));


        }


        #endregion

        #region  Light

        [Test]
        public void TestLight_OutputTurnOn()
        {
            Console.SetOut(_writer);

            _light.TurnOn();

            string ConsoleOutput = _writer.ToString();

            Assert.That(ConsoleOutput, Is.EqualTo($"Light is turned on\r\n"));
        }


        [Test]
        public void TestLight_OutputTurnOff()
        {
            _light.TurnOn();

            Console.SetOut(_writer);

            _light.TurnOff();

            string ConsoleOutput = _writer.ToString();

            Assert.That(ConsoleOutput, Is.EqualTo($"Light is turned off\r\n"));
        }



        #endregion

        #region Display



        #endregion
    }
}
