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
    public partial class Form8 : Form
    {
        public static int l;
       
        public Form8()
        {
            InitializeComponent();
        }

        
        private void button5_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

            Dbpayments db = new Dbpayments();
            dataGridView1.DataSource = db.GETALLPAYMENTS();

            Dbsales da = new Dbsales();
            DataTable dt = new DataTable();

            dt = da.GETALLSALES();
            for (int k=0; k < dt.Rows.Count; k++)
            {
                textcodepay.Items.Add(dt.Rows[k][0].ToString());
            }
            //textcodepay.DataSource = dt;
            //textcodepay.DisplayMember = "CODEPSALE";
            dt = da.GETALLSALES();
            for (int k = 0; k < dt.Rows.Count; k++)
            {
                textBox5.Items.Add(dt.Rows[k][0].ToString());
            }

        }

        private void btnadd_Click(object sender, EventArgs e)
        {

            if ((!(Class.IsDigits(textpay.Text))))
            {
                MessageBox.Show("amount only with numbers");
                label2.ForeColor = Color.Red;
                textpay.Clear();
                textpay.Focus();
                return;

            }
            Dbpayments dbp=new Dbpayments();
            if (dbp.Found(textcodepay.Text)==true)
            {
                MessageBox.Show("its already used");
                return;
            }
            label2.ForeColor = Color.Black;            
            
            
            DataTable dt1 = new DataTable();
            payments b = new payments();
            Dbpayments db = new Dbpayments();




            b.codesale = textcodepay.Text;
            b.payment = int.Parse(textpay.Text);
           
            b.dateofpayment = textdateofpay.Text;
            b.numberofpayments = textnumpfpay.Text;



            db.Insertpayments(b);

            MessageBox.Show("Added  :)");
            dataGridView1.DataSource = db.GETALLPAYMENTS();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            l++;

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

            if ((!(Class.IsDigits(textpay.Text))))
            {
                MessageBox.Show("amount only with numbers");
                label2.ForeColor = Color.Red;
                textpay.Clear();
                textpay.Focus();
                return;

            }

            label7.ForeColor = Color.White;

            
            
            Dbpayments db = new Dbpayments();
            payments b = new payments();
            DataTable dt = new DataTable();

            
            b.codesale = textBox5.Text;
            b.payment = int.Parse(textBox4.Text);
            
            b.dateofpayment =textBox2.Text;
            b.numberofpayments = textBox1.Text;

            db.Updatepayments(b);
            dt = db.GETALLPAYMENTS();
            dataGridView1.DataSource = dt;
            MessageBox.Show("payment is updated");

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            payments b = new payments();
            b.codesale = textBox5.Text.ToString();
            Dbpayments db = new Dbpayments();


            DialogResult dr = MessageBox.Show("Are you sure you want to delete this payment ?", "string caption", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.Deletepayments(b);
                MessageBox.Show("PAYMENT is deleted");
                textBox5.Text = "";
                textBox4.Clear();
               
                textBox2.Clear();
                textBox1.Clear();

            }
            dataGridView1.DataSource = db.GETALLPAYMENTS();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            customers b = new customers();
            Dbpayments db = new Dbpayments();
            DataTable dt = new DataTable();
            dt = db.SearchBookByCode(textsearch.Text);
            //dataGridView1.DataSource = dt;



            if (dt.Rows.Count > 0)
            {
               textBox5.Text = dt.Rows[0][0].ToString();
               textBox4.Text = dt.Rows[0][1].ToString();
               textBox2.Text = dt.Rows[0][2].ToString();
               textBox1.Text = dt.Rows[0][3].ToString();
               
            }
            else
            {
                textBox5.Text = "";
                textBox4.Text = "";
                textBox2.Text ="";
                textBox1.Text = "";

            }

            dataGridView1.DataSource = dt;




        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textnumpfpay.Clear();
            textpay.Clear();

        }

        private void textcodepay_SelectedIndexChanged(object sender, EventArgs e)
        {
            sales b = new sales();
            Dbsales ab =new Dbsales();
            DataTable dt = new DataTable();
            dt = ab.SearchsaleByCode(int.Parse(textcodepay.Text));
            string f = dt.Rows[0][3].ToString();
            Dbphones s = new Dbphones();
            DataTable st = new DataTable();
            st = s.SearchBookByCode(int.Parse(f));
            textpay.Text = st.Rows[0][3].ToString();

        }

        private void textBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            sales b = new sales();
            Dbsales ab = new Dbsales();
            DataTable dt = new DataTable();
            dt = ab.SearchsaleByCode(int.Parse(textBox5.Text));
            string m = dt.Rows[0][3].ToString();
            Dbphones s = new Dbphones();
            DataTable st = new DataTable();
            st = s.SearchBookByCode(int.Parse(m));
            textBox4.Text = st.Rows[0][3].ToString();

        }
    }
}
