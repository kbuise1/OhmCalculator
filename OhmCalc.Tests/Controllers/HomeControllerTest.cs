using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OhmCalc;
using OhmCalc.Controllers;
using OhmCalc.ViewModels;

namespace OhmCalc.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Test_Index_View()
        {
            ////Arrange
            HomeController controller = new HomeController();
            var model = new CalculationModel();

            ////Act
            ViewResult result = controller.Index(model) as ViewResult;

            ////Assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void Test_Index_Fills_List()
        {
            //// Arrange
            HomeController controller = new HomeController();
            var significantFigureColors = new Dictionary<float, string>()
            {
                {0,"black" },
                {1,"brown" }
            };

            var multiplierColors = new Dictionary<float, string>()
            {
                    {0.001f,"pink" },
                    {0.01f,"silver" }
            };

            var toleranceColors = new Dictionary<float, string>()
            {
                    {0.1f,"silver"},
                    {0.05f,"gold"}
            };

            var model = new CalculationModel()
            {
                BandAColorList = new SelectList(significantFigureColors, "Key", "Value"),
                BandBColorList = new SelectList(significantFigureColors, "Key", "Value"),
                BandCColorList = new SelectList(multiplierColors, "Key", "Value"),
                BandDColorList = new SelectList(toleranceColors, "Key", "Value")

            };


            //// Act
            ViewResult result = controller.Index(model) as ViewResult;

            //// Assert
            Assert.AreEqual(model, result.Model);
            CalculationModel currentmodel = result.Model as CalculationModel;
            Assert.IsNotNull(currentmodel.BandAColorList);
            Assert.IsNotNull(currentmodel.BandBColorList);
            Assert.IsNotNull(currentmodel.BandCColorList);
            Assert.IsNotNull(currentmodel.BandDColorList);
        }

        [TestMethod]
        public void Test_Calculate_View()
        {
            ////Arrange
            HomeController controller = new HomeController();
            var model = new CalculationModel();

            ////Act
            PartialViewResult result = controller.Calculate(model) as PartialViewResult;

            ////Assert
            Assert.AreEqual("_Calculations", result.ViewName);
        }

        [TestMethod]
        public void Test_Calculate_Method_Results()
        {

            ////Arrange
            HomeController controller = new HomeController();
            var model = new CalculationModel()
            {
                BandAValue = 1,
                BandBValue = 2,
                BandCValue = 100,
                BandDValue = 0.005f

            };

            //// Act
            PartialViewResult result = controller.Calculate(model) as PartialViewResult;


            //// Assert 
            Assert.IsInstanceOfType(result.Model, typeof(CalculationModel));
            CalculationModel currentmodel = result.Model as CalculationModel;
            if (currentmodel != null)
            {
                Assert.AreEqual(1200, currentmodel.OhmValue);
                Assert.AreEqual(1206, currentmodel.MaxOhm);
                Assert.AreEqual(1194, currentmodel.MinOhm);
                Assert.AreEqual(0.005, currentmodel.Tolerance, 0.1);
            }


        }

    }
}
