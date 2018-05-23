using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab21
{
    interface IProductsManagement
    {
        Product AddProduct(string ProductName,ProductType Type);
        Product RemoveProduct(string ProductName);

    }
}
