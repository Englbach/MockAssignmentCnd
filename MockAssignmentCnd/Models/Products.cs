using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockAssignmentCnd.Models
{
    public class Products
    {
        public int Product_id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime Date_Created { get; set; }
        public DateTime Date_Modified { get; set; }

    }
}