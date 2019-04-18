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
            this.buttonOperationNegate = new System.Windows.Forms.Button();
            this.buttonOperationPercent = new System.Windows.Forms.Button();
            this.buttonSymbolNine = new System.Windows.Forms.Button();
            this.buttonSymbolEight = new System.Windows.Forms.Button();
            this.buttonSymbolSeven = new System.Windows.Forms.Button();
            this.buttonSymbolSix = new System.Windows.Forms.Button();
            this.buttonSymbolFive = new System.Windows.Forms.Button();
            this.buttonSymbolFour = new System.Windows.Forms.Button();
            this.buttonSymbolThree = new System.Windows.Forms.Button();
            this.buttonSymbolTwo = new System.Windows.Forms.Button();
            this.buttonSymbolOne = new System.Windows.Forms.Button();
            this.buttonOperationAdd = new System.Windows.Forms.Button();
            this.buttonOperationSubtract = new System.Windows.Forms.Button();
            this.buttonOperationMultiply = new System.Windows.Forms.Button();
            this.buttonOperationDivide = new System.Windows.Forms.Button();
            this.buttonOperationEqual = new System.Windows.Forms.Button();
            this.buttonOperationReset = new System.Windows.Forms.Button();
            this.buttonOperationDot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(31, 13);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(278, 26);
            this.textBox.TabIndex = 0;
            this.textBox.Text = "0";
            this.textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonSymbolZero
            // 
            this.buttonSymbolZero.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSymbolZero.Location = new System.Drawing.Point(31, 343);
            this.buttonSymbolZero.Name = "buttonSymbolZero";
            this.buttonSymbolZero.Size = new System.Drawing.Size(136, 64);
            this.buttonSymbolZero.TabIndex = 18;
            this.buttonSymbolZero.Text = "0";
            this.buttonSymbolZero.UseVisualStyleBackColor = true;
            this.buttonSymbolZero.Click += new System.EventHandler(this.ButtonSymbolZero_Click);
            // 
            // buttonOperationNegate
            // 
            this.buttonOperationNegate.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.buttonOperationNegate.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOperationNegate.Location = new System.Drawing.Point(102, 63);
            this.buttonOperationNegate.Name = "buttonOperationNegate";
            this.buttonOperationNegate.Size = new System.Drawing.Size(65, 64);
            this.buttonOperationNegate.TabIndex = 3;
            this.buttonOperationNegate.Text = "+/-";
            this.buttonOperationNegate.UseVisualStyleBackColor = false;
            this.buttonOperationNegate.Click += new System.EventHandler(this.ButtonOperationNegate_Click);
            // 
            // buttonOperationPercent
            // 
            this.buttonOperationPercent.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.buttonOperationPercent.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOperationPercent.Location = new System.Drawing.Point(173, 63);
            this.buttonOperationPercent.Name = "buttonOperationPercent";
            this.buttonOperationPercent.Size = new System.Drawing.Size(65, 64);
            this.buttonOperationPercent.TabIndex = 4;
            this.buttonOperationPercent.Text = "%";
            this.buttonOperationPercent.UseVisualStyleBackColor = false;
            this.buttonOperationPercent.Click += new System.EventHandler(this.ButtonOperationPercent_Click);
            // 
            // buttonSymbolNine
            // 
            this.buttonSymbolNine.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSymbolNine.Location = new System.Drawing.Point(173, 133);
            this.buttonSymbolNine.Name = "buttonSymbolNine";
            this.buttonSymbolNine.Size = new System.Drawing.Size(65, 64);
            this.buttonSymbolNine.TabIndex = 8;
            this.buttonSymbolNine.Text = "9";
            this.buttonSymbolNine.UseVisualStyleBackColor = true;
            this.buttonSymbolNine.Click += new System.EventHandler(this.ButtonSymbolNine_Click);
            // 
            // buttonSymbolEight
            // 
            this.buttonSymbolEight.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSymbolEight.Location = new System.Drawing.Point(102, 133);
            this.buttonSymbolEight.Name = "buttonSymbolEight";
            this.buttonSymbolEight.Size = new System.Drawing.Size(65, 64);
            this.buttonSymbolEight.TabIndex = 7;
            this.buttonSymbolEight.Text = "8";
            this.buttonSymbolEight.UseVisualStyleBackColor = true;
            this.buttonSymbolEight.Click += new System.EventHandler(this.ButtonSymbolEight_Click);
            // 
            // buttonSymbolSeven
            // 
            this.buttonSymbolSeven.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSymbolSeven.Location = new System.Drawing.Point(31, 133);
            this.buttonSymbolSeven.Name = "buttonSymbolSeven";
            this.buttonSymbolSeven.Size = new System.Drawing.Size(65, 64);
            this.buttonSymbolSeven.TabIndex = 6;
            this.buttonSymbolSeven.Text = "7";
            this.buttonSymbolSeven.UseVisualStyleBackColor = true;
            this.buttonSymbolSeven.Click += new System.EventHandler(this.ButtonSymbolSeven_Click);
            // 
            // buttonSymbolSix
            // 
            this.buttonSymbolSix.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSymbolSix.Location = new System.Drawing.Point(173, 203);
            this.buttonSymbolSix.Name = "buttonSymbolSix";
            this.buttonSymbolSix.Size = new System.Drawing.Size(65, 64);
            this.buttonSymbolSix.TabIndex = 12;
            this.buttonSymbolSix.Text = "6";
            this.buttonSymbolSix.UseVisualStyleBackColor = true;
            this.buttonSymbolSix.Click += new System.EventHandler(this.ButtonSymbolSix_Click);
            // 
            // buttonSymbolFive
            // 
            this.buttonSymbolFive.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSymbolFive.Location = new System.Drawing.Point(102, 203);
            this.buttonSymbolFive.Name = "buttonSymbolFive";
            this.buttonSymbolFive.Size = new System.Drawing.Size(65, 64);
            this.buttonSymbolFive.TabIndex = 11;
            this.buttonSymbolFive.Text = "5";
            this.buttonSymbolFive.UseVisualStyleBackColor = true;
            this.buttonSymbolFive.Click += new System.EventHandler(this.ButtonSymbolFive_Click);
            // 
            // buttonSymbolFour
            // 
            this.buttonSymbolFour.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSymbolFour.Location = new System.Drawing.Point(31, 203);
            this.buttonSymbolFour.Name = "buttonSymbolFour";
            this.buttonSymbolFour.Size = new System.Drawing.Size(65, 64);
            this.buttonSymbolFour.TabIndex = 10;
            this.buttonSymbolFour.Text = "4";
            this.buttonSymbolFour.UseVisualStyleBackColor = true;
            this.buttonSymbolFour.Click += new System.EventHandler(this.ButtonSymbolFour_Click);
            // 
            // buttonSymbolThree
            // 
            this.buttonSymbolThree.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSymbolThree.Location = new System.Drawing.Point(173, 273);
            this.buttonSymbolThree.Name = "buttonSymbolThree";
            this.buttonSymbolThree.Size = new System.Drawing.Size(65, 64);
            this.buttonSymbolThree.TabIndex = 16;
            this.buttonSymbolThree.Text = "3";
            this.buttonSymbolThree.UseVisualStyleBackColor = true;
            this.buttonSymbolThree.Click += new System.EventHandler(this.ButtonSymbolThree_Click);
            // 
            // buttonSymbolTwo
            // 
            this.buttonSymbolTwo.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSymbolTwo.Location = new System.Drawing.Point(102, 273);
            this.buttonSymbolTwo.Name = "buttonSymbolTwo";
            this.buttonSymbolTwo.Size = new System.Drawing.Size(65, 64);
            this.buttonSymbolTwo.TabIndex = 15;
            this.buttonSymbolTwo.Text = "2";
            this.buttonSymbolTwo.UseVisualStyleBackColor = true;
            this.buttonSymbolTwo.Click += new System.EventHandler(this.ButtonSymbolTwo_Click);
            // 
            // buttonSymbolOne
            // 
            this.buttonSymbolOne.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSymbolOne.Location = new System.Drawing.Point(31, 273);
            this.buttonSymbolOne.Name = "buttonSymbolOne";
            this.buttonSymbolOne.Size = new System.Drawing.Size(65, 64);
            this.buttonSymbolOne.TabIndex = 14;
            this.buttonSymbolOne.Text = "1";
            this.buttonSymbolOne.UseVisualStyleBackColor = true;
            this.buttonSymbolOne.Click += new System.EventHandler(this.ButtonSymbolOne_Click);
            // 
            // buttonOperationAdd
            // 
            this.buttonOperationAdd.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.buttonOperationAdd.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOperationAdd.Location = new System.Drawing.Point(244, 273);
            this.buttonOperationAdd.Name = "buttonOperationAdd";
            this.buttonOperationAdd.Size = new System.Drawing.Size(65, 64);
            this.buttonOperationAdd.TabIndex = 17;
            this.buttonOperationAdd.Text = "+";
            this.buttonOperationAdd.UseVisualStyleBackColor = false;
            this.buttonOperationAdd.Click += new System.EventHandler(this.ButtonOperationAdd_Click);
            // 
            // buttonOperationSubtract
            // 
            this.buttonOperationSubtract.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.buttonOperationSubtract.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOperationSubtract.Location = new System.Drawing.Point(244, 203);
            this.buttonOperationSubtract.Name = "buttonOperationSubtract";
            this.buttonOperationSubtract.Size = new System.Drawing.Size(65, 64);
            this.buttonOperationSubtract.TabIndex = 13;
            this.buttonOperationSubtract.Text = "-";
            this.buttonOperationSubtract.UseVisualStyleBackColor = false;
            this.buttonOperationSubtract.Click += new System.EventHandler(this.ButtonOperationSubtract_Click);
            // 
            // buttonOperationMultiply
            // 
            this.buttonOperationMultiply.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.buttonOperationMultiply.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOperationMultiply.Location = new System.Drawing.Point(244, 133);
            this.buttonOperationMultiply.Name = "buttonOperationMultiply";
            this.buttonOperationMultiply.Size = new System.Drawing.Size(65, 64);
            this.buttonOperationMultiply.TabIndex = 9;
            this.buttonOperationMultiply.Text = "×";
            this.buttonOperationMultiply.UseVisualStyleBackColor = false;
            this.buttonOperationMultiply.Click += new System.EventHandler(this.ButtonOperationMultiply_Click);
            // 
            // buttonOperationDivide
            // 
            this.buttonOperationDivide.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.buttonOperationDivide.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOperationDivide.Location = new System.Drawing.Point(244, 63);
            this.buttonOperationDivide.Name = "buttonOperationDivide";
            this.buttonOperationDivide.Size = new System.Drawing.Size(65, 64);
            this.buttonOperationDivide.TabIndex = 5;
            this.buttonOperationDivide.Text = "÷";
            this.buttonOperationDivide.UseVisualStyleBackColor = false;
            this.buttonOperationDivide.Click += new System.EventHandler(this.ButtonOperationDivide_Click);
            // 
            // buttonOperationEqual
            // 
            this.buttonOperationEqual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonOperationEqual.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOperationEqual.Location = new System.Drawing.Point(244, 343);
            this.buttonOperationEqual.Name = "buttonOperationEqual";
            this.buttonOperationEqual.Size = new System.Drawing.Size(65, 64);
            this.buttonOperationEqual.TabIndex = 1;
            this.buttonOperationEqual.Text = "=";
            this.buttonOperationEqual.UseVisualStyleBackColor = false;
            this.buttonOperationEqual.Click += new System.EventHandler(this.ButtonOperationEqual_Click);
            // 
            // buttonOperationReset
            // 
            this.buttonOperationReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonOperationReset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOperationReset.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOperationReset.Location = new System.Drawing.Point(31, 63);
            this.buttonOperationReset.Name = "buttonOperationReset";
            this.buttonOperationReset.Size = new System.Drawing.Size(65, 64);
            this.buttonOperationReset.TabIndex = 2;
            this.buttonOperationReset.Text = "C";
            this.buttonOperationReset.UseVisualStyleBackColor = false;
            this.buttonOperationReset.Click += new System.EventHandler(this.ButtonOperationReset_Click);
            // 
            // buttonOperationDot
            // 
            this.buttonOperationDot.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOperationDot.Location = new System.Drawing.Point(173, 343);
            this.buttonOperationDot.Name = "buttonOperationDot";
            this.buttonOperationDot.Size = new System.Drawing.Size(65, 64);
            this.buttonOperationDot.TabIndex = 19;
            this.buttonOperationDot.Text = ".";
            this.buttonOperationDot.UseVisualStyleBackColor = true;
            this.buttonOperationDot.Click += new System.EventHandler(this.ButtonOperationDot_Click);
            // 
            // FormCalc
            // 
            this.AcceptButton = this.buttonOperationEqual;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonOperationReset;
            this.ClientSize = new System.Drawing.Size(337, 432);
            this.Controls.Add(this.buttonOperationDot);
            this.Controls.Add(this.buttonOperationEqual);
            this.Controls.Add(this.buttonOperationReset);
            this.Controls.Add(this.buttonOperationAdd);
            this.Controls.Add(this.buttonOperationSubtract);
            this.Controls.Add(this.buttonOperationMultiply);
            this.Controls.Add(this.buttonOperationDivide);
            this.Controls.Add(this.buttonSymbolThree);
            this.Controls.Add(this.buttonSymbolTwo);
            this.Controls.Add(this.buttonSymbolOne);
            this.Controls.Add(this.buttonSymbolSix);
            this.Controls.Add(this.buttonSymbolFive);
            this.Controls.Add(this.buttonSymbolFour);
            this.Controls.Add(this.buttonSymbolNine);
            this.Controls.Add(this.buttonSymbolEight);
            this.Controls.Add(this.buttonSymbolSeven);
            this.Controls.Add(this.buttonOperationPercent);
            this.Controls.Add(this.buttonOperationNegate);
            this.Controls.Add(this.buttonSymbolZero);
            this.Controls.Add(this.textBox);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(353, 471);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(353, 471);
            this.Name = "FormCalc";
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.FormCalc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button buttonSymbolZero;
        private System.Windows.Forms.Button buttonOperationNegate;
        private System.Windows.Forms.Button buttonOperationPercent;
        private System.Windows.Forms.Button buttonSymbolNine;
        private System.Windows.Forms.Button buttonSymbolEight;
        private System.Windows.Forms.Button buttonSymbolSeven;
        private System.Windows.Forms.Button buttonSymbolSix;
        private System.Windows.Forms.Button buttonSymbolFive;
        private System.Windows.Forms.Button buttonSymbolFour;
        private System.Windows.Forms.Button buttonSymbolThree;
        private System.Windows.Forms.Button buttonSymbolTwo;
        private System.Windows.Forms.Button buttonSymbolOne;
        private System.Windows.Forms.Button buttonOperationAdd;
        private System.Windows.Forms.Button buttonOperationSubtract;
        private System.Windows.Forms.Button buttonOperationMultiply;
        private System.Windows.Forms.Button buttonOperationDivide;
        private System.Windows.Forms.Button buttonOperationEqual;
        private System.Windows.Forms.Button buttonOperationReset;
        private System.Windows.Forms.Button buttonOperationDot;
    }
}

