using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contact
{
    public partial class user : Form
    {
        static string connectionString = "server=localhost;userid=root;database=contact;password=12345678;sslmode=none";
        public user()
        {
            InitializeComponent();
            ShowDataGrid();
        
        }

        private void btSeatch_Click(object sender, EventArgs e)
        {
            string name = tbSearch.Text;
            string sqlQuery = $"SELECT * FROM `contact` WHERE `Name` = '{name}'";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuery, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for(int i = 0; i <  dataGridView1.Rows.Count; i++)
            {
           
                lbName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                lbCompany.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                lbjobtitle.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                lbPhone.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
 
            }
            

          

        }
        private void ShowDataGrid()
        {
            string sqlQuery = "SELECT * FROM `contact`";
            MySqlConnection conn = new MySqlConnection(connectionString);   
            conn.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuery, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
