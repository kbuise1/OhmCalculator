using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OhmCalc.Models
{
    public class CalculationModel

    {

        public int BandAValue { get; set; }

        public int BandBValue { get; set; }

        public float BandCValue { get; set; }

        public float BandDValue { get; set; }

        public SelectList BandAColorList { get; set; }

        public SelectList BandBColorList { get; set; }
  
        public SelectList BandCColorList { get; set; }

        public SelectList BandDColorList { get; set; }

        public float OhmValue { get; set; }

        public float Tolerance { get; set; }

        public float MinOhm { get; set; }

        public float MaxOhm { get; set; }
    }
}