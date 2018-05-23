using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab21
{
    class Mart:IDepartmentsManagement
    {
        List<Department> Departments = new List<Department>();
        string fieldName;
        public string Name
        {
            get { return fieldName; }
            set { fieldName = value; }
        }
        public Mart()
        {
            //Конструктор
        }
         Department IDepartmentsManagement.AddDepartment(string DepartName,DepartmentType Type)
        {
            Department Department = new Department(DepartName);
            Department.Type = Type;
            Departments.Add(Department);
            return Department;
        }
         void IDepartmentsManagement.RemoveDepartment(string DepartName)
        {
            Departments.Remove(this.GetDepartment(DepartName));
        }
        public Department GetDepartment(string DepartmentName)
        {
            foreach (Department Department in Departments)
            {
                if (Department.Name == DepartmentName)
                    return Department;
            }
            return null;
        }
    }
}
