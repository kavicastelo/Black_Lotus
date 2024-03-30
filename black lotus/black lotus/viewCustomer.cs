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
    public partial class viewCustomer : Form
    {
        dbConnection.WebService1 getInfo = new dbConnection.WebService1();
        public HttpClient client = new HttpClient();

        public viewCustomer()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void viewCustomer_Load(object sender, EventArgs e)
        {
            webSetting();

            try
            {
                HttpResponseMessage msg = client.GetAsync("viewCustomers").Result;
                string uj = msg.Content.ReadAsStringAsync().Result;
                //MessageBox.Show(uj);
                dataGridView1.DataSource = stringSplit(uj);
                dataGridView1.Columns["CID"].HeaderText = "Customer ID";
                dataGridView1.Columns["name"].HeaderText = "Customer Name";
                dataGridView1.Columns["tp"].HeaderText = "Customer Contact";
                dataGridView1.Columns["email"].HeaderText = "Email";
                dataGridView1.Columns["addr"].HeaderText = "Address";
                dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void webSetting()
        {
            client.BaseAddress = new Uri("https://localhost:44367/WebService1.asmx/");
        }

        private DataTable stringSplit(string userJason)
        {
            string[] json = userJason.Split('>');
            string[] finalJason = json[2].Split('<');
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(finalJason[0]);
            return dt;

        }
    }
}
