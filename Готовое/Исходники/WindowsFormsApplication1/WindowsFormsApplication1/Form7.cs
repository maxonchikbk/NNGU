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
    public partial class Form7 : Form
    {
        String temps = "";
        int k = Func.K;
        int n = Func.N;        
        public Form7()
        {
            InitializeComponent();
            for (int i = 1; i < Func.sh; i++)
            {
                temps = temps + (Func.syscount[i] + 1);                
                if ((i / k) * k == i) 
                { 
                    comboBox1.Items.Add(temps); 
                    temps = ""; 
                }             
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

            //формируем заголовок схемы кодирования
            for (int i = 0; i < k; i++)
                temps = temps + "x" + (i+1);
            temps = temps + "->";
            for (int i = 0; i < n; i++)
                temps = temps + "y" + (i+1);
            textBox1.Text = temps;
            temps = "";
            //формируем часть схемы кодирования для систематических столбцов
            for (int i = 0; i < k; i++)
            {
                textBox2.Text = comboBox1.Text[i].ToString();
                Func.syscountPK[i] = Convert.ToInt16(textBox2.Text) - 1;               
                temps = temps + "y" + comboBox1.Text[i] + "=x" + (i + 1) + "  ";
                textBox1.Text += Environment.NewLine + temps;
                temps = "";
            }
            
            //копируем исходную матрицу кода для вычислений в copya
            int[,] copya = new int[Func.A, Func.B];
            for (int i = 0; i < Func.stepen(k); i++)
                for (int j = 0; j < n; j++)
                    copya[i, j] = Func.a[i, j];


            //преобразование матрицы для получения бул функций

            for (int i = 0; i < n; i++)
            {
                //если систематический столбец пропускаем его
                bool flag = false;
                for (int j = 0; j < k; j++)
                    if (i == Func.syscountPK[j]) flag = true;
                if (flag == true) continue;
                flag = false;

                //если не систематический то идем по строкам i-го столбца
                for (int j = 0; j < Func.stepen(k); j++)
                {
                    if (Func.countone(copya, j) == 0)
                    {
                        for (int z = 0; z < Func.stepen(k); z++)
                            if (z != j) copya[z, i] = Func.addmod2(copya[z, i], copya[j, i]);
                        continue;
                    }
                    Func.spisok(copya, j);
                    //берем j-ую строку и смотрим на какие влияет
                    for (int z = 0; z < Func.stepen(k); z++)
                    {
                        if (z == j) continue;
                        flag = true;
                        for (int l = 0; l < Func.countone(copya, j); l++)
                            if (copya[z, Func.onepos[l]] != 1) flag = false;
                        if (flag == true) copya[z, i] = Func.addmod2(copya[z, i], copya[j, i]);
                    }
                }
            }
            // печать результатов
            temps = "";
            for (int i = 0; i < n; i++)
            {
                //если систематический то пропускаем, их уже печатали
                bool flag = true;
                for (int j = 0; j < k; j++)                                    
                    if (i == Func.syscountPK[j]) flag = false;
                
                if (flag == false) continue;

                //значит текущий i не систематический
                temps = temps + "y" + (i + 1) + "=";
                for (int j = 0; j < Func.stepen(k); j++)
                {                 
                    if (copya[j, i] == 0) continue;                    
                    if (Func.countone(copya, j) == 0) temps = temps + "+1";                
                    else
                    {
                        Func.spisok(copya, j);
                        temps = temps + "+";
                        for (int t = 0; t < Func.countone(copya, j); t++)
                        {
                            //модифицировал
                            int position = 0;
                            for (int l = 0; l < k; l++)
                            {                                                               
                                if ((Func.syscountPK[l]) == (Func.onepos[t])) 
                                {                                 
                                    position = l+1;
                                    break;
                                }
                            }
                            temps = temps + "x" + position;
                        }                     
                    }
                }
                flag = false;
                for (int z = 0; z < Func.stepen(k); z++)
                    if (copya[z, i] == 1) flag = true;
                if (flag == false) temps = temps + "0";
                temps = temps + "   ";
                textBox1.Text += Environment.NewLine + temps;
                //Memo3->Text=Memo3->Text+temps;
                temps = "";
            }
        }
    }
}
