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
    public partial class Form7 : Form
    {
        public static int x;

        public Form7()
        {
            InitializeComponent();
        }

        
        private void button6_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            Dbsales db = new Dbsales();
            
            dataGridView1.DataSource = db.GETALLSALES();

            DataTable dt = new DataTable();
            Dbphones dd = new Dbphones();
            


            dt = dd.GETALLPHONES();
            textcodem.DataSource = dt;
            textcodem.DisplayMember = "CODEPHONE";

           
        
            dt = dd.GETALLPHONES();
            tcodem.DataSource = dt;
            tcodem.DisplayMember = "CODEPHONE";



            Dbadditives aa = new Dbadditives();



            dt = aa.GETALLADDITIVES();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Code";

            dt = aa.GETALLADDITIVES();
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Code";


            Dbcustomers ss = new Dbcustomers();
            dt = ss.GETALLCUSTOMERS();
            textidcustomer.DataSource = dt;
            textidcustomer.DisplayMember = "IDCUSTOMER";


            Dbcustomers ab = new Dbcustomers();
            dt = ab.GETALLCUSTOMERS();
            tidcustomer.DataSource = dt;
            tidcustomer.DisplayMember = "IDCUSTOMER";


        }

        private void button1_Click(object sender, EventArgs e)
        {

            

            
            
            
            DataTable dt1 = new DataTable();
            sales b = new sales();
            Dbsales db = new Dbsales();
            dt1 = db.ReturnDT("SELECT MAX(CODESALE) AS CODESALE FROM SALES");
            int cc = int.Parse(dt1.Rows[0][0].ToString());
            cc = cc + 1;




            b.codesale = cc.ToString();
            b.date = textdateofsale.Text;
            b.idcustomer = textidcustomer.Text;
            if (radioButton2.Checked)

                b.codeProduct = textcodem.Text;
            else

                b.codeProduct = comboBox1.Text;



            db.Insertsales(b);

            MessageBox.Show("Added  :)");
            dataGridView1.DataSource = db.GETALLSALES();

        }

        private void button2_Click(object sender, EventArgs e)
        {

           
            
            
            Dbsales db = new Dbsales();
            sales b = new sales();
            DataTable dt = new DataTable();

            b.codesale = tcodesale.Text;
            b.date = tdateofsale.Text;
            b.idcustomer = tidcustomer.Text;
            if (radioButton3.Checked)

                b.codeProduct = tcodem.Text;
            else

                b.codeProduct = comboBox2.Text;





            db.Updatesales(b);
            dt = db.GETALLSALES();
            dataGridView1.DataSource = dt;
            MessageBox.Show("sale is updated");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            sales b = new sales();
            b.codesale = tcodesale.Text.ToString();
            Dbsales db = new Dbsales();


            DialogResult dr = MessageBox.Show("Are you sure you want to delete this additives ?", "string caption", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.Deletesales(b);
                MessageBox.Show("additives is deleted");
                tcodesale.Clear();
                tdateofsale.Clear();
                tidcustomer.Text = "";
                tcodem.Text = "";
                comboBox2.Text = "";

            }
            dataGridView1.DataSource = db.GETALLSALES();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textcodesale.Clear();
            textdateofsale.Text = "";
            textcodem.Text = "";
            comboBox1.Text = "";

           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tcodesale.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            tdateofsale.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            tidcustomer.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            tcodem.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            x++;

        }

        private void button4_Click(object sender, EventArgs e)
        {

            sales b = new sales();
            Dbsales db = new Dbsales();
            DataTable dt = new DataTable();
            dt = db.SearchsaleByCode(int.Parse(textsearch.Text));
            //dataGridView1.DataSource = dt;



            if (dt.Rows.Count > 0)
            {


                tcodesale.Text = dt.Rows[0][0].ToString();
                tdateofsale.Text = dt.Rows[0][1].ToString();
                tidcustomer.Text = dt.Rows[0][2].ToString();
                tcodem.Text = dt.Rows[0][3].ToString();



            }
            else
            {
                tcodesale.Text = "";
                tdateofsale.Text = "";
                tidcustomer.Text = "";
                tcodem.Text = "";




            }

            dataGridView1.DataSource = dt;


        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textsearch_TextChanged(object sender, EventArgs e)
        {
          


        }

        private void radioButcode_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textcodem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            textcodem.Visible = false;
            comboBox1.Text = "";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            textcodem.Visible = true;
            textcodem.Text = "";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Visible = false;
            tcodem.Visible = true;
            tcodem.Text = "";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Visible = true;
            tcodem.Visible = false;
            comboBox2.Text = "";
        }
    }
}
