using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingEngine.Data.Models
{
    public class Rates
    {
        public double BasePremium { get; set; }
        public double StateFactor { get; set; }
        public double BusinessFactor { get; set; }
        public double HazardFactor { get; set; }

    }
}
