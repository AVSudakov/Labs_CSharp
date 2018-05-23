using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab21
{
    class Product
    {
        int fieldCount = 0;
        protected decimal fieldPrice;
        virtual public decimal Price
        {
            get { return fieldPrice; }
            set { fieldPrice = value; }
        }
        virtual public int Count
        {
            get { return fieldCount; }
            set { fieldCount = value; }
        }
        decimal Mass
        {
            get;
            set;
        }
        public string Manufacter
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        /*public ProductType Type
        {
            get;
            set;
        }*/
        public Product(string ProductName)
        {
            //Конструктор
            Name = ProductName;
        }
        /*public Product(string ProductName, ProductType Type)
        {
            //Конструктор
            Name = ProductName;
            this.Type = Type;
        }*/

    }
}
