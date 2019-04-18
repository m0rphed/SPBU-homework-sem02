using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_7._1.Calc
{
    public partial class FormCalc : Form
    {
        public FormCalc()
        {
            InitializeComponent();
        }

        private ICalculator _c = new Calculator();

        private bool _blockReentry;

        private void FormCalc_Load(object sender, EventArgs e)
        {
            _c.OnTextChange += Local_OnTextChange;
        }

        private void Local_OnTextChange(string data)
        {
            textBox.Text = data;
        }

        private void GuardFromUpdates(Action action)
        {
            if (!_blockReentry)
            {
                _blockReentry = true;
                action();
                _blockReentry = false;
            }
        }

        private void ButtonSymbolZero_Click(object sender, EventArgs e)
        {
            GuardFromUpdates(() => {
                _c.HandleDigit(0);
            });
        }

        private void ButtonOperationNegate_Click(object sender, EventArgs e)
        {
            GuardFromUpdates(() => {
                _c.HandleSpecialSymbol(SymbolType.Negate);
            });
        }

        private void ButtonSymbolSeven_Click(object sender, EventArgs e)
        {
            GuardFromUpdates(() => {
                _c.HandleDigit(7);
            });
        }

        private void ButtonSymbolFour_Click(object sender, EventArgs e)
        {
            GuardFromUpdates(() => {
                _c.HandleDigit(4);
            });
        }

        private void ButtonOperationDivide_Click(object sender, EventArgs e)
        {
            GuardFromUpdates(() => {
                _c.HandleSpecialSymbol(SymbolType.Divide);
            });
        }

        private void ButtonOperationEqual_Click(object sender, EventArgs e)
        {
            GuardFromUpdates(() => {
                _c.HandleSpecialSymbol(SymbolType.Equal);
            });
        }

        private void ButtonSymbolOne_Click(object sender, EventArgs e)
        {
            GuardFromUpdates(() => {
                _c.HandleDigit(1);
            });
        }

        private void ButtonOperationReset_Click(object sender, EventArgs e)
        {
            GuardFromUpdates(() => {
                _c.HandleSpecialSymbol(SymbolType.Reset);
            });
        }

        private void ButtonSymbolEight_Click(object sender, EventArgs e)
        {
            GuardFromUpdates(() => {
                _c.HandleDigit(8);
            });
        }

        private void ButtonSymbolNine_Click(object sender, EventArgs e)
        {
            GuardFromUpdates(() => {
                _c.HandleDigit(9);
            });
        }

        private void ButtonSymbolFive_Click(object sender, EventArgs e)
        {
            GuardFromUpdates(() => {
                _c.HandleDigit(5);
            });
        }

        private void ButtonSymbolSix_Click(object sender, EventArgs e)
        {
            GuardFromUpdates(() => {
                _c.HandleDigit(6);
            });
        }

        private void ButtonSymbolTwo_Click(object sender, EventArgs e)
        {
            GuardFromUpdates(() => {
                _c.HandleDigit(2);
            });
        }

        private void ButtonSymbolThree_Click(object sender, EventArgs e)
        {
            GuardFromUpdates(() => {
                _c.HandleDigit(3);
            });
        }

        private void ButtonOperationDot_Click(object sender, EventArgs e)
        {
            GuardFromUpdates(() => {
                _c.HandleSpecialSymbol(SymbolType.Dot);
            });
        }

        private void ButtonOperationPercent_Click(object sender, EventArgs e)
        {
            GuardFromUpdates(() => {
                _c.HandleSpecialSymbol(SymbolType.Percent);
            });
        }

        private void ButtonOperationMultiply_Click(object sender, EventArgs e)
        {
            GuardFromUpdates(() => {
                _c.HandleSpecialSymbol(SymbolType.Multiply);
            });
        }

        private void ButtonOperationSubtract_Click(object sender, EventArgs e)
        {
            GuardFromUpdates(() => {
                _c.HandleSpecialSymbol(SymbolType.Subtract);
            });
        }

        private void ButtonOperationAdd_Click(object sender, EventArgs e)
        {
            GuardFromUpdates(() => {
                _c.HandleSpecialSymbol(SymbolType.Add);
            });
        }
    }
}
