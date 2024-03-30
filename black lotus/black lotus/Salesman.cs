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
    public partial class Salesman : Form
    {
        dbConnection.WebService1 getInfo = new dbConnection.WebService1();
        public Salesman()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = textBox2.Text.ToString();
            String tp = textBox3.Text.ToString();
            String age = textBox4.Text.ToString();
            String addrs = textBox5.Text.ToString();
            String pass = textBox6.Text.ToString();
            String conpass = textBox7.Text.ToString();

            if (name.Equals("") || tp.Equals("") || age.Equals("") || addrs.Equals("") || pass.Equals("") || conpass.Equals("")){
                MessageBox.Show("Required fields are empty..!");
            }
            else if (!pass.Equals(conpass))
            {
                MessageBox.Show("Passwords are missmatch..!");
                textBox6.Text = "";
                textBox7.Text = "";
                textBox6.Focus();
            }
            else
            {
                if (getInfo.addSalesman(name, tp, age, addrs))
                {
                    MessageBox.Show("details added!");
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    homeAdmin homeAdmin = new homeAdmin();
                    homeAdmin.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("details not added! try again!");
                }

                if (getInfo.login(name,pass))
                {

                }
                else
                {
                    MessageBox.Show("login details not added!");
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.textBox3.MaxLength = 10;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (!button3.Focused || !button2.Focused)
            {
                
                if (textBox2.Text.Equals(""))
                {
                    MessageBox.Show("Name is required!");
                    textBox2.Focus();
                }
                
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (!button3.Focused || !button2.Focused)
            {

                if (textBox3.Text.Equals(""))
                {
                    MessageBox.Show("Mobile number is required!");
                    textBox3.Focus();
                }

            }
            
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (!button3.Focused || !button2.Focused)
            {

                if (textBox4.Text.Equals(""))
                {
                    MessageBox.Show("Age is required!");
                    textBox4.Focus();
                }

            }
            
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (!button3.Focused || !button2.Focused)
            {

                if (textBox5.Text.Equals(""))
                {
                    MessageBox.Show("Address is required!");
                    textBox5.Focus();
                }

            }
            
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (!button3.Focused || !button2.Focused)
            {

                if (textBox6.Text.Equals(""))
                {
                    MessageBox.Show("Password is required!");
                    textBox6.Focus();
                }

            }
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            this.textBox4.MaxLength = 2;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            this.textBox6.MaxLength = 8;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.textBox2.MaxLength = 20;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            this.textBox5.MaxLength = 40;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            homeAdmin homeAdmin = new homeAdmin();
            homeAdmin.Show();
            this.Hide();
        }

        private void Salesman_Load(object sender, EventArgs e)
        {
            button3.Focus();
            button2.Focus();
        }
    }
}
