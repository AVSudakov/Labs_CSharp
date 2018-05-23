using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab21
{
    class Department : IProductsManagement
    {
        List<Product> Products = new List<Product>();
        string fieldName;
        string fieldDirectorName;
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
        public Department(string DepartName)
        {
            fieldName = DepartName;
            //Конструктор
        }

        Product IProductsManagement.AddProduct(string ProductName,ProductType Type)
        {
            Product NewProduct;
            switch (Type)
            {
                case ProductType.Electronics:
                    Products.Add(NewProduct = new ElectronicProduct(ProductName));
                    break;
                case ProductType.Food:
                    NewProduct = null;
                    //Products.Add(new FoodProduct(ProductName));
                    break;
                case ProductType.Shoes:
                    NewProduct = null;
                    //Products.Add(new ShoeProduct(ProductName));
                    break;
                default:
                    NewProduct = null;
                    break;
            }
            return NewProduct;
        }
        Product IProductsManagement.RemoveProduct(string ProductName)
        {
            Product Product = GetProduct(ProductName);
            Products.Remove(Product);
            return Product;
        }
        public Product GetProduct(string ProductName)
        {
            foreach (Product Product in Products)
            {
                if (Product.Name == ProductName)
                    return Product;
            }
            return null;
        }
        override public string ToString()
        {
            return (String.Format("Name = {0}, Price = {1}, Type = {2}", Name, fieldDirectorName, Type.ToString()));
        }
    }
}
