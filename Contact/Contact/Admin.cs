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
using System.Xml.Linq;

namespace Contact
{
    public partial class Admin : Form
    {
       
        static string connectionString = "server=localhost;userid=root;database=contact;password=12345678;sslmode=none";
        public Admin()
        {
            InitializeComponent();
            ShowDataGrid();
            lbID.Visible = false;
            dataGridView1.Columns["idContact"].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                lbID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                tbName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                tbCompany.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                tbJobTitle.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                tbPhone.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

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

        private void button1_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string phone = tbPhone.Text;
            string company = tbCompany.Text;
            string jobTitle = tbJobTitle.Text;

            if(name !=  null && phone != null && company != null && jobTitle != null)
            {
                string sqlQuery = $"INSERT INTO contact (`Name`,`Company`,`PhoneNumber`,`JobTitle`) VALUES('{name}','{company}','{phone}','{jobTitle}')";
                MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
                mySqlConnection.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, mySqlConnection);
                cmd.ExecuteNonQuery();
                mySqlConnection.Close();
                ShowDataGrid();
            }
            else
            {
                MessageBox.Show("Заполните пустые поля");
            }
           
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
           
            string name = tbName.Text;
            string phone = tbPhone.Text;
            string company = tbCompany.Text;
            string jobTitle = tbJobTitle.Text;
            int newID = Convert.ToInt32(lbID.Text);
            if (name != null && phone != null && company != null && jobTitle != null)
            {
               
                string sqlQuery = $"UPDATE contact SET `Name` = '{name}', `PhoneNumber` = '{phone}',`Company` = '{company}',`JobTitle` = '{jobTitle}' WHERE `idContact` = '{newID}'";
                MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
                mySqlConnection.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, mySqlConnection);
                cmd.ExecuteNonQuery();
                mySqlConnection.Close();
                ShowDataGrid();
            }
            else
            {
                MessageBox.Show("Заполните пустые поля");
            }
        }

        private void tbDelete_Click(object sender, EventArgs e)
        {
            int newID = Convert.ToInt32(lbID.Text);
            string sqlQuery = $"DELETE FROM `contact` WHERE `idContact` = '{newID}'";
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, mySqlConnection);
            cmd.ExecuteNonQuery();
            mySqlConnection.Close();
            ShowDataGrid();
            
          
          
        }
    }
}
