using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Impes.QQRobot
{
    public partial class InputBox : Form
    {
        Form1 form;
        public InputBox(string title,string url,Form1 form)
        {
            InitializeComponent();
            this.Text = title;
            this.urlTxt.Text = url;
            this.form = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.code = tokenTxt.Text;
            Thread.Sleep(1000);
            this.Close();
        }
    }
}
