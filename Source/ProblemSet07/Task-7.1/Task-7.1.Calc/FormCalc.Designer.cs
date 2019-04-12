namespace Task_7._1.Calc
{
    partial class FormCalc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox = new System.Windows.Forms.TextBox();
            this.buttonSymbolZero = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(31, 13);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(100, 20);
            this.textBox.TabIndex = 0;
            // 
            // buttonSymbolZero
            // 
            this.buttonSymbolZero.Location = new System.Drawing.Point(31, 63);
            this.buttonSymbolZero.Name = "buttonSymbolZero";
            this.buttonSymbolZero.Size = new System.Drawing.Size(75, 23);
            this.buttonSymbolZero.TabIndex = 1;
            this.buttonSymbolZero.Text = "0";
            this.buttonSymbolZero.UseVisualStyleBackColor = true;
            this.buttonSymbolZero.Click += new System.EventHandler(this.ButtonSymbolZero_Click);
            // 
            // FormCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSymbolZero);
            this.Controls.Add(this.textBox);
            this.Name = "FormCalc";
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.FormCalc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button buttonSymbolZero;
    }
}

