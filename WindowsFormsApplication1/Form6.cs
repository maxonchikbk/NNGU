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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 2;
            dataGridView1.RowCount = 2;
            //for (int i = 0; i <= (n - 1); i++)
            //    for (int j = 0; j <= stepen(k) - 1; j++)
            //    {                    
            dataGridView1.Rows[1].Cells[1].Value = Form2.a[1, 1];
            //    }
            
        }
    }
}
