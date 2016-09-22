using MockAssignmentCnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockAssignmentCnd.Controllers
{
    public class ProductsServices : IProductsServices
    {
        public Products FindByName(string productName)
        {
            // That actually fetches all the Products from a database and creates a list
            throw new NotImplementedException();
        }

        public List<Products> GetAll()
        {
            // That actually fetches all the Products from a database and creates a list
            throw new System.NotImplementedException();
        }

        public bool SaveProducts(Products target)
        {
            // That actually fetches all the Products from a database and creates a list
            throw new NotImplementedException();
        }
    }
}