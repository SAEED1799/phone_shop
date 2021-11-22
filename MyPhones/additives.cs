using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhones
{
    class additives
    {
        private int Code;
        private string Name;
        private int PRICE;
        private string CATEGORY;
        private string DESCRIPTION;
        private int AMOUNT;


        public additives()
        { 

        }
        public int code
        {
            get { return this.Code; }
            set { this.Code = value; }
        }
        public string name
        {
            get { return this.Name; }
            set { this.Name = value; }
        }
        public int price
        {
            get { return this.PRICE; }
            set { this.PRICE = value; }
        }
        public string category
        {
            get { return this.CATEGORY; }
            set { this.CATEGORY = value; }
        }
        public string description
        {
            get { return this.DESCRIPTION; }
            set { this.DESCRIPTION = value; }
        }
        public int amount
        {
            get { return this.AMOUNT; }
            set { this.AMOUNT = value; }
        }

    }
}
