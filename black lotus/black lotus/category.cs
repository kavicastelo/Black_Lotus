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
    public partial class category : Form
    {
        dbConnection.WebService1 getInfo = new dbConnection.WebService1();
        public HttpClient client = new HttpClient();

        public category()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {
                if (getInfo.deleteCat(textBox1.Text.ToString()))
                {
                    MessageBox.Show(textBox1.Text + " category is deleted..!");
                }
                else
                {
                    MessageBox.Show("not Deleted..! try again!");
                }

                if (getInfo.deleteCatfromFlow(textBox1.Text.ToString()))
                {
                    //MessageBox.Show(textBox1.Text + " category is deleted..!");
                }
                else
                {
                    MessageBox.Show("flower tbt not Deleted..! try again!");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Category name");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {
                if (getInfo.addcategory(textBox1.Text.ToString()))
                {
                    MessageBox.Show("Added Successfully..!");
                    textBox1.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Please Enter Category name");
            }
        }

        private DataTable stringSplit(string userJason)
        {
            string[] json = userJason.Split('>');
            string[] finalJason = json[2].Split('<');
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(finalJason[0]);
            return dt;

        }

        private void webSetting()
        {
            client.BaseAddress = new Uri("https://localhost:44367/WebService1.asmx/");
        }

        private void getCatView()
        {
            try
            {
                HttpResponseMessage msg = client.GetAsync("viewCat").Result;
                string uj = msg.Content.ReadAsStringAsync().Result;
                //MessageBox.Show(uj);
                dataGridView1.DataSource = stringSplit(uj);
                dataGridView1.Columns["cat_id"].HeaderText = "Category ID";
                dataGridView1.Columns["category"].HeaderText = "Category";
                dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void category_Load(object sender, EventArgs e)
        {
            webSetting();
            getCatView();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
            }
        }
    }
}
