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
    public partial class Form5 : Form
    {
        public static int s;

        public Form5()
        {
            InitializeComponent();
        }




        private void button6_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (text1.Text.Length == 0)
            {
                MessageBox.Show("name is empty");
                label2.ForeColor = Color.Red;
                text1.Focus();
                return;
            }
            label2.ForeColor = Color.White;

            if (!((Class.IsEnglishLetters(text1.Text)) || (Class.IsHebrewLetters(text1.Text))))
            {
                MessageBox.Show("is not english or hebrew letters");
                label2.ForeColor = Color.Red;
                text1.Clear();
                text1.Focus();
                return;
            }

            label2.ForeColor = Color.White;


            if ((!(Class.IsDigits(textprice.Text))) )
            {
                MessageBox.Show("price only with numbers");
                label3.ForeColor = Color.Red;
                textprice.Clear();
                textprice.Focus();
                return;

            }

            label1.ForeColor = Color.White;


            if (textdesc.Text.Length == 0)
            {
                MessageBox.Show("name is empty");
                label6.ForeColor = Color.Red;
                textdesc.Focus();
                return;
            }
            label2.ForeColor = Color.White;

            if (! (Class.IsHebrewLetters(textdesc.Text)))
            {
                MessageBox.Show("is not  hebrew letters");
                label6.ForeColor = Color.Red;
                textdesc.Clear();
                textdesc.Focus();
                return;
            }

            label6.ForeColor = Color.White;

            if ((!(Class.IsDigits(textamount.Text))))
            {
                MessageBox.Show("amount only with numbers");
                label7.ForeColor = Color.Red;
                textamount.Clear();
                textamount.Focus();
                return;

            }

            label7.ForeColor = Color.White;



            DataTable dt1 = new DataTable();
            additives b = new additives();
            Dbadditives db = new Dbadditives();
           
            dt1 = db.ReturnDT("SELECT MAX(Code) AS Code FROM ADDITIVES");
            int cc = int.Parse(dt1.Rows[0][0].ToString());
            cc = cc + 1;

            b.code =cc;
            b.name = text1.Text;
            b.price = int.Parse(textprice.Text);
            b.category = comboBox1.Text;
            b.description = textdesc.Text;
            b.amount = int.Parse(textamount.Text);




            db.Insertaddditives(b);

            MessageBox.Show("Added  :)");
            dataGridView1.DataSource = db.GETALLADDITIVES();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textcode.Clear();
            text1.Clear();
            textprice.Clear();

            textdesc.Clear();
            textamount.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox2.Text.Length == 0)
            {
                MessageBox.Show("name is empty");
                label11.ForeColor = Color.Red;
                textBox2.Focus();
                return;
            }
            label11.ForeColor = Color.White;

            if (!((Class.IsEnglishLetters(textBox2.Text)) || (Class.IsHebrewLetters(textBox2.Text))))
            {
                MessageBox.Show("is not english or hebrew letters");
                label11.ForeColor = Color.Red;
                text1.Clear();
                text1.Focus();
                return;
            }

            label11.ForeColor = Color.White;


            if ((!(Class.IsDigits(textBox3.Text))))
            {
                MessageBox.Show("price only with numbers");
                label10.ForeColor = Color.Red;
                textprice.Clear();
                textprice.Focus();
                return;

            }

            label10.ForeColor = Color.White;


            if (textBox5.Text.Length == 0)
            {
                MessageBox.Show("te2or is empty");
                label8.ForeColor = Color.Red;
                textdesc.Focus();
                return;
            }
            label8.ForeColor = Color.White;

            if (!(Class.IsHebrewLetters(textBox5.Text)))
            {
                MessageBox.Show("is not  hebrew letters");
                label7.ForeColor = Color.Red;
                textdesc.Clear();
                textdesc.Focus();
                return;
            }

            label7.ForeColor = Color.White;

            if ((!(Class.IsDigits(textBox6.Text))))
            {
                MessageBox.Show("amount only with numbers");
                label4.ForeColor = Color.Red;
                textamount.Clear();
                textamount.Focus();
                return;

            }

            label4.ForeColor = Color.White;


            
            Dbadditives db = new Dbadditives();
            additives b = new additives();
            DataTable dt = new DataTable();

            b.code = int.Parse(textBox1.Text);
            b.name = textBox2.Text;
            b.price = int.Parse(textBox3.Text);
            b.category = textBox4.Text;
            b.description = textBox5.Text;
            b.amount = int.Parse(textBox6.Text);



            db.Updateaddditives(b);
            dt = db.GETALLADDITIVES();
            dataGridView1.DataSource = dt;
            MessageBox.Show("additives is updated");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            additives b = new additives();
            b.code = int.Parse(textBox1.Text.ToString());
            Dbadditives db = new Dbadditives();


            DialogResult dr = MessageBox.Show("Are you sure you want to delete this additives ?", "string caption", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.Deleteaddditives(b);
                MessageBox.Show("additives is deleted");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();

            }
            dataGridView1.DataSource = db.GETALLADDITIVES();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();

            s++;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                additives b = new additives();
                Dbadditives db = new Dbadditives();
                DataTable dt = new DataTable();
                dt = db.SearchaBycode(int.Parse(textBox7.Text));
                //dataGridView1.DataSource = dt;



                if (dt.Rows.Count > 0)
                {

                    textBox1.Text = dt.Rows[0][0].ToString();
                    textBox2.Text = dt.Rows[0][1].ToString();
                    textBox3.Text = dt.Rows[0][2].ToString();
                    textBox4.Text = dt.Rows[0][3].ToString();
                    textBox5.Text = dt.Rows[0][4].ToString();
                    textBox6.Text = dt.Rows[0][5].ToString();


                }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";

                }

                dataGridView1.DataSource = dt;

            }
            
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Dbadditives db = new Dbadditives();
            dataGridView1.DataSource = db.GETALLADDITIVES();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void radioButname_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}