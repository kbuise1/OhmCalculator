﻿using OhmCalc.Interfaces;
using OhmCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace OhmCalc.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Loads index page and fills drop down list
        /// </summary>
        /// <param name="model"></param>
        /// <returns>index view with model list values</returns>
        public ActionResult Index(CalculationModel model)
        {
            FillList(model);

            return View("Index",model);
        }
        
        /// <summary>
        /// Calls calculate method and returns results in partial view _calculations
        /// </summary>
        /// <param name="model"></param>
        /// <returns>partial view _calculations</returns>
        public ActionResult Calculate(CalculationModel model)
        {

            CalculateOhmValue(model);

            return PartialView("_Calculations", model);
        }
        
        /// <summary>
        /// Fills model list with corresponding color/value pairs
        /// </summary>
        /// <param name="model"></param>
        public void FillList(CalculationModel model)
        {
            var significantFigureColors = new Dictionary<float, string>()
            {
                {0,"black" },
                {1,"brown" },
                {2,"red" },
                {3, "orange" },
                {4, "yellow" },
                {5, "green" },
                {6, "blue" },
                {7, "violet" },
                {8, "gray" },
                {9, "white" }

            };

            var multiplierColors = new Dictionary<float, string>()
            {
                    {0.001f,"pink" },
                    {0.01f,"silver" },
                    {0.1f,"gold" },
                    {1,"black" },
                    {10,"brown" },
                    {100,"red" },
                    {1000, "orange" },
                    {10000, "yellow" },
                    {100000, "green" },
                    {1000000, "blue" },
                    {10000000, "violet" },
                    {100000000, "gray" },
                    {1000000000, "white" }
            };

            var toleranceColors = new Dictionary<float, string>()
            {
                    {0.1f,"silver"},
                    {0.05f,"gold"},
                    {0.01f,"brown"},
                    {0.02f,"red" },
                    {0.005f, "green" },
                    {0.0025f, "blue" },
                    {0.001f, "violet" },
                    {0.0005f, "gray" }
            };


            model.BandAColorList = new SelectList(significantFigureColors, "Key", "Value");
            model.BandBColorList = new SelectList(significantFigureColors, "Key", "Value");
            model.BandCColorList = new SelectList(multiplierColors, "Key", "Value");
            model.BandDColorList = new SelectList(toleranceColors, "Key", "Value");


        }


        /// <summary>
        /// Calculates ohm value and if tolerance value given defines the min and max range of ohm value
        /// </summary>
        /// <param name="model"></param>
        public void CalculateOhmValue(CalculationModel model)
        {

            model.OhmValue = (model.BandAValue * 10 + model.BandBValue) *model.BandCValue;
            model.Tolerance = model.BandDValue;
            model.MinOhm = model.OhmValue - (model.OhmValue * model.Tolerance);
            model.MaxOhm = model.OhmValue + (model.OhmValue * model.Tolerance);
 

        }



    }
}
 

