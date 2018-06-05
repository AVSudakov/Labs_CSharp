using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
namespace lab21
{
    public class Mart:IDepartmentsManagement
    {
        public List<Department> Departments = new List<Department>();
        string fieldName;
        [XmlAttribute(DataType="string",AttributeName="Name")] 
        public string Name
        {
            get { return fieldName; }
            set { fieldName = value; }
        }
        public Mart()
        {
            Name = "Универмаг №1";
            //Конструктор
        }
         Department IDepartmentsManagement.AddDepartment(string departmentName,DepartmentType Type)
        {
            Department Department = this.GetDepartment(departmentName);
            if (Department == null)
            {
                Department = new Department(departmentName);
                Department.Type = Type;
                Departments.Add(Department);
            }
            else
                return null;
            return Department;
        }
         Department IDepartmentsManagement.RemoveDepartment(string departName)
        {
            Department MyDepartment = this.GetDepartment(departName);
             if (MyDepartment != null)
                 Departments.Remove(MyDepartment);
             return MyDepartment;
        }
         public Department GetDepartment(string departName)
        {
            foreach (Department Department in Departments)
            {
                if (Department.Name == departName)
                    return Department;
            }
            return null;
        }
        public Department[] GetAllDepartments()
        {
            return Departments.ToArray();
        }
    }
}
