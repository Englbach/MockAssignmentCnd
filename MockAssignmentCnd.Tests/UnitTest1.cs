using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MockAssignmentCnd.Models;
using Moq;
using MockAssignmentCnd.Controllers;
using System.Linq;

namespace MockAssignmentCnd.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Create some mock products
            List<Products> products = new List<Products>()
            {
                new Products {Product_id=1, Name="Tivi LG", Description="It is the best tv on the word", Price=123.5 },
                new Products {Product_id=2 , Name="PC Dell", Description="", Price=257.5},
                new Products {Product_id=3, Name="Apple Iphone7", Description="Matte black", Price=863.2 }
            };

            //Mock the products, using mog
            Mock<IProductsServices> mockProductsServices = new Mock<IProductsServices>();

            //return all the products
            mockProductsServices.Setup(m => m.GetAll()).Returns(products);

            //return the products by name
            mockProductsServices.Setup(m => m.FindByName(It.IsAny<string>())).Returns((string s) => products.Where(x => x.Name == s).Single());

            //saving the products
            mockProductsServices.Setup(m => m.SaveProducts(It.IsAny<Products>())).Returns(
                (Products target) =>
                {
                    DateTime now = DateTime.Now;
                    if (target.Product_id.Equals(default(int)))
                    {
                        target.Date_Created = now;
                        target.Date_Modified = now;
                        target.Product_id = products.Count() + 1;
                        products.Add(target);
                    }
                    else
                    {
                        var original = products.Where(q => q.Product_id == target.Product_id).Single();
                        if(original!=null)
                        {
                            return false;
                        }
                        original.Name = target.Name;
                        original.Date_Modified = now;
                        original.Price = target.Product_id;
                        original.Description = target.Description;
                    }

                        return true;
                });

            // Complete the setup of our Mock Product
           // this.MockProductsServices = mockProductsServices.Object;

        }
        ///<summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        ///<summary>
        /// Our Mock Products Repository for use in testing
        ///</summary>
        public readonly IProductsServices MockProductsServices;

        ///<summary>
        ///Can we return all products
        /// </summary>

        [TestMethod]
        public void CanReturnAllProducts()
        {
            //try finding all products
            List<Products> testProducts = MockProductsServices.GetAll();
            //test if null
            Assert.IsNotNull(testProducts);
            //verify the correct number
            Assert.AreEqual(3, testProducts.Count);
        }

        ///<summary>
        ///Ca we return the products by name
        /// </summary>
        /// 
        [TestMethod]
        public void canReturnProductsByName()
        {
            //try finding name of products
            Products testProducts = this.MockProductsServices.FindByName("Tivi LG");
            Assert.IsNotNull(testProducts);
            //test type
            Assert.IsInstanceOfType(testProducts, typeof(Products));
            Assert.AreEqual(3, testProducts.Product_id);
        }
    }
}
