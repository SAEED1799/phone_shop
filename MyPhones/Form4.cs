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
    public partial class Form4 : Form
    {
        public static int K;

        public Form4()
        {
            InitializeComponent();
        }

       

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
          
            if (textnameprov.Text.Length == 0)
            {
                MessageBox.Show("name is empty");
                label2.ForeColor = Color.Red;
                textnameprov.Focus();
                return;
            }
            label2.ForeColor = Color.White;

            if (!((Class.IsEnglishLetters(textnameprov.Text)) || (Class.IsHebrewLetters(textnameprov.Text))))
            {
                MessageBox.Show("is not english or hebrew letters");
                label2.ForeColor = Color.Red;
                textnameprov.Clear();
                textnameprov.Focus();
                return;
            }

            label2.ForeColor = Color.White;
     

                if (!(textphonenum.MaskFull))
                {
                    MessageBox.Show("Invalid phone number");
                    label3.ForeColor = Color.Red;
                    textphonenum.Clear();
                    textphonenum.Focus();
                    return;
                }

                label3.ForeColor = Color.White;

                

               


                if (textemail.Text.Length == 0)
                {
                    MessageBox.Show("mail is empty");
                    label4.ForeColor = Color.Red;
                    textemail.Clear();
                    textemail.Focus();
                    return;
                }
                label1.ForeColor = Color.White;


                if (!(Class.emailIsValid(textemail.Text)))
                {
                    MessageBox.Show("יש טעות במייל");
                    label4.ForeColor = Color.Red;
                    textemail.Clear();
                    textemail.Focus();
                    return;
                }

                label5.ForeColor = Color.White;


                if (textaddress.Text.Length == 0)
                {
                    MessageBox.Show("Address is empty");
                    label5.ForeColor = Color.Red;
                    textaddress.Clear();
                    textaddress.Focus();
                    return;
                }
                label6.ForeColor = Color.White;

              




            DataTable dt1 = new DataTable();
            providers b = new providers();
            Dbprovider db = new Dbprovider();
            dt1 = db.ReturnDT("SELECT MAX(CODEPROVIDE) AS CODEPROVIDE FROM PROVIDERS");
            int cc = int.Parse(dt1.Rows[0][0].ToString());
            cc = cc + 1;
            



            b.codeprovide = int.Parse(cc.ToString());
            b.nameprovide = textnameprov.Text;
            b.phonenumber = textphonenum.Text;
            b.email = textemail.Text;
            b.address = textaddress.Text;


            db.Insertproviders(b);

            MessageBox.Show("Added)");
            dataGridView1.DataSource = db.GETALLproviders();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {


            if (txtnameprov.Text.Length == 0)
            {
                MessageBox.Show("name is empty");
                label10.ForeColor = Color.Red;
                txtnameprov.Focus();
                return;
            }
            label2.ForeColor = Color.White;

            if (!((Class.IsEnglishLetters(txtnameprov.Text)) || (Class.IsHebrewLetters(txtnameprov.Text))))
            {
                MessageBox.Show("is not english or hebrew letters");
                label10.ForeColor = Color.Red;
                txtnameprov.Clear();
                txtnameprov.Focus();
                return;
            }

            label2.ForeColor = Color.White;


            if (!(txtphonenum.MaskFull))
            {
                MessageBox.Show("Invalid phone number");
                label3.ForeColor = Color.Red;
                txtphonenum.Clear();
                txtphonenum.Focus();
                return;
            }

            label9.ForeColor = Color.White;






            if (txtemail.Text.Length == 0)
            {
                MessageBox.Show("mail is empty");
                label8.ForeColor = Color.Red;
                txtemail.Clear();
                txtemail.Focus();
                return;
            }
            label8.ForeColor = Color.White;


            if (!(Class.emailIsValid(txtemail.Text)))
            {
                MessageBox.Show("יש טעות במייל");
                label8.ForeColor = Color.Red;
                txtemail.Clear();
                txtemail.Focus();
                return;
            }

            label8.ForeColor = Color.White;


            if (txtaddress.Text.Length == 0)
            {
                MessageBox.Show("Address is empty");
                label7.ForeColor = Color.Red;
                txtaddress.Clear();
                txtaddress.Focus();
                return;
            }
            label7.ForeColor = Color.White;

              
            
            
            Dbprovider db = new Dbprovider();
            providers b = new providers();
            DataTable dt = new DataTable();



            b.codeprovide  = int.Parse (txtcodeprov.Text);
            b.nameprovide = txtnameprov.Text;
            b.email = txtemail.Text;
            b.address = txtaddress.Text;
            b.phonenumber = txtphonenum.Text;
            db.Updateproviders(b);
            dt = db.GETALLproviders();
            dataGridView1.DataSource = dt;
            MessageBox.Show("book is updated");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodeprov.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            txtnameprov.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            txtphonenum.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            txtemail.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            txtaddress.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            K++;

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Dbprovider db = new Dbprovider();
            dataGridView1.DataSource = db.GETALLproviders();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            providers b = new providers();
            b.codeprovide = int.Parse (txtcodeprov.Text);
            Dbprovider db = new Dbprovider();


            DialogResult dr = MessageBox.Show("Are you sure you want to delete this provider ?", "string caption", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.Deleteproviders(b);
                MessageBox.Show("provider is deleted");
                txtnameprov.Clear();
                txtcodeprov.Clear();
                txtaddress.Clear();
                txtemail.Clear();
                txtphonenum.Clear();
              
            }
            dataGridView1.DataSource = db.GETALLproviders();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textnameprov.Clear();
            textcodeprov.Clear();
            textaddress.Clear();
            textemail.Clear();
            textphonenum.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            providers  b = new providers ();
            Dbprovider  db = new Dbprovider();
            DataTable dt = new DataTable();
            dt = db.SearchproviderByCode(int.Parse(textBox1.Text));
            //dataGridView1.DataSource = dt;



            if (dt.Rows.Count > 0)
            {

               
                txtcodeprov.Text = dt.Rows[0][0].ToString();
                txtnameprov.Text = dt.Rows[0][1].ToString();
                txtphonenum.Text = dt.Rows[0][2].ToString();
                txtemail.Text = dt.Rows[0][3].ToString();
                txtaddress.Text = dt.Rows[0][4].ToString();
               
                

            }
            else
            {
                
                txtnameprov.Text = "";
                txtcodeprov.Text = "";
                txtphonenum.Text = "";
                txtemail.Text = "";
                txtaddress.Text = "";
                
                

            }

            dataGridView1.DataSource = dt;




        }

        private void textsearch_TextChanged(object sender, EventArgs e)
        {
            providers b = new providers();
            Dbprovider db = new Dbprovider();
            DataTable dt = new DataTable();
            dt = db.SearchBookByNmae(textsearch.Text);
            dataGridView1.DataSource = dt;

                txtcodeprov.Text = dt.Rows[0][0].ToString();
                txtnameprov.Text = dt.Rows[0][1].ToString();
                txtphonenum.Text = dt.Rows[0][2].ToString();
                txtemail.Text = dt.Rows[0][3].ToString();
                txtaddress.Text = dt.Rows[0][4].ToString();


               
           

        }

        private void radioButname_CheckedChanged(object sender, EventArgs e)
        {
            textsearch.Visible = true;
            textBox1.Text = "";
            textBox1.Visible = false;
            button4.Visible = false;
        }

        private void radioButid_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textsearch.Text = "";
            textsearch.Visible = false;
            button4.Visible = true;
        }

       

       
    }
}
