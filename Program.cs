using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab21
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductsManagement ProductsIntrface;
            IDepartmentsManagement DepartmentsIntrface;
            Mart Mart = new Mart();
            DepartmentsIntrface = (IDepartmentsManagement)Mart;
            Department Department = DepartmentsIntrface.AddDepartment("electronics",DepartmentType.Electronics);
            ProductsIntrface = (IProductsManagement)Mart.GetDepartment("electronics");
            Product Smartphone = ProductsIntrface.AddProduct("Smartphone Samsung Galaxy S3",ProductType.Electronics);
            Smartphone.Price = 12500;
            Smartphone.Manufacter = "Samsung";
            Console.WriteLine(Smartphone.ToString());
            //Console.WriteLine(m.GetDepartment("electronics").Name);
            DepartmentsIntrface.RemoveDepartment("electronics");
            MainLoop();
        }
        static void MainLoop()
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
		        Console.WriteLine("9 - change department");
                key = Console.ReadKey().KeyChar;
		        Console.Clear();
                switch (key)
		        {
		            case '0':
		            {	
			            break;
		            }
		            case '1':
		            {
                        break;
		            }
		            case '2':
		            {
			            break;
		            }
		            case '3':
		            {
			            break;
		            }
		            case '4':
		            {
			            break;
		            }
		            case '5':
		            {
                        break;
		            }
		            case '6':
		            {
			            break;
		            }
		            case '7':
		            {
                        break;
		            }
		            case '8':
		            {
			            break;
		            }
		            case '9':
		            {
			            break;
		            }

		            default:break;
		            //system("cls");
		        }
            } while (key != ' ');
        }
    }
}
