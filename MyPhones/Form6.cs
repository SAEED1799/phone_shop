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
    public partial class Form6 : Form
    {
        public static int t;
        public Form6()
        {
            InitializeComponent();
        }

        

      

        private void button1_Click(object sender, EventArgs e)
        {
            if ((!(Class.IsDigits(textprice.Text))))
            {
                MessageBox.Show("price only with numbers");
                label4.ForeColor = Color.Red;
                textprice.Clear();
                textprice.Focus();
                return;

            }

            label1.ForeColor = Color.White;


            if ((!(Class.IsDigits(textamount.Text))))
            {
                MessageBox.Show("amount only with numbers");
                label9.ForeColor = Color.Red;
                textamount.Clear();
                textamount.Focus();
                return;

            }

            label7.ForeColor = Color.White;


            DataTable dt1 = new DataTable();
            phones b = new phones();
            Dbphones db = new Dbphones();
            dt1 = db.ReturnDT("SELECT MAX(CODEPHONE) AS CODEPHONE FROM PHONES");
            int cc = int.Parse(dt1.Rows[0][0].ToString());
            cc = cc + 1;



            b.codephone =cc;
            b.tybe = combtybe.Text;
            b.codecombaney = textcodecom.Text;
            b.price = int.Parse(textprice.Text);
            b.color = combcolor.Text;
            b.memory = combmemory.Text;
            b.yearofcreat = textyear.Text;
            b.codeprovider = textcodeprov.Text;
            b.amount =int.Parse( textamount.Text);
          


            db.Insertphone(b);

            MessageBox.Show("Added  :)");
            dataGridView1.DataSource = db.GETALLPHONES();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textcode.Clear();
            textcodecom.Text = "";
            textprice.Clear();
            textyear.Text = "";
            textcodeprov.Text = "";
            textamount.Clear();
            combcolor.Text = "";
            combmemory.Text = "";
            combtybe.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if ((!(Class.IsDigits(textprice.Text))))
            {
                MessageBox.Show("price only with numbers");
                label15.ForeColor = Color.Red;
                textprice.Clear();
                textprice.Focus();
                return;

            }

            label1.ForeColor = Color.White;


            if ((!(Class.IsDigits(textamount.Text))))
            {
                MessageBox.Show("amount only with numbers");
                label10.ForeColor = Color.Red;
                textamount.Clear();
                textamount.Focus();
                return;

            }

            label7.ForeColor = Color.White;

            
            Dbphones db = new Dbphones();
            phones b = new phones();
            DataTable dt = new DataTable();

            b.codephone = int.Parse(tcode.Text);
            b.tybe = ttybe.Text;
            b.codecombaney = tcodecom.Text;
            b.price = int.Parse(tprice.Text);
            b.color = tcolor.Text;
            b.memory = tmemory.Text;
            b.yearofcreat = tyear.Text;
            b.codeprovider = tcodeprov.Text;
            b.amount = int.Parse(tamount.Text);


            db.Updatephones(b);
            dt = db.GETALLPHONES();
            dataGridView1.DataSource = dt;
            MessageBox.Show("phone is updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            phones b = new phones();
            b.codephone = int.Parse(tcode.Text.ToString());
            Dbphones db = new Dbphones();


            DialogResult dr = MessageBox.Show("Are you sure you want to delete this customer ?", "string caption", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.Deletephones(b);
                MessageBox.Show("customer is deleted");

                tcode.Clear();
                tcodecom.Clear();
                tprice.Clear();
                tyear.Clear();
                tcodeprov.Clear();
                tamount.Clear();
                ttybe.Clear();
                tcolor.Clear();
                tmemory.Clear();


            }
            dataGridView1.DataSource = db.GETALLPHONES();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textsearch.Text != "")
            {
                phones b = new phones();
                Dbphones db = new Dbphones();
                DataTable dt = new DataTable();
                dt = db.SearchBookByCode(int.Parse(textsearch.Text));
                dataGridView1.DataSource = dt;



                if (dt.Rows.Count > 0)
                {

                    tcode.Text = dt.Rows[0][0].ToString();
                    tcodecom.Text = dt.Rows[0][1].ToString();
                    tprice.Text = dt.Rows[0][2].ToString();
                    tyear.Text = dt.Rows[0][3].ToString();
                    tcodeprov.Text = dt.Rows[0][4].ToString();
                    tamount.Text = dt.Rows[0][5].ToString();
                    ttybe.Text = dt.Rows[0][6].ToString();
                    tcolor.Text = dt.Rows[0][7].ToString();
                    tmemory.Text = dt.Rows[0][8].ToString();

                }
                else
                {
                    tcode.Text = "";
                    tcodecom.Text = "";
                    tprice.Text = "";
                    tyear.Text = "";
                    tcodeprov.Text = "";
                    tamount.Text = "";
                    ttybe.Text = "";
                    tcolor.Text = "";
                    tmemory.Text = "";

                }

                dataGridView1.DataSource = dt;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tcode.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            ttybe.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            tcodecom.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString(); 
            tprice.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            tcolor.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            tmemory.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString(); 
            tyear.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();
            tcodeprov.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value.ToString();
            tamount.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[8].Value.ToString();
           
           
           

            t++;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            Dbprovider db = new Dbprovider();
            DataTable dt = new DataTable();
            Dbphones dd = new Dbphones();
            dataGridView1.DataSource = dd.GETALLPHONES();

            dt = db.GETALLproviders();
            textcodeprov.DataSource = dt;
            textcodeprov.DisplayMember = "CODEPROVIDE";

        }

        private void textcodeprov_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        
}
    }
