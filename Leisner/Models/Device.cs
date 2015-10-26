using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models {
    public class Device {
        public int ID { get; set; }
        public Device( int id) {
            this.ID = id;
        }
    }
}