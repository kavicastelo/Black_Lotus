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
    public partial class homeSalesMan : Form
    {
        public homeSalesMan()
        {
            InitializeComponent();
        }

        private void addFlowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Flowers flowers = new Flowers();
            flowers.Show();
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.Show();
        }

        private void saleFlowersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this function not working. because time was runnig out. I do all another function within 3 days ^-^");
            Purchase purchase = new Purchase();
            purchase.Show();
            this.Hide();
        }

        private void searchFlowersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchFlowers searchFlowers = new searchFlowers();
            searchFlowers.Show();
        }

        private void searchCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchCustomers searchCustomers = new searchCustomers();
            searchCustomers.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewCustomer viewCustomer = new viewCustomer();
            viewCustomer.Show();
        }
    }
}
