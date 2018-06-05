using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
namespace lab21
{
    class Program
    {
         
        static void Main(string[] args)
        {
            
            IProductsManagement ProductsIntrface;
            IDepartmentsManagement DepartmentsIntrface;
            Mart MyMart = new Mart();
            DepartmentsIntrface = (IDepartmentsManagement)MyMart;
            Department MyDepartment = DepartmentsIntrface.AddDepartment("Мир электроники", DepartmentType.Electronics);
            MyDepartment.Director = "Петров И.И.";
            ProductsIntrface = (IProductsManagement)MyMart.GetDepartment("Мир электроники");
            Product Smartphone = ProductsIntrface.AddProduct("Smartphone Samsung Galaxy J3", ProductType.Electronics);
            Smartphone.Price = 12500;
            Smartphone.Manufacter = "Samsung";
            ((ElectronicProduct)Smartphone).RamSize = 12000;
            XmlSerializer xs = new XmlSerializer(typeof(Mart));
            MainLoop(MyMart, DepartmentsIntrface, xs);
        }
        static void MainLoop(Mart MyMart, IDepartmentsManagement DepartmentsIntrface, XmlSerializer xs)
        {
	        char key;		
	        do
	        {
		        Console.WriteLine("Choose action:");	
		        Console.WriteLine("0 - add department");	
		        Console.WriteLine("1 - department info");	
		        Console.WriteLine("2 - remove department");
		        Console.WriteLine("3 - add product");
		        Console.WriteLine("4 - product info");
		        Console.WriteLine("5 - delete product");
		        Console.WriteLine("6 - show all departments");
		        Console.WriteLine("7 - show all products");
		        Console.WriteLine("8 - change product");
		        Console.WriteLine("s - serialize");
                Console.WriteLine("d - deserialize");

                key = Console.ReadKey().KeyChar;
		        Console.Clear();
                switch (key)
		        {
		            case '0'://Добавление отдела
		            {
                        DepartmentType NewType;
                        Console.WriteLine("Choose type:");
                        Console.WriteLine("0 - electronics");
                        Console.WriteLine("1 - food");
                        Console.WriteLine("2 - sport");
                        Console.WriteLine("3 - wear");
                        Console.WriteLine("4 - gifts");
                        Console.WriteLine("5 - shoes");
                        Console.WriteLine("6 - toys");
                        Console.WriteLine("7 - other");
                        char newType = Console.ReadKey().KeyChar;
                        try
                        {
                            NewType = (DepartmentType)int.Parse(newType.ToString());
                            if (!Enum.IsDefined(typeof(DepartmentType), NewType))
                                throw new IndexOutOfRangeException();
                            Console.WriteLine("Enter name:");
                            string departmentName = Console.ReadLine().ToString();
                            Console.WriteLine("Enter director:");
                            string directorName = Console.ReadLine().ToString();
                            Department NewDepartment = DepartmentsIntrface.AddDepartment(departmentName, NewType);
                            NewDepartment.Director = directorName;
                        }
                        catch (IndexOutOfRangeException MyException)
                        {
                            Console.WriteLine("Неверный выбор!");
                        }
                        catch (Exception MyException)
                        {
                            Console.WriteLine(MyException.Message);
                        }
			            break;
		            }
		            case '1': //Вывод информации об отделе
                    {
                        try
                        {
                            Department MyDepartment = DepartmentFromConsole(MyMart);
                            Console.WriteLine(MyDepartment.ToString());
                            break;
                        }
                        catch (Exception MyException)
                        {
                            Console.WriteLine(MyException.Message);
                        }
                        break;
		            }
		            case '2':
		            {
                        Console.WriteLine("Enter department name:");
                        string departmentName = Console.ReadLine().ToString();
                        Department MyDepartment = DepartmentsIntrface.RemoveDepartment(departmentName);
			            break;
		            }
		            case '3'://Добавить товар
                    {
                        ProductType NewType;
                        Product NewProduct;
                        Console.WriteLine("Choose type:");
                        Console.WriteLine("0 - electronics");
                        Console.WriteLine("1 - food");
                        Console.WriteLine("2 - sport");
                        Console.WriteLine("3 - wear");
                        Console.WriteLine("4 - gifts");
                        Console.WriteLine("5 - shoes");
                        Console.WriteLine("6 - toys");
                        Console.WriteLine("7 - other");
                        char keyType = Console.ReadKey().KeyChar;
                        try
                        {
                            NewType = (ProductType)int.Parse(keyType.ToString());
                            if (!Enum.IsDefined(typeof(ProductType), NewType))
                                throw new IndexOutOfRangeException();
                            IProductsManagement ProductsIntrface;
                            Department MyDepartment = DepartmentFromConsole(MyMart);
                            Console.WriteLine("Enter product name:");
                            string productName = Console.ReadLine().ToString();
                            Console.WriteLine("Enter product manufacter:");
                            string productManufacter = Console.ReadLine().ToString();
                            ProductsIntrface = (IProductsManagement)MyDepartment;
                            NewProduct=ProductsIntrface.AddProduct(productName, NewType);
                            NewProduct.Manufacter = productManufacter;
                        }
                        catch (IndexOutOfRangeException MyException)
                        {
                            Console.WriteLine("Неверный выбор!");
                        }
                        catch (Exception MyException)
                        {
                            Console.WriteLine(MyException.Message);
                        }
			            break;
		            }
		            case '4'://Информация о товаре
		            {
                        try
                        {
                            Department MyDepartment = DepartmentFromConsole(MyMart);
                            Product MyProduct = ProductFromConsole(MyDepartment);
                            Console.WriteLine(MyProduct.ToString());
                            foreach (string property in MyProduct.GetAllProperties())
                                Console.WriteLine("{0} = {1}", property, MyProduct.GetProperty(property));
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Такой объект не существует!");
                        }
			            break;
		            }
		            case '5'://Удалить товар из отдела
		            {
                        Department MyDepartment = DepartmentFromConsole(MyMart);
                        Product MyProduct = ProductFromConsole(MyDepartment);
                        IProductsManagement ProductsIntrface;
                        ProductsIntrface = (IProductsManagement)MyDepartment;
                        ProductsIntrface.RemoveProduct(MyProduct.Name);
                        break;
		            }
		            case '6'://Вывод всех отделов
		            {
                        try
                        {
                            foreach(Department EachDepartment in MyMart.GetAllDepartments())
                                Console.WriteLine(EachDepartment.ToString());
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Такой отдел не найден!");
                        }
                        Console.ReadKey();
			            break;
		            }
		            case '7'://Вывод всех товаров отдела
		            {
                        try
                        {
                            Department MyDepartment = DepartmentFromConsole(MyMart);
                            foreach (Product EachProduct in MyDepartment.GetAllProducts())
                                Console.WriteLine(EachProduct.ToString());
                        }
                        catch(NullReferenceException)
                        {
                            Console.WriteLine("Такой отдел не найден!");
                        }
                        Console.ReadKey();
                        break;
                        
		            }
		            case '8'://Правка товара
		            {
                        Department MyDepartment = DepartmentFromConsole(MyMart);
                        Product MyProduct = ProductFromConsole(MyDepartment);
                        Console.WriteLine("Enter new price:");
                        decimal newPrice;
                        
                        try
                        {
                            newPrice = decimal.Parse(Console.ReadLine());
                            MyProduct.Price = newPrice;
                            Console.WriteLine("Enter new name:");
                            string productName = Console.ReadLine().ToString();
                            MyProduct.Name = productName;
                            MyProduct.Price = newPrice;
                            foreach (string property in MyProduct.GetAllProperties())
                            {
                                Console.WriteLine("Enter " + property + ":");
                                string propertyValue = Console.ReadLine();
                                if (propertyValue != "")
                                    MyProduct.SetProperty(property, propertyValue);
                            }
                        }
                        catch (Exception MyException)
                        {
                            Console.WriteLine(MyException.Message);
                        }
			            break;
		            }
		            case '9'://Правка отдела
		            {
                        Department MyDepartment = DepartmentFromConsole(MyMart);
                        DepartmentType Enumeration;
                        //string newName;
                        //string newDirector;
                        Console.WriteLine("Enter new name:");
                        MyDepartment.Name = Console.ReadLine();
                         Console.WriteLine("Enter new Director:");
                        MyDepartment.Director = Console.ReadLine();
                        Console.WriteLine("Choose new type:");
                        Console.WriteLine("0 - electronics");
                        Console.WriteLine("1 - food");
                        Console.WriteLine("2 - sport");
                        Console.WriteLine("3 - wear");
                        Console.WriteLine("4 - gifts");
                        Console.WriteLine("5 - shoes");
                        Console.WriteLine("6 - toys");
                        Console.WriteLine("7 - other");
                        char newType = Console.ReadKey().KeyChar;
                        try
                        {
                            if (Enum.IsDefined(typeof(DepartmentType), int.Parse(newType.ToString())))
                                MyDepartment.Type = (DepartmentType)int.Parse(newType.ToString());
                            else
                                Console.WriteLine("Неверный выбор!");
                        }
                        catch (Exception MyException)
                        {
                            Console.WriteLine(MyException.Message);
                        }
			            break;
		            }
                    case 's'://сериализация
                    {
                        
                        using (Stream s = File.Create("Mart.xml"))
                            xs.Serialize(s, MyMart);
                        break;
                    }
                    case 'd'://десериализация
                    {
                        //XmlSerializer xs = new XmlSerializer(typeof(Mart));
                        using (Stream s = File.Open("Mart.xml",FileMode.Open,FileAccess.Read))
                            MyMart=(Mart)xs.Deserialize(s);
                        break;
                    }
		            default:
                       Console.WriteLine(key); 
                       break;
		            //system("cls");
		        }
            } while (key != ' ');
        }
       static Department DepartmentFromConsole(Mart MyMart)
        {
            Console.WriteLine("Enter department name:");
            string departmentName = Console.ReadLine().ToString();
            return MyMart.GetDepartment(departmentName);
        }
       static Product ProductFromConsole(Department MyDepartment)
       {
           Console.WriteLine("Enter product name:");
           string productName = Console.ReadLine().ToString();
           return MyDepartment.GetProduct(productName);
       }
    }
}
