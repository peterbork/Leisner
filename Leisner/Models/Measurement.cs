using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leisner.Models {
    public class Measurement {
        public int ID { get; set; }
        public double Volume { get; set; }
        public DateTime Time { get; set; }
        public string Method { get; set; }
    }
}