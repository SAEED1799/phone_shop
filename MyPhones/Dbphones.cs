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
    class Dbphones
    {
        private OleDbConnection cnn = new OleDbConnection();
        private OleDbCommand cmd = new OleDbCommand();
        private DataTable dt = new DataTable();

        public Dbphones()
        {
            cnn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MYPHONES.accdb";

        }
        public DataTable GETALLPHONES() //  פעולה מחזירה כל הטלפונים
        {
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                cmd.CommandText = "select * from PHONES";
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


        public void Insertphone(phones b)  //פעולה מוסיפה טלפון
        {
            string SqlStr = string.Format("insert into PHONES(CODEPHONE,TYBE,CODECOMBANEY,PRICE,COLOR,MEMORY,YEAROFCREAT,CODEPROVIDER,AMOUNT)values({0},'{1}','{2}',{3},'{4}','{5}','{6}','{7}',{8})", b.codephone, b.tybe, b.codecombaney, b.price, b.color, b.memory, b.yearofcreat,b.codeprovider, b.amount);


            InsDelUpd(SqlStr);
        }

        public void Deletephones(phones b) // פעולה מוחקת ספר לפי קוד הטלפון
        {
            string SqlStr = string.Format("delete  from PHONES  where CODEPHONE ={0}", b.codephone);

            InsDelUpd(SqlStr);
        }

        public void Updatephones(phones b) // פעולה מעדכנת טלפון
        {
            string SqlStr = string.Format("update PHONES  set CODEPHONE={0},TYBE='{1}',CODECOMBANEY='{2}',PRICE={3},COLOR='{4}',MEMORY='{5}',YEAROFCREAT='{6}', CODEPROVIDER='{7}',AMOUNT={8} where CODEPHONE={0}", b.codephone, b.tybe, b.codecombaney, b.price, b.color, b.memory, b.yearofcreat, b.codeprovider, b.amount);
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


        public DataTable GetphonesInfo(phones b) // פעולה מחזירה תיאור טלפון לפי הקוד
        {
            DataTable dt = new DataTable();
            string SqlStr = string.Format("select * from PHONES where CODEPHONE={0}", b.codephone);
            dt = ReturnDT(SqlStr);
            return dt;
        }

        public bool Found(int code) // פעולה מחזירה אמת אם הטלפון קיים לפי קוד הטלפון אחרת מחזירה שקר
        {
            DataTable dt = new DataTable();
            string str = string.Format("select * from PHONES where CODEPHONE={0} ", code);
            dt = ReturnDT(str);
            if (dt.Rows.Count == 0)
                return false;
            else
                return true;
        }



        public DataTable SearchBookByCode(int code)
        {
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                cmd.CommandText = string.Format("select * from PHONES where CODEPHONE={0}", code);
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
                cmd.CommandText = string.Format("select * from PHONES where TYBE like '%{0}%'", st);
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

        internal DataTable SearchBookByCode(string f)
        {
            throw new NotImplementedException();
        }
    }
}
