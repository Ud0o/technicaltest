using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustEatTechnicalTest.Models
{
    public class DeliveryEtaMinutes
    {
        public object Approximate { get; set; }
        public int RangeLower { get; set; }
        public int RangeUpper { get; set; }
    }
}
