using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leisner.Models {
    public class PatientDevice {
        public int ID { get; set; }
        public DateTime HandOutDate { get; set; }
        public DateTime HandInDate { get; set; }
        public Patient Patient { get; set; }
        public Device Device { get; set; }
        public List<Measurement> Measurements { get; set; }
    }
}