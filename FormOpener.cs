using System;
using System.Windows.Forms;

namespace WinFormsCefSharpSample
{
    public partial class FormOpener : Form
    {
        public FormOpener()
        {
            InitializeComponent();
        }

        private void btnBasic_Click(object sender, EventArgs e)
        {
            var form = new FormBasic();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new FormOpenDevTools();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new JsMessageSample.JsMessageSampleForm();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new ChangePopupIconSample.SampleForm();
            form.Show();
        }
    }
}
