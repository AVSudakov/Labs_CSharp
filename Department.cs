using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab21
{
    [Serializable]
    public class Department : IProductsManagement
    {
        public List<Product> Products = new List<Product>();
        string fieldName;
        string fieldDirectorName;
        public string Director
        {
            get { return fieldDirectorName; }
            set { fieldDirectorName = value; }
        }
        public DepartmentType Type
        {
            get;
            set;
        }
        public string Name
        {
            get { return fieldName; }
            set { fieldName = value; }
        }
        public Department()
        {
            fieldName = "new_department";
            //Конструктор
        }
        public Department(string departName)
        {
            fieldName = departName;
            //Конструктор
        }

        Product IProductsManagement.AddProduct(string productName,ProductType Type)
        {
            Product NewProduct;
            NewProduct = this.GetProduct(productName);
            if (NewProduct != null)
                NewProduct.Count++;
            else
            switch (Type)
            {
                case ProductType.Electronics:
                    Products.Add(NewProduct = new ElectronicProduct(productName));
                    break;
                case ProductType.Food:
                    Products.Add(NewProduct = new FoodProduct(productName));
                    break;
                case ProductType.Shoes:
                    NewProduct = null;
                    Products.Add(NewProduct = new ShoeProduct(productName));
                    break;
                default:
                    NewProduct = null;
                    break;
            }
            return NewProduct;
        }
        Product IProductsManagement.RemoveProduct(string productName)
        {
            Product Product = GetProduct(productName);
            if (Product.Count > 0)
                Product.Count--;
            else
                Products.Remove(Product);
            return Product;
        }
        public Product GetProduct(string productName)
        {
            return Products.FirstOrDefault(p => p.Name == productName);
        }
        public Product[] GetAllProducts()
        {
            return Products.ToArray();
        }
        override public string ToString()
        {
            return (String.Format("Name = {0}, Director = {1}, Type = {2}", Name, fieldDirectorName, Type.ToString()));
        }
    }
}
