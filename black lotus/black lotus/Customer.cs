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
    public partial class Customer : Form
    {
        dbConnection.WebService1 getInfo = new dbConnection.WebService1();
        public Customer()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            button2.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = textBox2.Text.ToString();
            String tp = textBox3.Text.ToString();
            String email = textBox4.Text.ToString();
            String addr = textBox5.Text.ToString();

            if (name.Equals("") || tp.Equals("") || email.Equals("") || addr.Equals(""))
            {
                MessageBox.Show("Required fields are empty..!");
            }
            else
            {
                if (getInfo.addcustomer(name, tp, email, addr))
                {
                    MessageBox.Show("new customer added successfully..!");
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    
                }
                else
                {
                    MessageBox.Show("not added..!");
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (!button2.Focused)
            {

                if (textBox2.Text.Equals(""))
                {
                    MessageBox.Show("Required Customer Name..!");
                    textBox2.Focus();
                }

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (!button2.Focused)
            {

                if (textBox3.Text.Equals(""))
                {
                    MessageBox.Show("Required Customer Mobile Number..!");
                    textBox3.Focus();
                }

            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (!button2.Focused)
            {

                if (textBox4.Text.Equals(""))
                {
                    MessageBox.Show("Required Customer Email..!");
                    textBox4.Focus();
                }

            }
        }
    }
}
