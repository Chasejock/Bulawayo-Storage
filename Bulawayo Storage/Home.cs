using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bulawayo_Storage
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            AddStudent Add = new AddStudent();
            Add.Show();
            this.Hide();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            SearchDataBase Search = new SearchDataBase();
            Search.Show();
            this.Hide();
        }

        private void btn_Report_Click(object sender, EventArgs e)
        {
            string caption = "Not Implemented";
            MessageBoxButtons Buttons = MessageBoxButtons.OK;
            MessageBoxIcon Icon = MessageBoxIcon.Information;
            MessageBox.Show("No Fuctions Yet", caption, Buttons,Icon);
        }

        private void btn_Admin_Click(object sender, EventArgs e)
        {
            string caption = "Not Implemented";
            MessageBoxButtons Buttons = MessageBoxButtons.OK;
            MessageBoxIcon Icon = MessageBoxIcon.Information;
            MessageBox.Show("No Fuctions Yet", caption, Buttons, Icon);
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
