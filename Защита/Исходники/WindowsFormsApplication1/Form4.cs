using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        bool show = true;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n, k, l;
            pictureBox1.SendToBack();
            button2.Text = "Показать график";
            show = true;
            if (!int.TryParse(numericUpDown1.Text, out k) || !int.TryParse(numericUpDown2.Text, out n) || !int.TryParse(textBox3.Text, out l)) MessageBox.Show("ошибка ввода");
            else
            {

                int.TryParse(numericUpDown1.Text, out n);
                int.TryParse(numericUpDown2.Text, out k);
                label9.Text = "Всего существует " + Convert.ToString(Math.Pow(2, Math.Pow(2, k) * n)) + " различных матриц с данными параметрами";
                int chbed = 0;
                int chsys = 0;
                int chlin = 0;
                int chkv = 0;
                Random rnd = new Random();
                int[,] a = new int[Func.A, Func.B];
                progressBar1.Maximum = Convert.ToInt32(textBox3.Text);
                progressBar1.Value = 0;
                for (int test = 0; test < Convert.ToInt32(textBox3.Text); test++)
                {
                    progressBar1.Value += 1;
                    for (int i = 0; i <= (n - 1); i++)
                        for (int j = 0; j <= Func.stepen(k) - 1; j++)
                        {
                            a[j, i] = rnd.Next(2);
                        }

                    if (Func.testinectivnost(a, k, n) == 0) chbed++;
                    else if (Func.systematic(a, k, n) == 1)
                    {
                        chsys++;
                        if (Func.linerian(a, k, n) == 1) chlin++;
                        if (Func.kvazilinerian(a, k, n) == 1) chkv++;
                    }

                }
                textBox4.Text = Convert.ToString(Convert.ToInt32(textBox3.Text) - chsys);
                label10.Text = Convert.ToInt16((Convert.ToInt32(textBox3.Text) - chsys) / Convert.ToDouble(textBox3.Text) * 100) + " %";                
                textBox5.Text = Convert.ToString(chsys);
                label11.Text = Convert.ToInt16(chsys / Convert.ToDouble(textBox3.Text) * 100) + " %";
                textBox6.Text = Convert.ToString(chlin);
                label12.Text = Convert.ToInt16(chlin / Convert.ToDouble(textBox3.Text) * 100) + " %";                
                textBox7.Text = Convert.ToString(chkv);
                label13.Text = Convert.ToInt16(chkv / Convert.ToDouble(textBox3.Text) * 100) + " %";                

            }
        }        
        private void button2_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(numericUpDown1.Text);
            int k = Convert.ToInt32(numericUpDown2.Text); 
            if (show)
            {
                pictureBox1.BringToFront();
                pictureBox1.ImageLocation = @"Resources\" + numericUpDown1.Value.ToString() + "x" + numericUpDown2.Value.ToString() + ".jpg";
                if (k > n) pictureBox1.ImageLocation = @"Resources\9x9.jpg";
                button2.Text = "Скрыть график";
                show = false;
            }
            else
            {                
                pictureBox1.SendToBack();
                button2.Text = "Показать график";
                show = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(numericUpDown1.Text);
            int k = Convert.ToInt32(numericUpDown2.Text);
            Process p1 = new Process();
            p1.StartInfo.UseShellExecute = true;
            p1.StartInfo.RedirectStandardOutput = false;          
            p1.StartInfo.FileName = @"Resources\" + numericUpDown1.Value.ToString() + "x" + numericUpDown2.Value.ToString()+".jpg";
            if (k > n) p1.StartInfo.FileName = @"Resources\9x9.jpg";
            p1.Start();
        }
    }
}
