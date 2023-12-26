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
        public Form1()
        {
            InitializeComponent();
        }

        private void btSignIn_Click(object sender, EventArgs e)
        {
            string name = tbLogin.Text;
            string password = tbPassword.Text;
            
            if(name == "user" && password == "user")
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
    }
}
