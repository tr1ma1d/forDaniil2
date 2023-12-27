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
    public partial class register_form : Form
    {
        static string connectionString = "server=localhost;userid=root;database=contact;password=12345678;sslmode=none";
        public register_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string password = tbPassword.Text;
            bool answ = findUser(name);
            if(answ == true)
            {
                MessageBox.Show("Пользователь занят");
            }
            else
            {
                string sqlQuery = $"INSERT INTO `users`(`username`,`password`) VALUES('{name}','{password}')";
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                cmd.ExecuteNonQuery();
                Form1 form = new Form1();
                form.Show();
            }
            
        }
        private bool findUser(string name)
        {
            string sqlQuery = $"SELECT * FROM `users` WHERE `username` = '{name}'";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            return false;
        }
    }
}
