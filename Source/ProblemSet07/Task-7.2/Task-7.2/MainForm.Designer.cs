namespace Task_7.Problem_2
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // TextBox
            // 
            this.TextBox.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox.CausesValidation = false;
            this.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.TextBox.Location = new System.Drawing.Point(0, 0);
            this.TextBox.Name = "TextBox";
            this.TextBox.ReadOnly = true;
            this.TextBox.ShortcutsEnabled = false;
            this.TextBox.Size = new System.Drawing.Size(299, 73);
            this.TextBox.TabIndex = 0;
            this.TextBox.TabStop = false;
            this.TextBox.Text = "00:00:00";
            this.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBox.WordWrap = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(299, 81);
            this.Controls.Add(this.TextBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(315, 120);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(315, 120);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Clock";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.TextBox TextBox;
    }
}

