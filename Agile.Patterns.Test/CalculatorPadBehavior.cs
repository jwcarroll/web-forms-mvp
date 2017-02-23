using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Agile.Calculator;
using Xunit;

namespace Agile.Patterns.Test
{
    public class CalculatorPadBehavior
    {
        [Fact]
        public void ShouldCorrectlyHandleChangingOperation()
        {
            var calcPad = new CalculatorPad();

            calcPad.One();
            calcPad.Zero();
            calcPad.Minus();
            calcPad.Plus();
            calcPad.One();
            calcPad.Zero();
            calcPad.EqualsButton();

            Assert.Equal("20", calcPad.Entry);
        }

        [Fact]
        public void ShouldHandleSingleMultiplicationCorrectly()
        {
            var calcPad = new CalculatorPad();

            calcPad.Six();
            calcPad.Multiply();
            calcPad.Six();

            Assert.Equal("6", calcPad.Entry);
        }

        [Fact]
        public void ShouldHandleMultiplyByZeroCorrectly()
        {
            var calcPad = new CalculatorPad();
            
            calcPad.Zero();
            calcPad.Multiply();
            calcPad.EqualsButton();
            calcPad.Six();
            calcPad.Multiply();
            calcPad.Six();
            calcPad.EqualsButton();

            Assert.Equal("36", calcPad.Entry);
        }

        [Fact]
        public void ShouldPerformMultiplicationOnItselfWhenEqualsButtonIsPressed()
        {
            var calcPad = new CalculatorPad();

            calcPad.One();
            calcPad.Zero();
            calcPad.Multiply();
            calcPad.EqualsButton();

            Assert.Equal("100", calcPad.Entry);
        }

        [Fact]
        public void ShouldPerformDivisionOnItselfWhenEqualsButtonIsPressed()
        {
            var calcPad = new CalculatorPad();

            calcPad.One();
            calcPad.Zero();
            calcPad.Divide();
            calcPad.EqualsButton();

            Assert.Equal("1", calcPad.Entry);
        }

        [Fact]
        public void ShouldPerformLastOperationOnNewValueEnteredIfEqualsButtonIsPressed()
        {
            var calcPad = new CalculatorPad();

            calcPad.One();
            calcPad.Zero();
            calcPad.Divide();
            calcPad.EqualsButton();

            Assert.Equal("1", calcPad.Entry);

            calcPad.Six();
            calcPad.EqualsButton();

            Assert.Equal("0.6", calcPad.Entry);

            calcPad.Four();
            calcPad.Five();
            calcPad.EqualsButton();

            Assert.Equal("4.5", calcPad.Entry);
        }

        [Fact]
        public void ShouldResetEventsAfterEqualsButtonIsPressed()
        {
            var calcPad = new CalculatorPad();

            calcPad.One();
            calcPad.Zero();
            calcPad.Divide();
            calcPad.EqualsButton();
            calcPad.Six();
            calcPad.Multiply();
            calcPad.Six();
            calcPad.EqualsButton();

            Assert.Equal("36", calcPad.Entry);
        }

        [Fact]
        public void ShouldReturnCorrectNumberAfterMultiplyByZero()
        {
            var calcPad = new CalculatorPad();

            calcPad.Six();
            calcPad.Multiply();
            calcPad.Zero();
            calcPad.EqualsButton();

            Assert.Equal("0", calcPad.Entry);

            calcPad.Six();
            calcPad.Multiply();
            calcPad.Six();
            calcPad.EqualsButton();

            Assert.Equal("36", calcPad.Entry);
        }

        [Fact]
        public void ShouldHandleLongChainOfCommandsAsString()
        {
            var calcPad = new CalculatorPad();

            calcPad.Execute("10*================");

            Assert.Equal("100000000000000000", calcPad.Entry);
        }

        [Fact]
        public void ShouldInterpretStringAsCommands()
        {
            var calcPad = new CalculatorPad();

            calcPad.Execute("1+1=");

            Assert.Equal("2", calcPad.Entry);
        }

        [Fact]
        public void ShouldCorrectlyHandleDecimalPoint()
        {
            var calcPad = new CalculatorPad();

            calcPad.Execute("1.1");

            Assert.Equal("1.1", calcPad.Entry);
        }
    }
}
