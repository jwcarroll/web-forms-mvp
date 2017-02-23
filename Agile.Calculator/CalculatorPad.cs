using System;
using System.Collections.Generic;

namespace Agile.Calculator
{
    public class CalculatorPad
    {
        private readonly FourFunction _fourFunction;
        private String _entry;
        private Char _sign;
        private Operation _operation;
        private Action _lastAction;
        private Decimal _currentValue;
        private Decimal _register;
        private Boolean _operationPending;
        
        public CalculatorPad()
        {
            _fourFunction = new FourFunction();
            _register = 0;
            _currentValue = 0;
            _entry = "0";
            _sign = '+';

            _operationPending = false;
            _operation = Operation.None;
            _lastAction = Action.None;
        }

        public String Entry
        {
            get { return String.Format("{0}", GetEntryValue()); }
        }

        public void One()
        {
            EnterValue("1");
        }

        public void Two()
        {
            EnterValue("2");
        }

        public void Three()
        {
            EnterValue("3");
        }

        public void Four()
        {
            EnterValue("4");
        }

        public void Five()
        {
            EnterValue("5");
        }

        public void Six()
        {
            EnterValue("6");
        }

        public void Seven()
        {
            EnterValue("7");
        }

        public void Eight()
        {
            EnterValue("8");
        }

        public void Nine()
        {
            EnterValue("9");
        }

        public void Zero()
        {
            EnterValue("0");
        }

        public void ChangeSign()
        {
            _sign = _sign == '-' ? '+' : '-';
        }

        public void Period()
        {
            EnterDecimalPoint();
        }

        public void Plus()
        {
            PerformOperation(Operation.Add);
        }

        public void Minus()
        {
            PerformOperation(Operation.Subtract);
        }

        public void Multiply()
        {
            PerformOperation(Operation.Multiply);
        }

        public void Divide()
        {
            PerformOperation(Operation.Divide);
        }

        public void EqualsButton()
        {
            if (_operationPending)
                _register = GetEntryValue();
            else
                _currentValue = GetEntryValue();

            EqualsOperation();
        }

        private void PerformOperation(Operation op)
        {
            if (!_operationPending)
            {
                _currentValue = GetEntryValue();
                _register = 0;
            }
            else
            {
                _register = GetEntryValue();

                if (_lastAction != Action.Operation)
                    EqualsOperation();
            }
            
            _operation = op;

            _lastAction = Action.Operation;
            _operationPending = true;
        }

        private void EqualsOperation()
        {
            if(_operationPending)
            {
                _fourFunction.LeftOperand = _currentValue;
                _fourFunction.RightOperand = _register;
                
                _register = GetEntryValue();

                _operationPending = false;
            }
            else
            {
                _fourFunction.LeftOperand = _currentValue;
                _fourFunction.RightOperand = _register;
            }
            

            switch(_operation)
            {
                case Operation.None:
                    break;
                case Operation.Add:
                    _currentValue = _fourFunction.Add();
                    break;
                case Operation.Subtract:
                    _currentValue = _fourFunction.Subtract();
                    break;
                case Operation.Divide:
                    _currentValue = _fourFunction.Divide();
                    break;
                case Operation.Multiply:
                    _currentValue = _fourFunction.Multiply();
                    break;
            }

            SetEntryValue(_currentValue);
            _lastAction = Action.Operation;
        }

        private void SetEntryValue(decimal currentValue)
        {
            _entry = String.Format("{0}", currentValue);

            _sign = _entry.IndexOf('-') >= 0 ? '-' : '+';

            _entry = _entry.Trim('-');
        }

        private decimal GetEntryValue()
        {
            Int32 decimalIndex = _entry.IndexOf('.');
            
            if (decimalIndex == 0)
                _entry = "0" + _entry;
            else if (decimalIndex == (_entry.Length - 1))
                _entry = _entry.Trim('.');

            if (String.IsNullOrEmpty(_entry))
                _entry = "0";

            return Decimal.Parse(String.Format("{0}{1}", _sign, _entry));
        }

        private void EnterValue(String value)
        {
            switch(_lastAction)
            {
                case Action.Operation:
                    _sign = '+';
                    _entry = value;
                    break;
                case Action.None:
                case Action.Value:
                    _entry += value;
                    break;
            }

            _lastAction = Action.Value;
        }
        
        private void EnterDecimalPoint()
        {
            const string value = ".";

            switch (_lastAction)
            {
                case Action.Operation:
                    _entry = String.Format("0{0}", value);
                    break;
                case Action.None:
                case Action.Value:
                    if(_entry.IndexOf(value) == -1)
                        _entry += value;
                    break;
            }

            _lastAction = Action.Value;
        }

        public void Execute(String commandString)
        {
            foreach (var c in commandString)
            {
                if (Char.IsDigit(c))
                {
                    EnterValue(c.ToString());
                }
                else switch (c)
                    {
                        case '.':
                            EnterDecimalPoint();
                            break;
                        case '+':
                            PerformOperation(Operation.Add);
                            break;
                        case '-':
                            PerformOperation(Operation.Subtract);
                            break;
                        case '/':
                            PerformOperation(Operation.Divide);
                            break;
                        case '*':
                            PerformOperation(Operation.Multiply);
                            break;
                        case '=':
                            EqualsButton();
                            break;
                        default:
                            throw new ArgumentException(
                                String.Format(
                                    "Invalid character: '{0}' does not correspond to any available action on {1}", c,
                                    GetType().Name));
                    }
            }
        }
    }
}
