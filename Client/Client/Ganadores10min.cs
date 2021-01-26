using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Ganadores10min : Form
    {
        string Lista;
        public Ganadores10min()
        {
            InitializeComponent();
        }
       

        public void setLista(string Lista2)
        {
            this.Lista = Lista2;
        }

        private void Ganadores10min_Load(object sender, EventArgs e)
        {
            string[] vector = new string[5];

            vector= Lista.Split(' ');

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = 5;

            int i = 0;
            while (i < vector.Length)
            {
                dataGridView1.Rows[0].Cells[i].Value = vector[i];
                i++;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
