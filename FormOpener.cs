using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
