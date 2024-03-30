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
    public partial class homeAdmin : Form
    {
        public homeAdmin()
        {
            InitializeComponent();
        }

        private void addFlowerToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Flowers flowers = new Flowers();
            flowers.Show();
        }

        private void addFlowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salesman salesman = new Salesman();
            salesman.Show();
            this.Hide();
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.Show();
        }

        private void searchFlowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchFlowers searchFlowers = new searchFlowers();
            searchFlowers.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addFlowerCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            category cat = new category();
            cat.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
