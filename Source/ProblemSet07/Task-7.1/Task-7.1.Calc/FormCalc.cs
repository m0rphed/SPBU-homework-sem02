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

        private void FormCalc_Load(object sender, EventArgs e)
        {
            _c.OnTextChange += Local_OnTextChange;
        }

        private void Local_OnTextChange(string data)
        {
            textBox.Text = data;
        }

        private void ButtonSymbolZero_Click(object sender, EventArgs e)
        {
            _c.HandleDigit(0);
            // _c.HandleSymbol(OperationSymbol.Dot)
        }
    }
}
