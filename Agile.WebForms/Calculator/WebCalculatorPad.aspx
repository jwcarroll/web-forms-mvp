<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebCalculatorPad.aspx.cs" Inherits="Agile.WebForms.Calculator.WebCalculatorPad" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-4">
            <div class="calc-pad-container">
                <div class="row">
                    <div class="col-xs-12">
                        <div class="calc-pad-output">
                            <asp:Label runat="server" ID="lblOutput"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-3"><div class="calcPad-Button" title="Seven">7</div></div>
                    <div class="col-xs-3"><div class="calcPad-Button" title="Eight">8</div></div>
                    <div class="col-xs-3"><div class="calcPad-Button" title="Nine">9</div></div>
                    <div class="col-xs-3"><div class="calcPad-Button" title="Divide">/</div></div>
                </div>
                <div class="row">
                    <div class="col-xs-3"><div class="calcPad-Button" title="Four">4</div></div>
                    <div class="col-xs-3"><div class="calcPad-Button" title="Five">5</div></div>
                    <div class="col-xs-3"><div class="calcPad-Button" title="Six">6</div></div>
                    <div class="col-xs-3"><div class="calcPad-Button" title="Multiply">*</div></div>
                </div>
                <div class="row">
                    <div class="col-xs-3"><div class="calcPad-Button" title="One">1</div></div>
                    <div class="col-xs-3"><div class="calcPad-Button" title="Two">2</div></div>
                    <div class="col-xs-3"><div class="calcPad-Button" title="Three">3</div></div>
                    <div class="col-xs-3"><div class="calcPad-Button" title="Subtract">-</div></div>
                </div>
                <div class="row">
                    <div class="col-xs-6"><div class="calcPad-Button calcPad-DoubleWidth" title="Zero">0</div></div>
                    <div class="col-xs-3"><div class="calcPad-Button" title="Decimal">.</div></div>
                    <div class="col-xs-3"><div class="calcPad-Button" title="Add">+</div></div>
                </div>
                <div class="row">
                    <div class="col-xs-6"><div class="calcPad-Button calcPad-DoubleWidth" title="ChangeSign">+-</div></div>
                    <div class="col-xs-6"><div class="calcPad-Button calcPad-DoubleWidth" title="Equals">=</div></div>
                </div>
            </div>
        </div>
        <div class="col-sm-8">
            <h1>Web Calculator</h1>
            <p>
                The web calculator is a good example of how the Model View Presenter pattern can be used to
        build a single component that will work with any reasonably implemented view. The same Presenter
        that is driving the WinForms example is driving this example.
            </p>
            <p>
                Realistically, you would never implement a calculator that sends every button click event to the
        server ;) However, knowing that the only code here not covered by testing is the .aspx page is pretty
        cool!
            </p>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageScriptContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".calcPad-Button")
                .click(function () {
                    __doPostBack('handle-button-click', $(this).attr("title"));
                });
        });
    </script>
</asp:Content>
