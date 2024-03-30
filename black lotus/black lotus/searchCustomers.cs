using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace black_lotus
{
    public partial class searchCustomers : Form
    {
        public dbConnection.WebService1 getInfo = new dbConnection.WebService1();
        public HttpClient client = new HttpClient();

        public searchCustomers()
        {
            InitializeComponent();
        }

       
        private void webSetting()
        {
            client.BaseAddress = new Uri("https://localhost:44367/WebService1.asmx/");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String id = textBox1.Text.ToString();
            try
            {
                HttpResponseMessage msg = client.GetAsync("retriveCustomerData?id="+id+"").Result;
                string uj = msg.Content.ReadAsStringAsync().Result;
               // MessageBox.Show(uj);
                dataGridView1.DataSource = stringSplit(uj);
                dataGridView1.Columns["CID"].HeaderText = "Customer ID";
                dataGridView1.Columns["name"].HeaderText = "Customer Name";
                dataGridView1.Columns["tp"].HeaderText = "Customer Contact";
                dataGridView1.Columns["email"].HeaderText = "Customer Email";
                dataGridView1.Columns["addr"].HeaderText = "Customer Address";
                dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            }
           
            catch(Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }

        }

        private DataTable stringSplit(string userJason)
        {
            string[] json = userJason.Split('>');
            string[] finalJason = json[2].Split('<');
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(finalJason[0]);
            return dt;

        }

     
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void searchCustomers_Load(object sender, EventArgs e)
        {
            webSetting();
        }
    }
}
