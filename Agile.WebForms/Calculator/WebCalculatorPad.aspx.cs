using System;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using Agile.Calculator;
using Agile.Patterns.MVP;

namespace Agile.WebForms.Calculator
{
    public partial class WebCalculatorPad : Page, ICalculatorView
    {
        private CalculatorPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter = new CalculatorPresenter { View = this, Pad = CalcPad };
            Presenter.InitializeView();

            if (IsPostBack)
            {
                var target = Request.Params["__EVENTTARGET"];
                var arg = Request.Params["__EVENTARGUMENT"];

                HandlePostbackEvent(target, arg);
            }
        }

        public string Output
        {
            get { return lblOutput.Text; }
            set { lblOutput.Text = value; }
        }

        public event EventHandler<CalculatorButtonPressEventArgs> ButtonPress;

        public void InvokeButtonPress(CalculatorButtonPressEventArgs e)
        {
            ButtonPress?.Invoke(this, e);
        }

        private void HandlePostbackEvent(string target, string arg)
        {
            if(target == "handle-button-click")
            {
                var button = (CalculatorButton)Enum.Parse(typeof(CalculatorButton), arg, true);
                InvokeButtonPress(new CalculatorButtonPressEventArgs(button));
            }
        }

        private static CalculatorPad CalcPad
        {
            get
            {
                var calcPad = HttpContext.Current.Session["CalculatorPad"] as CalculatorPad;

                if (calcPad == null)
                    HttpContext.Current.Session["CalculatorPad"] = (calcPad = new CalculatorPad());

                return calcPad;
            }
        }
    }
}