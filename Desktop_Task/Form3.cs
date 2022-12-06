using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Task
{
    public partial class Form3 : Form
    {
        public int idTask;
        public string title;
        public string description;
        public DateTime end_date;
        public DateTime start_date;
        public string priority_level;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            txtId.Text = idTask.ToString();
            txtTitle.Text = title;
            txtDescription.Text = description;
            dtpStart.Value = start_date;
            dtpEnd.Value = end_date;
           txtPriority.Text = priority_level;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        
        }
    }
}
