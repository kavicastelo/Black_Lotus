using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace black_lotus
{
    public partial class Purchase : Form
    {
        dbConnection.WebService1 getInfo = new dbConnection.WebService1();

        public Purchase()
        {
            InitializeComponent();
        }

        string newAddr = "";

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.SelectedItem = 0;
            comboBox2.SelectedItem = 0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Purchase_Load(object sender, EventArgs e)
        {
            button3.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String cid = textBox2.Text.ToString();
            String cname = textBox3.Text.ToString();
            String ctp = textBox1.Text.ToString();
            String caddr = textBox4.Text.ToString();
            String fcat = comboBox1.SelectedItem.ToString();
            String fid = comboBox2.SelectedItem.ToString();
            String fname = textBox5.Text.ToString();
            String qunt = textBox6.Text.ToString();
            String tot = textBox7.Text.ToString();

            if (ctp.Equals("") || qunt.Equals("") || tot.Equals(""))
            {
                MessageBox.Show("Required fields are empty..!");
            }
            else
            {
                if (getInfo.sellFlowers(cid,cname,ctp,caddr,fid,fcat,fname,qunt,tot))
                {
                    MessageBox.Show("Purches added..!");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    comboBox1.SelectedItem = 0;
                    comboBox2.SelectedItem = 0;
                }
                else
                {
                    MessageBox.Show("Sell failed..! try again!");
                }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!button3.Focused)
            {

                if (textBox1.Text.Equals(""))
                {
                    MessageBox.Show("Enter customer mobile number");
                    textBox1.Focus();
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            newAddr = Microsoft.VisualBasic.Interaction.InputBox("Enter new Address", "New Address", "0");
            textBox4.Text = newAddr;
        }
    }
}
