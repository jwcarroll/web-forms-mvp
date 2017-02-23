using System;
using Agile.Calculator;

namespace Agile.Patterns.MVP
{
    public class CalculatorPresenter
    {
        public ICalculatorView View { get; set; }

        private CalculatorPad _calculatorPad;
        public CalculatorPad Pad
        {
            get { return _calculatorPad ?? (_calculatorPad = new CalculatorPad()); }
            set{ _calculatorPad = value;}
        }
        
        public void InitializeView()
        {
            View.Output = "0";
            View.ButtonPress += View_ButtonPress;
        }

        void View_ButtonPress(object sender, CalculatorButtonPressEventArgs e)
        {
            HandleButton(e.ButtonPressed);

            if(e.ButtonPressed != CalculatorButton.Decimal)
                View.Output = Pad.Entry;
        }

        private void HandleButton(CalculatorButton button)
        {
            switch (button)
            {
                case CalculatorButton.Zero:
                    Pad.Zero();
                    break;
                case CalculatorButton.One:
                    Pad.One();
                    break;
                case CalculatorButton.Two:
                    Pad.Two();
                    break;
                case CalculatorButton.Three:
                    Pad.Three();
                    break;
                case CalculatorButton.Four:
                    Pad.Four();
                    break;
                case CalculatorButton.Five:
                    Pad.Five();
                    break;
                case CalculatorButton.Six:
                    Pad.Six();
                    break;
                case CalculatorButton.Seven:
                    Pad.Seven();
                    break;
                case CalculatorButton.Eight:
                    Pad.Eight();
                    break;
                case CalculatorButton.Nine:
                    Pad.Nine();
                    break;
                case CalculatorButton.Decimal:
                    Pad.Period();
                    break;
                case CalculatorButton.Add:
                    Pad.Plus();
                    break;
                case CalculatorButton.Subtract:
                    Pad.Minus();
                    break;
                case CalculatorButton.Multiply:
                    Pad.Multiply();
                    break;
                case CalculatorButton.Divide:
                    Pad.Divide();
                    break;
                case CalculatorButton.Equals:
                    Pad.EqualsButton();
                    break;
                case CalculatorButton.ChangeSign:
                    Pad.ChangeSign();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}