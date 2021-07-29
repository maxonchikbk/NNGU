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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            int k = Func.K;
            int n = Func.N;
            int[,] a = new int[Func.K, Func.N];
            dataGridView1.ColumnCount = n;
            dataGridView1.RowCount = Func.stepen(k);
            for (int i = 0; i <= (n - 1); i++)
                for (int j = 0; j <= Func.stepen(k) - 1; j++)
               {                    
                dataGridView1.Rows[j].Cells[i].Value = Func.a[j, i];
               }
            
        }        

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            f.ShowDialog();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int temp=0;
            int k = Func.K;
            int n = Func.N;
            for (int i = 0; i < n; i++)
                for (int j = 0; j <= Func.stepen(k) - 1; j++)
                {
                    Func.a[j, i] = Convert.ToInt16(dataGridView1.Rows[j].Cells[i].Value);
                }
            textBox1.Text = Convert.ToString(((Func.codelenght(Func.a, k, n) + 1) / 2 - 1));
            textBox2.Text =  Convert.ToString(Func.codelenght(Func.a, k, n) - 1);

            if (Func.systematic(Func.a, k, n) == 1)
            {
                label3.Text = "систематический";
                button2.Enabled = true;
                if (Func.linerian(Func.a, k, n) == 1) { textBox4.Text = "линейный"; }
                else
                {
                    textBox4.Text = "нелинейный";
                    if (Func.kvazilinerian(Func.a, k, n) == 1) textBox4.Text = textBox4.Text + " " + "квазилинейный";
                    else textBox4.Text = textBox4.Text + " " + "неквазилинейный";
                }

                textBox3.Text = "{";
                for (int i = 1; i < Func.sh; i++)
                {
                    temp = Func.syscount[i] + 1;
                    textBox3.Text += temp;
                    if (((i / k) * k == i) && (i != Func.sh - 1)) { textBox3.Text = textBox3.Text + "} {"; }
                }
                textBox3.Text = textBox3.Text + "} ";
            }
            else
            {
                label3.Text = "не систематический";
                button2.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            Func.K = Convert.ToInt16(textBox5.Text);
            Func.N = Convert.ToInt16(textBox6.Text);
            int k = Convert.ToInt16(textBox5.Text);
            int n = Convert.ToInt16(textBox6.Text);
            dataGridView1.ColumnCount = n;
            dataGridView1.RowCount = Func.stepen(k);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            Random rnd = new Random();
            Func.K = Convert.ToInt16(textBox5.Text);
            Func.N = Convert.ToInt16(textBox6.Text); 
            int k = Convert.ToInt16(textBox5.Text);
            int n = Convert.ToInt16(textBox6.Text);
            dataGridView1.ColumnCount = n;
            dataGridView1.RowCount = Func.stepen(k);
            for (int i = 0; i <= (n - 1); i++)
                for (int j = 0; j <= Func.stepen(k) - 1; j++)
                {
                    dataGridView1.Rows[j].Cells[i].Value = rnd.Next(2);                   
                }
        }
    }
}
