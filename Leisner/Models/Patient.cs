using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leisner.Models {
    public class Patient {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
    }
}