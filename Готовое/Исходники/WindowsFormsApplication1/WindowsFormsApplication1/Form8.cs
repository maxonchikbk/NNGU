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
    public partial class Form8 : Form
    {
        int k = 0, n = 0;
        int studentfalse = 0;
        void generacia()
        {
            textBox5.Text = "" + (Func.kolzad-1);
            Random rnd = new Random();
            k = rnd.Next(1, 3);
            n = rnd.Next(k, 8);
            do
            {
                dataGridView1.ColumnCount = n;
                dataGridView1.RowCount = Func.stepen(k);
                for (int i = 0; i <= (n - 1); i++)
                    for (int j = 0; j <= Func.stepen(k) - 1; j++)
                    {
                        dataGridView1.Rows[j].Cells[i].Value = rnd.Next(2);
                        Func.a[j, i] = Convert.ToInt16(dataGridView1.Rows[j].Cells[i].Value);
                    }
            }
            while (Func.systematic(Func.a, k, n) != 1);
        }
        void generaciaob()
        {
            textBox5.Text = "" + (Func.kolzad - 1);
            Random rnd = new Random();
            k = rnd.Next(1, 3);
            n = rnd.Next(k, 8);            
                dataGridView1.ColumnCount = n;
                dataGridView1.RowCount = Func.stepen(k);
                for (int i = 0; i <= (n - 1); i++)
                    for (int j = 0; j <= Func.stepen(k) - 1; j++)
                    {
                        dataGridView1.Rows[j].Cells[i].Value = rnd.Next(2);
                        Func.a[j, i] = Convert.ToInt16(dataGridView1.Rows[j].Cells[i].Value);
                    }           
        }
        void generaciank(int n1,int k1)
        {
            textBox5.Text = "" + (Func.kolzad - 1);
            Random rnd = new Random();         
            do
            {
                dataGridView1.ColumnCount = n1;
                dataGridView1.RowCount = Func.stepen(k1);
                for (int i = 0; i <= (n1 - 1); i++)
                    for (int j = 0; j <= Func.stepen(k1) - 1; j++)
                    {
                        dataGridView1.Rows[j].Cells[i].Value = rnd.Next(2);
                        Func.a[j, i] = Convert.ToInt16(dataGridView1.Rows[j].Cells[i].Value);
                    }
            }
            while (Func.systematic(Func.a, k1, n1) != 1);
        }
        public Form8()
        {
            InitializeComponent();
            generacia();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            switch (Func.zadanie)
            {
                case 1: panel1.BringToFront(); button1.Enabled = false; break;
                case 2: panel2.BringToFront(); break;
                case 3: panel3.BringToFront(); generaciaob(); break;
                case 4: panel1.BringToFront(); 
                    do
                        generacia();
                    while (Func.codelenght(Func.a, k, n) != Func.length);
                    button1.Enabled = false; break;
                case 5: panel3.BringToFront();
                    generaciank(Func.N, Func.K);
                    break;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            switch (Func.zadanie)
            {
                case 1:                  
                        if (radioButton1.Checked)
                            if (Func.linerian(Func.a, k, n) != 1)
                            { studentfalse++; MessageBox.Show("Неверно"); }
                            else
                            {
                                MessageBox.Show("Верно");
                                generacia();
                                Func.kolzad--;
                            }
                        if (radioButton2.Checked)
                            if ((Func.linerian(Func.a, k, n) == 1) || (Func.kvazilinerian(Func.a, k, n) != 1))
                            { studentfalse++; MessageBox.Show("Неверно"); }
                            else
                            {
                                MessageBox.Show("Верно");
                                generacia();
                                Func.kolzad--;
                            }
                        if (radioButton3.Checked)
                            if ((Func.linerian(Func.a, k, n) == 1) || (Func.kvazilinerian(Func.a, k, n) == 1))
                            { studentfalse++; MessageBox.Show("Неверно"); }
                            else
                            {
                                MessageBox.Show("Верно");
                                generacia();
                                Func.kolzad--;
                            }                    
                    break;

                case 2:
                    textBox6.Text = "";                    
                    int flag = 1;
                    while (flag == 1)
                    {
                        flag = 0;
                        for (int i = 1; i < Func.sh - 1; i++)
                        {
                            if (Func.syscount[i] > Func.syscount[i + 1])
                            {
                                int a = Func.syscount[i];
                                Func.syscount[i] = Func.syscount[i + 1];
                                Func.syscount[i + 1] = a;
                                flag = 1;
                            }
                        }
                    }
                    flag = 1;
                    for (int i = 1; i < Func.sh; i++)
                    {
                        for (int j = 1; j <= i; j++) if (Func.syscount[i] == Func.syscount[j] && i != j) flag = 0;
                        if (flag == 1)
                        {
                            textBox6.Text = textBox6.Text + (Func.syscount[i] + 1);
                            textBox6.Text = textBox6.Text + ",";
                        }
                        flag = 1;
                    }
                    if (((textBox1.TextLength!=textBox6.TextLength-1)||(!textBox6.Text.Contains(textBox1.Text)))|| textBox1.Text=="")
                    { studentfalse++; MessageBox.Show("Заполнено неверно");
                    button2.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Верно");
                        textBox1.Text = "";
                        button2.Visible = false;
                        generacia();
                        Func.kolzad--;
                    }
                    break;
                case 3:
                    int o1, o2, o3;
                    if (!int.TryParse(textBox2.Text, out o1) || !int.TryParse(textBox3.Text, out o2) || !int.TryParse(textBox4.Text, out o3)) MessageBox.Show("ошибка ввода");
                    else
                    {
                        if (Func.codelenght(Func.a, k, n) != Convert.ToInt16(textBox2.Text)) MessageBox.Show("Неправильное кодовое расстояние");
                        if ((Func.codelenght(Func.a, k, n) - 1) != Convert.ToInt16(textBox3.Text)) MessageBox.Show("Неправильное число замечаемых ошибок");
                        if (((Func.codelenght(Func.a, k, n) + 1) / 2 - 1) != Convert.ToInt16(textBox4.Text)) MessageBox.Show("Неправильное число исправляемых ошибок");
                        if (Func.codelenght(Func.a, k, n) == Convert.ToInt16(textBox2.Text) && (Func.codelenght(Func.a, k, n) - 1) == Convert.ToInt16(textBox3.Text) && ((Func.codelenght(Func.a, k, n) + 1) / 2 - 1) == Convert.ToInt16(textBox4.Text))
                        {
                            MessageBox.Show("Верно");
                            generaciaob();
                            Func.kolzad--;
                        }
                        else studentfalse++;
                    }
                    break;
                case 4:
                    
                    if (radioButton1.Checked)
                        if (Func.linerian(Func.a, k, n) != 1)
                        { studentfalse++; MessageBox.Show("Неверно"); }
                        else
                        {
                            MessageBox.Show("Верно");
                            do
                                generacia();
                            while (Func.codelenght(Func.a, k, n) != Func.length);
                            Func.kolzad--;
                        }
                    if (radioButton2.Checked)
                        if ((Func.linerian(Func.a, k, n) == 1) || (Func.kvazilinerian(Func.a, k, n) != 1))
                        { studentfalse++; MessageBox.Show("Неверно"); }
                        else
                        {
                            MessageBox.Show("Верно");
                            do
                                generacia();
                            while (Func.codelenght(Func.a, k, n) != Func.length);
                            Func.kolzad--;
                        }
                    if (radioButton3.Checked)
                        if ((Func.linerian(Func.a, k, n) == 1) || (Func.kvazilinerian(Func.a, k, n) == 1))
                        { studentfalse++; MessageBox.Show("Неверно"); }
                        else
                        {
                            MessageBox.Show("Верно");
                            do
                                generacia();
                            while (Func.codelenght(Func.a, k, n) != Func.length);
                            Func.kolzad--;
                        }
                    break;
                case 5:                    
                     if (!int.TryParse(textBox2.Text, out o1) || !int.TryParse(textBox3.Text, out o2) || !int.TryParse(textBox4.Text, out o3)) MessageBox.Show("ошибка ввода");
                     else
                     {
                         if (Func.codelenght(Func.a, k, n) != Convert.ToInt16(textBox2.Text)) MessageBox.Show("Неправильное кодовое расстояние");
                         if ((Func.codelenght(Func.a, k, n) - 1) != Convert.ToInt16(textBox3.Text)) MessageBox.Show("Неправильное число замечаемых ошибок");
                         if (((Func.codelenght(Func.a, k, n) + 1) / 2 - 1) != Convert.ToInt16(textBox4.Text)) MessageBox.Show("Неправильное число исправляемых ошибок");
                         if (Func.codelenght(Func.a, k, n) == Convert.ToInt16(textBox2.Text) && (Func.codelenght(Func.a, k, n) - 1) == Convert.ToInt16(textBox3.Text) && ((Func.codelenght(Func.a, k, n) + 1) / 2 - 1) == Convert.ToInt16(textBox4.Text))
                         {
                             MessageBox.Show("Верно");
                             generaciank(Func.N, Func.K);
                             Func.kolzad--;
                         }
                         else studentfalse++;
                     }
                    break;
            }
            if (Func.kolzad == 0)
            {
                MessageBox.Show("Допущено ошибок: " + studentfalse);
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
            int flag = 1;
            while (flag == 1)
            {
                flag = 0;
                for (int i = 1; i < Func.sh - 1; i++)
                {
                    if (Func.syscount[i] > Func.syscount[i + 1])
                    {
                        int a = Func.syscount[i];
                        Func.syscount[i] = Func.syscount[i + 1];
                        Func.syscount[i + 1] = a;
                        flag = 1;
                    }
                }
            }
            flag = 1;
            for (int i = 1; i < Func.sh; i++)
            {
                for (int j = 1; j <= i; j++) if (Func.syscount[i] == Func.syscount[j] && i != j) flag = 0;
                if (flag == 1)
                {
                    textBox6.Text = textBox6.Text + (Func.syscount[i] + 1);
                    textBox6.Text = textBox6.Text + ",";
                }
                flag = 1;
            }
            MessageBox.Show(textBox6.Text);
        }
    }
}
