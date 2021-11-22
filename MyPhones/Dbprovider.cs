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
    class Dbprovider
    {
        private OleDbConnection cnn = new OleDbConnection();
        private OleDbCommand cmd = new OleDbCommand();
        private DataTable dt = new DataTable();

        public Dbprovider()
        {
            cnn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MYPHONES.accdb";

        }
        public DataTable GETALLproviders() //  פעולה מחזירה כל הספקים
        {
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                cmd.CommandText = "select * from PROVIDERS";
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

        public void Insertproviders(providers b)  //פעולה מוסיפה ספק
        {
            string SqlStr = string.Format("insert into PROVIDERS(CODEPROVIDE,NAMEPROVIDE,PHONENUMBER,EMAIL,ADDRESS)values({0},'{1}','{2}','{3}','{4}')", b.codeprovide, b.nameprovide, b.phonenumber, b.email, b.address);


            InsDelUpd(SqlStr);
        }

        public void Deleteproviders(providers b) // פעולה מוחקת ספר לפי קוד הספק
        {
            string SqlStr = string.Format("delete  from PROVIDERS  where CODEPROVIDE = {0}", b.codeprovide);

            InsDelUpd(SqlStr);
        }

        public void Updateproviders(providers b) // פעולה מעדכנת ספק
        {
            string SqlStr = string.Format("update PROVIDERS set CODEPROVIDE={0},NAMEPROVIDE='{1}',PHONENUMBER='{2}',EMAIL='{3}',ADDRESS='{4}' where CODEPROVIDE={5}", b.codeprovide, b.nameprovide, b.phonenumber, b.email, b.address, b.codeprovide);
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


        public DataTable GetprovidersInfo(providers b) // פעולה מחזירה תיאור ספק לפי הקוד
        {
            DataTable dt = new DataTable();
            string SqlStr = string.Format("select * from PROVIDERS where CODEPROVIDE={0}", b.code);
            dt = ReturnDT(SqlStr);
            return dt;
        }

        public bool Found(int code) // פעולה מחזירה אמת אם הספק קיים לפי קוד הספק אחרת מחזירה שקר
        {
            DataTable dt = new DataTable();
            string str = string.Format("select * from PROVIDERS where CODEPROVIDE={0} ", code);
            dt = ReturnDT(str);
            if (dt.Rows.Count == 0)
                return false;
            else
                return true;
        }



        public DataTable SearchproviderByCode(int code)
        {
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                cmd.CommandText = string.Format("select * from PROVIDERS where CODEPROVIDE={0}", code);
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
                cmd.CommandText = string.Format("select * from PROVIDERS where NAMEPROVIDE like '%{0}%'", st);
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



        internal object GETALLPHONES()
        {
            throw new NotImplementedException();
        }
    }
}
