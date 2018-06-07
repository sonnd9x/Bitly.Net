using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bitly.Net;

namespace BitlyWrapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var bitly = new BitlyAPI();
            bitly.ACCESS_TOKEN = "YOUR ACCESS TOKEN KEY";
            if (textBox1.Text != "")
            {
                textBox2.Text = await bitly.ShortenAsync(textBox1.Text);
            }
        }
    }
}
