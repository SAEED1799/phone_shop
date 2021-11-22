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
    public partial class Form3 : Form   
    {
        public static int i;

        public Form3()
        {
            InitializeComponent();

            
        }

        



        private void buttonadd_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            customers b = new customers();
            Dbcustomers db = new Dbcustomers();

            
            b.idcustomer = textid.Text;
            b.firstname = textfname.Text;
            b.lastname = textlname.Text;
            b.dateoffbirth = dateTimePicker1.Text;
            b.email = textemail.Text;
            b.address = textaddress.Text;
            b.phonenumber = textphonenum.Text;
            if (radiomale.Checked == true)
            {
                b.gender = radiomale.Text;
            }
            if (radiofemale.Checked == true)
            {
                b.gender = radiofemale.Text;
            }
            

            db.Insertcustomes(b);

            MessageBox.Show("Added  :)");
            dataGridView1.DataSource = db.GETALLCUSTOMERS();

           
           

        }

        private void textsearch_TextChanged(object sender, EventArgs e)
        {
            customers b = new customers();
            Dbcustomers db = new Dbcustomers();
            DataTable dt = new DataTable();
            dt = db.SearchBookByNmae(textsearch.Text);
            dataGridView1.DataSource = dt;


            txtid.DataBindings.Add("text", dt, "IDCUSTOMER");
            txtfname.DataBindings.Add("text", dt, "FIRSTNAME");
            txtlname.DataBindings.Add("text", dt, "LASTNAME");
            txtdateofberth.DataBindings.Add("text", dt, "DATEOFBIRTH");
            txtemail.DataBindings.Add("text", dt, "EMAIL");
            txtaddress.DataBindings.Add("text", dt, "ADDRESS");
            txtphonenum.DataBindings.Add("text", dt, "PHONENUMPER");
            txtgender.DataBindings.Add("text", dt, "GENDER");

        }

        private void radiobutname_CheckedChanged(object sender, EventArgs e)
        {
            textsearch.Visible = true;
            textBox1.Text = "";
            textBox1.Visible = false;
            button4.Visible = false;



        }

        private void radiobutid_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textsearch.Text = "";
            textsearch.Visible = false;
            button4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            customers b = new customers();
            Dbcustomers db = new Dbcustomers();
            DataTable dt = new DataTable();
            dt = db.SearchBookByCode(textBox1.Text);
            //dataGridView1.DataSource = dt;



            if (dt.Rows.Count > 0)
            {

                txtid.Text = dt.Rows[0][0].ToString();
                txtfname.Text = dt.Rows[0][1].ToString();
                txtlname.Text = dt.Rows[0][2].ToString();
                txtdateofberth.Text = dt.Rows[0][3].ToString();
                txtemail.Text = dt.Rows[0][4].ToString();
                txtaddress.Text = dt.Rows[0][5].ToString();
                txtphonenum.Text = dt.Rows[0][6].ToString();
                txtgender.Text = dt.Rows[0][7].ToString();

            }
            else
            {
                txtid.Text = "";
                txtfname.Text = "";
                txtlname.Text = "";
                txtdateofberth.Text = "";
                txtemail.Text = "";
                txtaddress.Text = "";
                txtphonenum.Text = "";
                txtgender.Text = "";

            }

            dataGridView1.DataSource = dt;




        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            customers b = new customers();
            b.idcustomer = txtid.Text.ToString();
            Dbcustomers db = new Dbcustomers();
            

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this customer ?", "string caption", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.Deletecustomers(b);
                MessageBox.Show("customer is deleted");
                txtid.Clear();
                txtfname.Clear();
                txtlname.Clear();
                txtaddress.Clear();
                txtemail.Clear();
                txtphonenum.Clear();
                txtdateofberth.Clear();
                txtgender.Clear();

            }
            dataGridView1.DataSource = db.GETALLCUSTOMERS();
        }

        

        






       

        private void button5_Click_1(object sender, EventArgs e)
        {
            textid.Clear();
            textfname.Clear();
            textlname.Clear();
            textaddress.Clear();
            textemail.Clear();
            textphonenum.Clear();


        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
              if (txtfname.Text.Length == 0)
            {
                MessageBox.Show("name is empty");
                label2.ForeColor = Color.Red;
                txtfname.Focus();
                return;
            }
            label2.ForeColor = Color.White;

            if (!((Class.IsEnglishLetters(txtfname.Text)) || (Class.IsHebrewLetters(txtfname.Text))))
            {
                MessageBox.Show("is not english or hebrew letters");
                label2.ForeColor = Color.Red;
                txtfname.Clear();
                txtfname.Focus();
                return;
            }

            label2.ForeColor = Color.White;
            


                if (txtlname.Text.Length == 0)
                {
                    MessageBox.Show("name is empty");
                    label3.ForeColor = Color.Red;
                    label3.Focus();
                    return;
                }
                label3.ForeColor = Color.White;

                if (!((Class.IsEnglishLetters(txtlname.Text)) || (Class.IsHebrewLetters(txtlname.Text))))
                {
                    MessageBox.Show("is not english or hebrew letters");
                    label3.ForeColor = Color.Red;
                    txtlname.Clear();
                    txtlname.Focus();
                    return;
                }

                label3.ForeColor = Color.White;

                if (!Class.AgeMore10(dateTimePicker1.Value.Date))
                {
                    MessageBox.Show("Age is less than 10 years");
                    label4.ForeColor = Color.Red;
                    txtdateofberth.Focus();
                    return;

                }

                label4.ForeColor = Color.White;


                if (!(textphonenum.MaskFull))
                {
                    MessageBox.Show("Invalid phone number");
                    label7.ForeColor = Color.Red;
                    textphonenum.Clear();
                    textphonenum.Focus();
                    return;
                }

                label7.ForeColor = Color.White;

                if ((!(Class.IsDigits(txtid.Text))) || (!(Class.LengthIs9(txtid.Text))))
                {
                    MessageBox.Show("Invalid Id: id is only 9 digits");
                    label1.ForeColor = Color.Red;
                    txtid.Clear();
                    txtid.Focus();
                    return;

                }

                label1.ForeColor = Color.White;


                if (txtemail.Text.Length == 0)
                {
                    MessageBox.Show("mail is empty");
                    label5.ForeColor = Color.Red;
                    txtemail.Clear();
                    txtemail.Focus();
                    return;
                }
                label1.ForeColor = Color.White;


                if (!(Class.emailIsValid(txtemail.Text)))
                {
                    MessageBox.Show("יש טעות במייל");
                    label5.ForeColor = Color.Red;
                    txtemail.Clear();
                    txtemail.Focus();
                    return;
                }

                label5.ForeColor = Color.White;


                if (txtaddress.Text.Length == 0)
                {
                    MessageBox.Show("Address is empty");
                    label6.ForeColor = Color.Red;
                    txtaddress.Clear();
                    txtaddress.Focus();
                    return;
                }
                label6.ForeColor = Color.White;

                

            
            
            
            Dbcustomers db = new Dbcustomers();
            customers b = new customers();
            DataTable dt = new DataTable();

            b.idcustomer = txtid.Text;
            b.firstname = txtfname.Text;
            b.lastname = txtlname.Text;
            b.dateoffbirth = txtdateofberth.Text;
            b.email = txtemail.Text;
            b.address = txtaddress.Text;
            b.phonenumber = txtphonenum.Text;
            b.gender = txtgender.Text;
            
            db.Updatecustomers(b);
            dt = db.GETALLCUSTOMERS();
            dataGridView1.DataSource = dt;
            MessageBox.Show("book is updated");
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)

        {
            txtid.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            txtfname.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            txtlname.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            txtdateofberth.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            txtemail.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            txtaddress.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
            txtphonenum.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();
            txtgender.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value.ToString();
            i++;

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Dbcustomers db = new Dbcustomers();
            dataGridView1.DataSource = db.GETALLCUSTOMERS();
        }

        private void buttonadd_Click_1(object sender, EventArgs e)
        {

            if (textfname.Text.Length == 0)
            {
                MessageBox.Show("name is empty");
                label2.ForeColor = Color.Red;
                textfname.Focus();
                return;
            }
            label2.ForeColor = Color.White;

            if (!((Class.IsEnglishLetters(textfname.Text)) || (Class.IsHebrewLetters(textfname.Text))))
            {
                MessageBox.Show("is not english or hebrew letters");
                label2.ForeColor = Color.Red;
                textfname.Clear();
                textfname.Focus();
                return;
            }

            label2.ForeColor = Color.White;
            {


                if (textlname.Text.Length == 0)
                {
                    MessageBox.Show("name is empty");
                    label3.ForeColor = Color.Red;
                    label3.Focus();
                    return;
                }
                label3.ForeColor = Color.White;

                if (!((Class.IsEnglishLetters(textlname.Text)) || (Class.IsHebrewLetters(textlname.Text))))
                {
                    MessageBox.Show("is not english or hebrew letters");
                    label3.ForeColor = Color.Red;
                    textlname.Clear();
                    textlname.Focus();
                    return;
                }

                label3.ForeColor = Color.White;

                if (!Class.AgeMore10(dateTimePicker1.Value.Date))
                {
                    MessageBox.Show("Age is less than 10 years");
                    label4.ForeColor = Color.Red;
                    dateTimePicker1.Focus();
                    return;

                }

                label4.ForeColor = Color.White;


                if (!(textphonenum.MaskFull))
                {
                    MessageBox.Show("Invalid phone number");
                    label7.ForeColor = Color.Red;
                    textphonenum.Clear();
                    textphonenum.Focus();
                    return;
                }

                label7.ForeColor = Color.White;

                if ((!(Class.IsDigits(textid.Text))) || (!(Class.LengthIs9(textid.Text))))
                {
                    MessageBox.Show("Invalid Id: id is only 9 digits");
                    label1.ForeColor = Color.Red;
                    textid.Clear();
                    textid.Focus();
                    return;

                }

                label1.ForeColor = Color.White;


                if (textemail.Text.Length == 0)
                {
                    MessageBox.Show("mail is empty");
                    label5.ForeColor = Color.Red;
                    textemail.Clear();
                    textemail.Focus();
                    return;
                }
                label1.ForeColor = Color.White;


                if (!(Class.emailIsValid(textemail.Text)))
                {
                    MessageBox.Show("יש טעות במייל");
                    label5.ForeColor = Color.Red;
                    textemail.Clear();
                    textemail.Focus();
                    return;
                }

                label5.ForeColor = Color.White;


                if (textaddress.Text.Length == 0)
                {
                    MessageBox.Show("Address is empty");
                    label6.ForeColor = Color.Red;
                    textaddress.Clear();
                    textaddress.Focus();
                    return;
                }
                label6.ForeColor = Color.White;

                if ((radiomale.Checked == false) && (radiofemale.Checked == false))
                {
                    MessageBox.Show("עליך לבחור את המין");
                    label8.ForeColor = Color.Red;
                    return;
                }
                label8.ForeColor = Color.White;



                DataTable dt1 = new DataTable();
                customers b = new customers();
                Dbcustomers db = new Dbcustomers();




                b.idcustomer = textid.Text;
                b.firstname = textfname.Text;
                b.lastname = textlname.Text;
                b.dateoffbirth = dateTimePicker1.Text;
                b.email = textemail.Text;
                b.address = textaddress.Text;
                b.phonenumber = textphonenum.Text;
                if (radiomale.Checked == true)
                {
                    b.gender = radiomale.Text;
                }
                if (radiofemale.Checked == true)
                {
                    b.gender = radiofemale.Text;
                }


                db.Insertcustomes(b);

                MessageBox.Show("Added  :)");
                dataGridView1.DataSource = db.GETALLCUSTOMERS();



            }
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            txtfname.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            txtlname.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            txtdateofberth.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            txtemail.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            txtaddress.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
             txtphonenum.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();
            txtgender.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value.ToString();
            i++;
        }

        private void textsearch_TextChanged_1(object sender, EventArgs e)
        {
            customers b = new customers();
            Dbcustomers db = new Dbcustomers();
            DataTable dt = new DataTable();
            dt = db.SearchBookByNmae(textsearch.Text);
            dataGridView1.DataSource = dt;

            txtid.Text = dt.Rows[0][0].ToString();
            txtfname.Text = dt.Rows[0][1].ToString();
            txtlname.Text = dt.Rows[0][2].ToString();
            txtdateofberth.Text = dt.Rows[0][3].ToString();
            txtemail.Text = dt.Rows[0][4].ToString();
            txtaddress.Text = dt.Rows[0][5].ToString();
            txtphonenum.Text = dt.Rows[0][6].ToString();
            txtgender.Text = dt.Rows[0][7].ToString();
        }

        private void radioButname_CheckedChanged_1(object sender, EventArgs e)
        {
            textsearch.Visible = true;
            textBox1.Text = "";
            textBox1.Visible = false;
            button4.Visible = false;
        }

        private void radioButid_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textsearch.Text = "";
            textsearch.Visible = false;
            button4.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
