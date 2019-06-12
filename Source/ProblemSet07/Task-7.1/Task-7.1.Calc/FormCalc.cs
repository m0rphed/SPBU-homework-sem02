using System;
using System.Windows.Forms;

namespace Task_7._1.Calc
{
    public partial class FormCalc : Form
    {
        public FormCalc()
        {
            InitializeComponent();
        }

        private readonly ICalculator calculator = new Calculator();

        private bool blockReentry;

        private void FormCalc_Load(object sender, EventArgs e)
        {
            calculator.OnTextChange += Local_OnTextChange;
        }

        private void Local_OnTextChange(string data)
        {
            textBox.Text = data;
        }

        private void GuardFromUpdates(Action action)
        {
            if (!blockReentry)
            {
                blockReentry = true;
                action();
                blockReentry = false;
            }
        }

        private void ButtonOperation_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            GuardFromUpdates(() =>
            {
                switch (button.Text)
                {
                    case "C":
                        calculator.HandleSpecialSymbol(SymbolType.Reset);
                        break;
                    case ".":
                        calculator.HandleSpecialSymbol(SymbolType.Dot);
                        break;
                    case "=":
                        calculator.HandleSpecialSymbol(SymbolType.Equal);
                        break;
                    case "+":
                        calculator.HandleSpecialSymbol(SymbolType.Add);
                        break;
                    case "-":
                        calculator.HandleSpecialSymbol(SymbolType.Subtract);
                        break;
                    case "×":
                        calculator.HandleSpecialSymbol(SymbolType.Multiply);
                        break;
                    case "÷":
                        calculator.HandleSpecialSymbol(SymbolType.Divide);
                        break;
                    case "+/-":
                        calculator.HandleSpecialSymbol(SymbolType.Negate);
                        break;
                    case "%":
                        calculator.HandleSpecialSymbol(SymbolType.Percent);
                        break;
                    default:
                        return;
                }
            });
        }

        private void ButtonDigit_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            GuardFromUpdates(() =>
            {
                calculator.HandleDigit(int.Parse(button.Text));
            });
        }
    }
}
