using MockAssignmentCnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockAssignmentCnd.Controllers
{
    public interface IProductsServices
    {
        List<Products> GetAll();
        Products FindByName(string productName);
        bool SaveProducts(Products target);
    }
}