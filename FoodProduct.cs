using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab21
{
    public class FoodProduct : Product
    {
        public FoodProduct(string ProductName)
            : base(ProductName)
        {
 
        }
        public FoodProduct()
        {

        }
        public override string[] GetAllProperties()
        {
            string[] properties = new string[3];
            properties[0] = "ExpiryDate";
            properties[1] = "Ingridients";
            properties[2] = "PackType";
            //Properties[3] = "Name";
            return properties;
        }
        public DateTime ExpiryDate
        {
            get;
            set;
        }
        public string Ingridients
        {
            get;
            set;
        }
        public string PackType
        {
            get;
            set;
        }
        override public string ToString()
        {
            return (String.Format("Name = {0}, Price = {1}, Manufacter = {2}", Name, Price, Manufacter));
        }
        public override string GetProperty(string propertyName)
        {
             switch (propertyName)
            {
                case "ExpiryDate":
                    return ExpiryDate.ToString();
                    //break;
                case "PackType":
                    return PackType;
                    //break;
                case "Ingridients":
                    return Ingridients;
                //break;
                default:
                    return "";
                //break;
            }
        
        }
        public override bool SetProperty(string propertyName, string value)
        {
            switch (propertyName)
            {
                case "ExpiryDate":
                    ExpiryDate = DateTime.Parse(value);
                    return true;
                    //break;
                case "Ingridients":
                    Ingridients = value;
                    return true;
                //break;
                case "PackType":
                    PackType = value;
                    return true;
                //break;
                //case "Name":
                    //Name = value;
                    //return true;
                    //break;
                default:
                    return false;
                //break;
            }
        }
    }
}
