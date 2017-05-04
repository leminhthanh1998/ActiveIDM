using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ActiveIDMan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length!=0&&textBox2.Text.Length!=0&&textBox3.Text.Length!=0)
            {
                DelReg del = new DelReg();
                del.XoaReg();
                FakeLicense fake = new FakeLicense();
                fake.Fake(textBox1.Text, textBox2.Text, textBox3.Text);

            }
            else
            {
                MessageBox.Show("Hãy chắc là bạn đã nhập Name và Email");
            }

        }

        string[] keyIdm =
        {
            "HF0I6-AYL1O-BHDI7-DG9LW", "WNJ39-J1JN0-JKNVS-BZSCB", "OUC2X-F1F8A-8LO76-ETQCK",
            "HSIWU-KRQQQ-Y870K-YI6QQ", "4LWTP-H1OGR-75A92-7GWRM", "33W2S-KXK34-HYSO6-601AK", "856PX-89ROT-QG0PW-TOPZM",
            "L67GT-CE6TR-DFT1D-XWVCM", "CJA0S-K6CO4-R4NPJ-EKNRK", "N0Z90-KJTTW-7TZO4-I27A1"
        };
        private void button2_Click(object sender, EventArgs e)
        {
            //button2.Image = Image.FromFile();
            Random ran=new Random();
            textBox3.Text = keyIdm[ran.Next(0,9)];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f=new Form2();
            f.Show();
        }
    }
}
