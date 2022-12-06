using Desktop_Task.Models.Request;
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
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Desktop_Task
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:44340/api/Task";

            TaskRequest oTask = new TaskRequest();
            oTask.title = txtTitle.Text;
            oTask.description = txtDescription.Text;
            oTask.start_date = dtpStart.Value;
            oTask.end_date = dtpEnd.Value;
            oTask.priority_level = cbPriority.Text;
            
            string resultado = Send<TaskRequest>(url, oTask, "POST");
            MessageBox.Show(resultado);



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public string Send<T>(string url, T objectRequest, string method = "POST")
        {
            string result = "";
            try
            {
                

                JavaScriptSerializer js = new JavaScriptSerializer();

                //serializamos el objeto
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(objectRequest);

                //peticion
                WebRequest request = WebRequest.Create(url);
                //headers
                request.Method = method;
                request.PreAuthenticate = true;
                request.ContentType = "application/json;charset=utf-8'";
                request.Timeout = 10000; //esto es opcional

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                
            }
            catch (Exception e)
            {
                result = e.Message; 

            }

            return result;
        }

        private void cbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            
        }
    }
}

