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
    public partial class viewPurchase : Form
    {
        dbConnection.WebService1 getInfo = new dbConnection.WebService1();
        public HttpClient client = new HttpClient();

        public viewPurchase()
        {
            InitializeComponent();
        }

        private void viewPurchase_Load(object sender, EventArgs e)
        {
            webSetting();

            try
            {
                HttpResponseMessage msg = client.GetAsync("viewSalesmen").Result;
                string uj = msg.Content.ReadAsStringAsync().Result;
                //MessageBox.Show(uj);
                dataGridView1.DataSource = stringSplit(uj);
                dataGridView1.Columns["sellID"].HeaderText = "Purches ID";
                dataGridView1.Columns["cid"].HeaderText = "Customer ID";
                dataGridView1.Columns["c_name"].HeaderText = "Customer Name";
                dataGridView1.Columns["c_tp"].HeaderText = "Customer Contact";
                dataGridView1.Columns["c_addr"].HeaderText = "Customer Address";
                dataGridView1.Columns["FID"].HeaderText = "Flower ID";
                dataGridView1.Columns["f_cat"].HeaderText = "Category";
                dataGridView1.Columns["f_name"].HeaderText = "Flower Name";
                dataGridView1.Columns["qunt"].HeaderText = "Quantity";
                dataGridView1.Columns["tot"].HeaderText = "Total";
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
