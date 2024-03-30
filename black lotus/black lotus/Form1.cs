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
    public partial class Form1 : Form
    {
        dbConnection.WebService1 getInfo = new dbConnection.WebService1();
        public HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*if (getInfo.createConn())
            {
                MessageBox.Show("Database Connected...");
            }
            else
            {
                MessageBox.Show("Database not Connected...");
            }*/
            webSetting();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text;
            String pass = textBox2.Text;

            try
            {
                if (name.Equals("") || pass.Equals(""))
                {
                    MessageBox.Show("can not login with empty fields..!");
                }
                else
                {
                    getLoginDet();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
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

        private void getLoginDet()
        {
            try
            {
                HttpResponseMessage msg = client.GetAsync("retrevwLogin").Result;
                string uj = msg.Content.ReadAsStringAsync().Result;
                //MessageBox.Show(uj);
                int rCount = stringSplit(uj).Rows.Count;
                if (rCount > 0)
                {
                    for (int count = 0; count < rCount; count++)
                    {
                        String user = stringSplit(uj).Rows[count][1].ToString();
                        String pass = stringSplit(uj).Rows[count][2].ToString();

                        if (textBox2.Text.Equals(user))
                        {
                            if (textBox1.Text.Equals(pass))
                            {
                                if (stringSplit(uj).Rows[count][3].ToString().Equals("1"))
                                {
                                    textBox1.Text = "";
                                    textBox2.Text = "";
                                    this.Hide();
                                    homeSalesMan homeSalesMan = new homeSalesMan();
                                    homeSalesMan.Show();
                                    break;
                                }
                                else if (stringSplit(uj).Rows[count][3].ToString().Equals("0"))
                                {
                                    textBox1.Text = "";
                                    textBox2.Text = "";
                                    this.Hide();
                                    homeAdmin homeAdmin = new homeAdmin();
                                    homeAdmin.Show();
                                    break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Password..!");
                            }
                        }
                        else
                        {
                            //MessageBox.Show("Incorrect Username..!");
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
    }
}
