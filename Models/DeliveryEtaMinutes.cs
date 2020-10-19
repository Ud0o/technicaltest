using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustEat.Api.Models
{
    public class DeliveryEtaMinutes
    {
        public object Approximate { get; set; }
        public int RangeLower { get; set; }
        public int RangeUpper { get; set; }
    }
}
