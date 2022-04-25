using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tech.MultiTask.UI
{
    public partial class Form1 : Form
    {
        FilePlay play = new FilePlay(@"c:\a\");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            play.CreateTask_Creation();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            play.CreateTask_Delete();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            play.CreateMultiTask_Creation();
        }

        private void button4_Click(object sender, EventArgs e)
        {
             
            play.CreateMultiTask_Delete();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            play.CreateTask_Weather(textBox2.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
             
            play.Auto(textBox2.Text);
            play.AutoRead();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Text = play.requests.Count.ToString();
        }
    }
}
