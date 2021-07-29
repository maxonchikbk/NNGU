using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        bool state = false;
        public static int[,] a = new int[Func.A, Func.B];
        public int stepen(int z)
        {
            int res = 1;
            for (int i = 1; i <= z; i++)
                res *= 2;
            return res;
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = true;
            dataGridView1.Visible = false;
            button2.Visible = false;
            panel3.Visible = false;
            state = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = true;
            dataGridView1.Visible = true;
            button2.Visible = false;
            state = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView1.ReadOnly = false;
            if (radioButton1.Checked)
            {                
                int k = Convert.ToInt16(textBox1.Text);
                int n = Convert.ToInt16(textBox2.Text);
                panel2.Visible = false;
                button2.Visible = true;
                dataGridView1.ColumnCount = n;
                dataGridView1.RowCount = stepen(k);
            }             
            if (state)
            {
                Form6 f = new Form6();
                f.ShowDialog();               
            }
            state = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int k = Convert.ToInt16(textBox1.Text);
            int n = Convert.ToInt16(textBox2.Text);
            for (int i = 0; i <= (n - 1); i++)
                for (int j = 0; j <= stepen(k) - 1; j++)
                {
                    dataGridView1.Rows[j].Cells[i].Value = rnd.Next(2);
                    a[j, i] = Convert.ToInt16(dataGridView1.Rows[j].Cells[i].Value);
                }
        }

    }
}
