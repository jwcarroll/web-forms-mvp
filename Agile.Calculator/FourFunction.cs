using System;

namespace Agile.Calculator
{
    public class FourFunction
    {
        private Decimal _leftOperand;
        private Decimal _rightOperand;

        public Decimal RightOperand
        {
            get { return _rightOperand; }
            set { _rightOperand = value; }
        }

        public Decimal LeftOperand
        {
            get { return _leftOperand; }
            set { _leftOperand = value; }
        }

        public Decimal Add()
        {
            return LeftOperand + RightOperand;
        }

        public Decimal Subtract()
        {
            return LeftOperand - RightOperand;
        }

        public Decimal Divide()
        {
            return LeftOperand / RightOperand;
        }

        public Decimal Multiply()
        {
            return LeftOperand * RightOperand;
        }
    }
}
