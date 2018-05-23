using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab21
{
    class ElectronicProduct : Product
    {
        public ElectronicProduct(string ProductName)
            : base(ProductName)
        {
            //Name = ProductName;
        }
        override public decimal Price
        {
            get { return fieldPrice; }
            set { fieldPrice = value; }
        }
        override public string ToString()
        {
            return (String.Format("Name = {0}, Price = {1}, Manufacter = {2}", Name, Price, Manufacter));
        }
    }
}
