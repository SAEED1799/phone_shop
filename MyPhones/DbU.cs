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
    public class DbU
    {
        private OleDbConnection cnn = new OleDbConnection();
        private OleDbCommand cmd = new OleDbCommand();
        private DataTable dt = new DataTable();

        public DbU()
        {
            cnn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MYPHONES.accdb";

        }
        public DataTable GETALLBOOKS() // פעולה מחזירה כל המשתמשים
        {
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                cmd.CommandText = "select * from USERS";
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

        public void Insertcustomes(users b)  //פעולה מוסיפה משתמש
        {
            string SqlStr = string.Format("insert into USERS(IDUSER,PASSWORD,FIRSTNAME,LASTNAME,EMAIL)values('{0}','{1}','{2}','{3}','{4}')", b.iduser, b.password, b.firstname, b.lastname, b.email);


            InsDelUpd(SqlStr);
        }
        

        public void Deletecustomers(users b) // פעולה מוחקת ספר לפי קוד משתמש
        {
            string SqlStr = string.Format("delete  from USERS  where IDUSER ={0}", b.code);

            InsDelUpd(SqlStr);
        }

        public void Updatecustomers(users b) // פעולה מעדכנת משתמש
        {
            string SqlStr = string.Format("update USERS  set IDUSER={0},PASSWORD={1},FIRSTNAME={2},LASTNAME={3},EMAIL={4}", b.iduser, b.password, b.firstname, b.lastname, b.email);
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


        public DataTable GetcustomersInfo(users b) // פעולה מחזירה תיאור משתמש לפי הקוד
        {
            DataTable dt = new DataTable();
            string SqlStr = string.Format("select * from USERS where IDUSER='{0}'", b.code);
            dt = ReturnDT(SqlStr);
            return dt;
        }

        public bool Found(int code) // פעולה מחזירה אמת אםהמשתמש קיים לפי קוד המשתמש אחרת מחזירה שקר
        {
            DataTable dt = new DataTable();
            string str = string.Format("select * from USERS where IDUSER={0} ", code);
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
                cmd.CommandText = string.Format("select * from USERS where IDUSER={0}", code);
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
                cmd.CommandText = string.Format("select * from USERS where FIRSTNAME like '%{0}%'", st);
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
