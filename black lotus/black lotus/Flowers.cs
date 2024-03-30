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
    public partial class Flowers : Form
    {
        dbConnection.WebService1 getInfo = new dbConnection.WebService1();
        public HttpClient client = new HttpClient();

        public Flowers()
        {
            InitializeComponent();
        }

        private void webSetting()
        {
            client.BaseAddress = new Uri("https://localhost:44367/WebService1.asmx/");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (!button4.Focused || !button5.Focused)
            {

                if (textBox4.Text.Equals(""))
                {
                    MessageBox.Show("Required Flower Name..!");
                    textBox4.Focus();
                }

            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (!button4.Focused || !button5.Focused)
            {

                if (textBox2.Text.Equals(""))
                {
                    MessageBox.Show("Required Quantity..!");
                    textBox2.Focus();
                }

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = textBox4.Text.ToString();
            String qunt = textBox2.Text.ToString();
            String ppu = textBox1.Text.ToString();
            String type = comboBox1.SelectedItem.ToString();

            if(name.Equals("")||qunt.Equals("")||ppu.Equals("")||type.Equals("-- SELECT CATEGORY --"))
            {
                MessageBox.Show("Required fields are empty..!");
            }
            else
            {
                if (getInfo.addFlowers(type, name, qunt, ppu))
                {
                    MessageBox.Show("new flower added..!");
                    textBox4.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    comboBox1.SelectedIndex = 0;

                    getFlowerView();
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            searchFlowers searchFlowers = new searchFlowers();
            searchFlowers.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String name = textBox4.Text.ToString();
            String qunt = textBox2.Text.ToString();
            String ppu = textBox1.Text.ToString();
            String type = comboBox1.SelectedItem.ToString();
            String fid = id.Text.ToString();

            if (name.Equals("") || qunt.Equals("") || ppu.Equals("") || type.Equals("-- SELECT CATEGORY --")||fid.Equals(""))
            {
                MessageBox.Show("Can not update this moment..!");
            }
            else
            {
                try
                {
                    if (getInfo.updateFlowers(type,name,qunt,ppu,fid))
                    {
                        MessageBox.Show("Updated Successfully..!");
                        textBox4.Text = "";
                        textBox1.Text = "";
                        textBox2.Text = "";
                        comboBox1.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("Not Updated..!");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private DataTable stringSplit(string userJason)
        {
            string[] json = userJason.Split('>');
            string[] finalJason = json[2].Split('<');
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(finalJason[0]);
            return dt;

        }

        private void Flowers_Load(object sender, EventArgs e)
        {
            button4.Focus();
            button5.Focus();
            webSetting();
            getDataToCombo();
            getFlowerView();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                id.Text = row.Cells[0].Value.ToString();
                textBox4.Text = row.Cells[2].Value.ToString();
                textBox2.Text = row.Cells[3].Value.ToString();
                textBox1.Text = row.Cells[4].Value.ToString();
            }
        }

        private void getDataToCombo()
        {
            try
            {
                HttpResponseMessage msg = client.GetAsync("viewCustomers").Result;
                string uj = msg.Content.ReadAsStringAsync().Result;
                //MessageBox.Show(uj);
                int rCount = stringSplit(uj).Rows.Count;
                if (rCount > 0)
                {
                    for(int count = 0; count < rCount; count++)
                    {
                        comboBox1.Items.Clear();
                        comboBox1.Items.Add(stringSplit(uj).Rows[count][1].ToString());
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void getFlowerView()
        {
            try
            {
                HttpResponseMessage msg = client.GetAsync("retriveFlowerDataToAdd").Result;
                string uj = msg.Content.ReadAsStringAsync().Result;
                //MessageBox.Show(uj);
                dataGridView1.DataSource = stringSplit(uj);
                dataGridView1.Columns["FID"].HeaderText = "Flower ID";
                dataGridView1.Columns["category"].HeaderText = "Category";
                dataGridView1.Columns["name"].HeaderText = "Flower Name";
                dataGridView1.Columns["qunt"].HeaderText = "Quanty";
                dataGridView1.Columns["ppu"].HeaderText = "Price per Unit";
                dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
    }
}
