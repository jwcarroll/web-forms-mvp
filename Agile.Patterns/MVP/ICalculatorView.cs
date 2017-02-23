using System;

namespace Agile.Patterns.MVP
{
    public interface ICalculatorView
    {
        String Output { get; set; }
        event EventHandler<CalculatorButtonPressEventArgs> ButtonPress;
    }
}