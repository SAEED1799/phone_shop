using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhones
{
    class customers
    {
         private string IDCUSTOMER;
         private string FIRSTNAME;
         private string  LASTNAME;
         private string DATEOFFBIRTH;
         private string EMAIL;
         private string  ADDRESS;
         private string PHONENUMBER;
         private string GENDER;

         public customers()
         {
         }

         public string idcustomer
         {
             get { return this.IDCUSTOMER; }
             set { this.IDCUSTOMER = value; }
         }
         public string firstname
         {
             get { return this.FIRSTNAME; }
             set { this.FIRSTNAME = value; }
         }
         public string lastname
         {
             get { return this.LASTNAME; }
             set { this.LASTNAME = value; }
         }
         public string dateoffbirth
         {
             get { return this.DATEOFFBIRTH; }
             set { this.DATEOFFBIRTH = value; }
         }
         public string email
         {
             get { return this.EMAIL; }
             set { this.EMAIL = value; }
         }
         public string address
         {
             get { return this.ADDRESS; }
             set { this.ADDRESS = value; }
         }

         public string phonenumber
         {
             get { return this.PHONENUMBER ; }
             set { this.PHONENUMBER  = value; }
         }
         public string gender
         {
             get { return this.GENDER; }
             set { this.GENDER = value; }
         }

         
    }
}

    