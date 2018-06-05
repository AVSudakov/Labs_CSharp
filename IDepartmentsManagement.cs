using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab21
{
    interface IDepartmentsManagement
    {
        Department AddDepartment(string DepartmentName,DepartmentType Type);
        Department RemoveDepartment(string DepartmentName);
    }
}
