using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
namespace lab21
{
    [Serializable]
    [XmlInclude(typeof(ElectronicProduct))]
    [XmlInclude(typeof(FoodProduct))]
    [XmlInclude(typeof(ShoeProduct))]
    public abstract class Product
    {
        int fieldCount = 0;
        protected decimal fieldPrice;
        public decimal Price
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
      public Product(string productName)
        {
            //Конструктор
            Name = productName;
            this.Count=1;
        }
      public Product()
      {
          //Конструктор
          Name = "new_product";
          Count = 1;
      }
        public Product(string productName, int count)
        {
            //Конструктор
            Name = productName;
            Count = count;
        }
         public abstract string GetProperty(string propertyName);
         public abstract bool SetProperty(string propertyName, string value);
         public abstract string[] GetAllProperties();
    }
}
