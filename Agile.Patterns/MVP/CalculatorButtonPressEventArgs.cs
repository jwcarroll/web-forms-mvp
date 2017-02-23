using System;

namespace Agile.Patterns.MVP
{
    public class CalculatorButtonPressEventArgs : EventArgs
    {
        public CalculatorButton ButtonPressed { get; private set; }

        public CalculatorButtonPressEventArgs(CalculatorButton buttonPressed)
        {
            ButtonPressed = buttonPressed;
        }
    }
}
