using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPhones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if ((txtuser.Text.Length == 0) && (txtpassword.Text.Length == 0))
            {
                MessageBox.Show("שם המשתמש והסיסמה ריקים , תמלא אותם !");
                lbluser.ForeColor = Color.Red;
                lblpassword.ForeColor = Color.Red;
                txtuser.Clear();
                txtpassword.Clear();
                txtuser.Focus();

                return;
            }
            lbluser.ForeColor = Color.Black;
            lblpassword.ForeColor = Color.Black;

            if (txtuser.Text.Length == 0)
            {

                MessageBox.Show("שם המשתמש ריק , תמלא אותו !");
                lbluser.ForeColor = Color.Red;
                txtuser.Clear();
                txtuser.Focus();
                return;
            }
            lbluser.ForeColor = Color.Black;

            if (!(txtuser.Text == "saeed"))
            {
                MessageBox.Show(" :) יש שגיאה בשם המשתמש ! ,תנסה שוב ");
                lbluser.ForeColor = Color.Red;
                txtuser.Clear();
                txtuser.Focus();
                return;
            }
            lbluser.ForeColor = Color.Black;

            if (txtpassword.Text.Length == 0)
            {
                MessageBox.Show("  הסיסמה ריקה , תמלא אותה !");
                lblpassword.ForeColor = Color.Red;
                txtpassword.Clear();
                txtpassword.Focus();
                return;
            }
            lblpassword.ForeColor = Color.Black;

            if (!(txtpassword.Text == "saeed1999"))
            {

                MessageBox.Show(" :) יש שגיאה בסיסמה ! ,תנסה שוב ");
                lblpassword.ForeColor = Color.Red;
                txtpassword.Clear();
                txtpassword.Focus();
                return;
            }
            lblpassword.ForeColor = Color.Black;

            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

       
    }
}
