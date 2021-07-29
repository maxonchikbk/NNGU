using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {        
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            int n,k,l;
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
                    else if (Func.systematic(a, k, n) != 1)
                    {
                        chsys++;
                        if (Func.linerian(a, k, n) == 1) chlin++;
                        if (Func.kvazilinerian(a, k, n) == 1) chkv++;
                    }

                }
                textBox4.Text = Convert.ToString(chbed);
                textBox5.Text = Convert.ToString(chsys);
                textBox6.Text = Convert.ToString(chlin);
                textBox7.Text = Convert.ToString(chkv);
                pictureBox1.Visible = false;
                button3.Visible = false;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;            
            int n= Convert.ToInt32(numericUpDown1.Text);
            int k= Convert.ToInt32(numericUpDown2.Text);            
            if ((n >= 7) && (k==1)) pictureBox1.ImageLocation = "..\\Resources\\7х1.jpg";
            else pictureBox1.ImageLocation ="..\\Resources\\"+numericUpDown1.Text+"х"+numericUpDown2.Text+".jpg";
            if (k > n) pictureBox1.ImageLocation = "..\\Resources\\1х2.jpg";
            button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            button3.Visible = false;
        }
    }
}
