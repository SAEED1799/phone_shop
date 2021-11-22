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
    class Dbcustomers
    {

        private OleDbConnection cnn = new OleDbConnection();
        private OleDbCommand cmd = new OleDbCommand();
        private DataTable dt = new DataTable();

        public Dbcustomers()
        {
            cnn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MYPHONES.accdb";

        }
        public DataTable GETALLCUSTOMERS() //  פעולה מחזירה כל הלקוחות
        {
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                cmd.CommandText = "select * from CUSTOMERS";
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


        public void Insertcustomes(customers b)  //פעולה מוסיפה לקוח
        {
            string SqlStr = string.Format("insert into CUSTOMERS(IDCUSTOMER,FIRSTNAME,LASTNAME,DATEOFFBIRTH,EMAIL,ADDRESS,PHONENUMBER,GENDER)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", b.idcustomer, b.firstname, b.lastname, b.dateoffbirth, b.email, b.address, b.phonenumber, b.gender);


            InsDelUpd(SqlStr);
        }

        public void Deletecustomers(customers b) // פעולה מוחקת ספר לפי קוד הלקוח
        {
            string SqlStr = string.Format("delete  from CUSTOMERS  where IDCUSTOMER ='{0}'", b.idcustomer);
            
            InsDelUpd(SqlStr);
        }

        public void Updatecustomers(customers b) // פעולה מעדכנת לקוח
        {
            string SqlStr = string.Format("update CUSTOMERS  set IDCUSTOMER='{0}',FIRSTNAME='{1}',LASTNAME='{2}',DATEOFFBIRTH='{3}',EMAIL='{4}', ADDRESS='{5}',PHONENUMBER='{6}', GENDER='{7}' where IDCUSTOMER='{8}'", b.idcustomer, b.firstname, b.lastname, b.dateoffbirth, b.email, b.address, b.phonenumber, b.gender, b.idcustomer);
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


        public DataTable GetcustomersInfo(customers b) // פעולה מחזירה תיאור לקוח לפי הקוד
        {
            DataTable dt = new DataTable();
            string SqlStr = string.Format("select * from CUSTOMERS where IDCUSTOMER='{0}'", b.idcustomer);
            dt = ReturnDT(SqlStr);
            return dt;
        }

        public bool Found(int code) // פעולה מחזירה אמת אם הלקוח קיים לפי קוד הלקוח אחרת מחזירה שקר
        {
            DataTable dt = new DataTable();
            string str = string.Format("select * from CUSTOMERS where IDCUSTOMER='{0}' ", code);
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
                cmd.CommandText = string.Format("select * from CUSTOMERS where IDCUSTOMER='{0}'", code);
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
                cmd.CommandText = string.Format("select * from CUSTOMERS where FIRSTNAME like '%{0}%'", st);
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

        //internal object GETALLcustomers()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
    
