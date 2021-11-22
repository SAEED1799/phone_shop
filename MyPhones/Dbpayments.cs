using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPhones
{
    class Dbpayments
    {
        private OleDbConnection cnn = new OleDbConnection();
        private OleDbCommand cmd = new OleDbCommand();
        private DataTable dt = new DataTable();

        public Dbpayments()
        {
            cnn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MYPHONES.accdb";

        }
        public DataTable GETALLPAYMENTS() //  פעולה מחזירה כל התשלומים
        {
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                cmd.CommandText = "select * from PAYMENTS";
                cmd.Connection = cnn;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return dt;

        }

        public void Insertpayments(payments b)  //פעולה מוסיפה תשלום
        {
            string SqlStr = string.Format("insert into PAYMENTS(CODESALE,PAYMENT,DATEOFPAYMENT,NUMBEROFPAYMENTS)values('{0}',{1},'{2}',{3})", b.codesale, b.payment,  b.dateofpayment, b.numberofpayments);


            InsDelUpd(SqlStr);
        }

        public void Deletepayments(payments b) // פעולה מוחקת ספר לפי קוד התשלום
        {
            string SqlStr = string.Format("delete  from PAYMENTS  where CODESALE='{0}'", b.codesale);

            InsDelUpd(SqlStr);
        }

        public void Updatepayments(payments b) // פעולה מעדכנת תשלום
        {
            string SqlStr = string.Format("update PAYMENTS  set CODESALE='{0}',PAYMENT={1},DATEOFPAYMENT='{2}',NUMBEROFPAYMENTS={3}  where CODESALE='{0}'", b.codesale, b.payment, b.dateofpayment, b.numberofpayments);
            InsDelUpd(SqlStr);
        }

        public void InsDelUpd(string SqlStr) // פעולה מבצעת 
        {
            OleDbCommand cmd = new OleDbCommand();

            try
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = SqlStr;
                cmd.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
        public DataTable ReturnDT(string SqlStr) //פעולה מחזירה טבלה לפי משפט 
        {
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                cmd.CommandText = SqlStr;
                cmd.Connection = cnn;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return dt;
        }


        public DataTable GetpaymentsInfo(payments b) // פעולה מחזירה תיאור תשלום לפי הקוד
        {
            DataTable dt = new DataTable();
            string SqlStr = string.Format("select * from PAYMENTS where NUMBEROFPAYMENTS='{4}'", b.code);
            dt = ReturnDT(SqlStr);
            return dt;
        }

        public bool Found(string code) // פעולה מחזירה אמת אם התשלום קיים לפי קוד התשלום אחרת מחזירה שקר
        {
            DataTable dt = new DataTable();
            string str = string.Format("select * from PAYMENTS where CODESALE='{0}' ", code);
            dt = ReturnDT(str);
            if (dt.Rows.Count == 0)
                return false;
            else
                return true;
        }



        public DataTable SearchBookByCode(string code)
        {
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                cmd.CommandText = string.Format("select * from PAYMENTS where CODESALE='{0}'", code);
                cmd.Connection = cnn;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return dt;
        }


        public DataTable SearchBookByNmae(string st)
        {
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                cmd.CommandText = string.Format("select * from PAYMENTS where Name like '%{0}%'", st);
                cmd.Connection = cnn;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return dt;



        }

        public string numberofpayments { get; set; }
    }
}
