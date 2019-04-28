namespace Task_7.Problem_2
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Simple clock app.
    /// Shows your system time.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// Main form of the project
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handler for timer tick event
        /// </summary>
        /// <param name="sender">timer</param>
        /// <param name="e">event arguments metadata</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            TextBox.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        /// <summary>
        /// Handler for opening of an app
        /// </summary>
        /// <param name="sender">main app form</param>
        /// <param name="e">event arguments metadata</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            Timer.Start();
        }

        /// <summary>
        /// Handler for closing of an app
        /// </summary>
        /// <param name="sender">main app form</param>
        /// <param name="e">event arguments metadata</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Timer.Stop();
        }
    }
}
