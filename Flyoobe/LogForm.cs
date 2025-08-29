using System.Windows.Forms;

namespace Flyoobe
{
    public partial class LogForm : Form
    {
        public LogForm(string logText)
        {
            InitializeComponent();
            richLog.Text = logText;
            richLog.SelectionStart = richLog.Text.Length; // Scroll to the end of the log
        }
    }
}