using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication.Arch.Controllers;

namespace WebApplication.Arch.Tests.Controllers
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestMethod]
        [DataRow("1234", "567","1234567")]
        [DataRow("12", "56", "1256")]
        public void CategoryTitle_Test(string sName , string sDesc , string sResult)
        {
            // Arrange
            Models.mCategory Catg = new Models.mCategory { CategoryID = 1, CategoryName = sName, Description = sDesc };

            // Act


            // Assert
            Assert.AreEqual(sResult, Catg.CategoryTitle );
        }


        [TestMethod]
        public void CategoryTitleMethod_Test()
        {
            // Arrange
            Models.mCategory Catg = new Models.mCategory { CategoryID = 1, CategoryName = "TestName", Description = "Test Description" };

            // Act


            // Assert
            Assert.AreEqual(Catg.CategoryTitle, Catg.Title());
        }


    }
}
