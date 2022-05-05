using Konata.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My.QQRobot
{
    public partial class Login : Form
    {
        Form1 form;
        public Login(Form1 form)
        {
            this.form = form;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.key = form.UpdateKeystore(new BotKeyStore(qqTxt.Text, pwdTxt.Text));
            Thread.Sleep(1000);
            this.Close();
        }
    }
}
