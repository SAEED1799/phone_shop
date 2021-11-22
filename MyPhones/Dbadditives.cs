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
    class Dbadditives
    {
        private OleDbConnection cnn = new OleDbConnection();
        private OleDbCommand cmd = new OleDbCommand();
        private DataTable dt = new DataTable();

        public Dbadditives()
        {
            cnn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MYPHONES.accdb";

        }
        public DataTable GETALLADDITIVES() //   פעולה מחזירה כל התוספות
        {
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                cmd.CommandText = "select * from ADDITIVES";
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

        public void Insertaddditives(additives b)  //פעולה מוסיפה תוספת
        {
            string SqlStr = string.Format("insert into ADDITIVES(Code,Name,PRICE,CATEGORY,DESCRIPTION,AMOUNT)values({0},'{1}',{2},'{3}','{4}',{5})", b.code, b.name, b.price, b.category, b.description, b.amount);

            
            InsDelUpd(SqlStr);
        }

        public void Deleteaddditives(additives b) // פעולה מוחקת ספר לפי קוד תוספת
        {
            string SqlStr = string.Format("delete  from ADDITIVES  where Code ={0}", b.code);

            InsDelUpd(SqlStr);
        }

        public void Updateaddditives(additives b) // פעולה מעדכנת תוספת
        {
            string SqlStr = string.Format("update ADDITIVES  set Code={0},Name='{1}',PRICE={2},CATEGORY='{3}',DESCRIPTION='{4}',AMOUNT={5} where Code ={0}", b.code, b.name, b.price, b.category, b.description, b.amount);
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


        public DataTable GetadditivesInfo(additives b) // פעולה מחזירה תיאור תוספת לפי הקוד
        {
            DataTable dt = new DataTable();
            string SqlStr = string.Format("select * from ADDITIVES where Code={0}", b.code);
            dt = ReturnDT(SqlStr);
            return dt;
        }

        public bool Found(int code) // פעולה מחזירה אמת אם התוספת קיים לפי קוד התוספת אחרת מחזירה שקר
        {
            DataTable dt = new DataTable();
            string str = string.Format("select * from ADDITIVES where Code={0} ", code);
            dt = ReturnDT(str);
            if (dt.Rows.Count == 0)
                return false;
            else
                return true;
        }

        public DataTable SearchaBycode(int st)
        {
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                cmd.CommandText = string.Format("select * from ADDITIVES where Code={0}", st);
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

        public DataTable SearchadditivesByCode(int code)
        {
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                cmd.CommandText = string.Format("select * from ADDITIVES where Code={0}", code);
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
                cmd.CommandText = string.Format("select * from ADDITIVES where Name like '%{0}%'", st);
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
    }
}