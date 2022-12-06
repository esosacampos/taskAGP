using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Task
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            string respuesta = await GetHttp();
            List<Models.Request.TaskRequest> lst = JsonConvert.DeserializeObject<List<Models.Request.TaskRequest>>(respuesta);
            dataGridView1.DataSource = lst;
        }

        private async Task<string> GetHttp()
        {
            WebRequest oRequest = WebRequest.Create("https://localhost:44340/api/Task");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        private async Task<string> GetHttp(int pId)
        {
            WebRequest oRequest = WebRequest.Create("https://localhost:44340/api/Task?pId=" + pId);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int pId = Convert.ToInt32(DataGridViewUtils.GetValorCelda(dataGridView1, 0));
            string respuesta = await GetHttp(pId);
            List<Models.Request.TaskRequest> lst = JsonConvert.DeserializeObject<List<Models.Request.TaskRequest>>(respuesta);

            Form3 frm = new Form3();
           

            foreach (var item in lst)
            {
                frm.idTask = item.idTask;
                frm.title = item.title;
                frm.description = item.description;
                frm.start_date = item.start_date;
                frm.end_date = item.end_date;
                frm.priority_level = item.priority_level;
            }
            frm.Show();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Close();
        }
    }

    public class DataGridViewUtils
    {
        public static string GetValorCelda(DataGridView dgv, int num)
        {
            string valor = "";

            valor = dgv.Rows[dgv.CurrentRow.Index].Cells[num].Value.ToString();

            return valor;
        }
    }
}
