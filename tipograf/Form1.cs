using System;
using System.Windows.Forms;

namespace tipograf
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, EventArgs e)
        {
            string text = textBox.Text;
            text = Rules.MainPart(text);

            textBox.Text = text;
            textBox.SelectionStart = textBox.Text.Length;
            textBox.ScrollToCaret();
        }
    }
}
