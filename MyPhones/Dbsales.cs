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
    class Dbsales
    {
         private OleDbConnection cnn = new OleDbConnection();
        private OleDbCommand cmd = new OleDbCommand();
        private DataTable dt = new DataTable();

        public Dbsales()
        {
            cnn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MYPHONES.accdb";

        }
        public DataTable GETALLSALES() //  פעולה מחזירה כל המכירות
        {
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                cmd.CommandText = "select * from SALES";
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

        public void Insertsales(sales b)  //פעולה מוסיפה מכירה
        {
            string SqlStr = string.Format("insert into SALES(CODESALE,sDATE,IDCUSTOMER,CODEPRODUCT)values('{0}','{1}','{2}','{3}')", b.codesale, b.date, b.idcustomer, b.codeProduct);
            InsDelUpd(SqlStr);
        }

        public void Deletesales(sales  b) // פעולה מוחקת ספר לפי קוד מכירה
        {
            string SqlStr = string.Format("delete  from SALES  where CODESALE ='{0}'", b.codesale);

            InsDelUpd(SqlStr);
        }

        public void Updatesales(sales b) // פעולה מעדכנת מכירה
        {
            string SqlStr = string.Format("update SALES  set CODESALE='{0}',sDATE='{1}',IDCUSTOMER='{2}',CODEPRODUCT='{3}' where CODESALE ='{0}'", b.codesale, b.date, b.idcustomer, b.codeProduct);
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


        public DataTable GetsalesInfo(sales b) // פעולה מחזירה תיאור מכירה לפי הקוד
        {
            DataTable dt = new DataTable();
            string SqlStr = string.Format("select * from SALES where CODESALE='{0}'", b.codesale);
            dt = ReturnDT(SqlStr);
            return dt;
        }

        public bool Found(int code) // פעולה מחזירה אמת אם המכירה קיים לפי קוד המכירה אחרת מחזירה שקר
        {
            DataTable dt = new DataTable();
            string str = string.Format("select * from SALES where CODESALE='{0}' ", code);
            dt = ReturnDT(str);
            if (dt.Rows.Count == 0)
                return false;
            else
                return true;
        }



        public DataTable SearchsaleByCode(int code)
        {
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                cmd.CommandText = string.Format("select * from SALES where CODESALE='{0}'", code);
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

        internal DataTable SearchsaleByCode(string p)
        {
            throw new NotImplementedException();
        }
    }
}
