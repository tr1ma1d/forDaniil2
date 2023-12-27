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
    public partial class Form1 : Form
    {
        static string connectionString = "server=localhost;userid=root;database=contact;password=12345678;sslmode=none";
        public Form1()
        {
            InitializeComponent();
        }

        private void btSignIn_Click(object sender, EventArgs e)
        {
            string name = tbLogin.Text;
            string password = tbPassword.Text;
            bool anw = findUser(name,password);
            if(anw = true)
            {
                user user = new user();
                user.Show();
            }
            else if(name == "user" && password == "user")
            {
                
                user user = new user();
                user.Show();
             
            }
            else if (name == "admin" && password == "admin")
            {
               
                Admin admin = new Admin();
                admin.Show();
               
            }
            else
            {
                MessageBox.Show("Повторите попытку");
            }
        }
        private bool findUser(string name,string password)
        {
            string sqlQuery = $"SELECT * FROM `users` WHERE `username` = '{name}' AND `password` = '{password}'";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();   
            if(reader.Read())
            {
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            register_form rg = new register_form();
          
            rg.Show();
        }
    }
}
