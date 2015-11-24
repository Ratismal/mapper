using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mapper
{
    public partial class New : Form
    {
        public int height;
        public int width;

        public New()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            height = Int32.Parse(textBox1.Text);
            width = Int32.Parse(textBox2.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
