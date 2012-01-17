using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzz
{
    [TestClass]
    public class Tests
    {
        private FizzBuzzer _fizzBuzzer;

        [TestInitialize]
        public void Initialize()
        {
            _fizzBuzzer = new FizzBuzzer();
        }

        [TestMethod]
        public void NormalNumbersReturnThemselves()
        {
            Assert.AreEqual("1", _fizzBuzzer.Calculate(1));
            Assert.AreEqual("2", _fizzBuzzer.Calculate(2));
            Assert.AreEqual("4", _fizzBuzzer.Calculate(4));
            Assert.AreEqual("7", _fizzBuzzer.Calculate(7));
        }

        [TestMethod]
        public void MultipleOfThreeReturnsFizz()
        {
            Assert.AreEqual("Fizz", _fizzBuzzer.Calculate(3));
            Assert.AreEqual("Fizz", _fizzBuzzer.Calculate(6));
        }

        [TestMethod]
        public void MultiplesOfFiveReturnsBuzz()
        {
            Assert.AreEqual("Buzz", _fizzBuzzer.Calculate(5));
            Assert.AreEqual("Buzz", _fizzBuzzer.Calculate(10));
        }

        [TestMethod]
        public void MultiplesOfFifteenReturnsFizzBuzz()
        {
            Assert.AreEqual("FizzBuzz", _fizzBuzzer.Calculate(15));
            Assert.AreEqual("FizzBuzz", _fizzBuzzer.Calculate(30));
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void NumberSmallerThanOneThrowsException()
        {
            _fizzBuzzer.Calculate(0);
        }

        [TestMethod]
        public void CriticalValuesStillWork()
        {
            _fizzBuzzer.Calculate(1);
            _fizzBuzzer.Calculate(100);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void NumberGreaterThanOneHundredThrowsException()
        {
            _fizzBuzzer.Calculate(101);
        }
    }
}
