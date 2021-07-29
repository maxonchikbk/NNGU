using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {       
        bool state = true;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Func.kolzad = Convert.ToInt16(textBox1.Text);
            Func.length = Convert.ToInt16(textBox2.Text);
            Func.N = Convert.ToInt16(textBox6.Text);
            Func.K = Convert.ToInt16(textBox5.Text);
            if (radioButton1.Checked) Func.zadanie = 1;
            if (radioButton2.Checked) Func.zadanie = 2;
            if (radioButton3.Checked) Func.zadanie = 3;
            if (radioButton4.Checked) Func.zadanie = 4;
            if (radioButton5.Checked) Func.zadanie = 5;
            Form8 f = new Form8();
            f.ShowDialog();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {            
            if (state)
            {
                label3.Visible = true;
                textBox2.Visible = true;
                state = false;
            }
            else
            {
                label3.Visible = false;
                textBox2.Visible = false;
                state = true;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (state)
            {
                panel1.Visible = true;                
                state = false;
            }
            else
            {
                panel1.Visible = false;                
                state = true;
            }
        }       
    }
}
