﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models {
    public class Measurement {
        public int ID { get; set; }
        public double Volume { get; set; }
        public DateTime Time { get; set; }
        public string Method { get; set; }

        public Measurement(double volume, DateTime time, string method) {
            this.ID = Controllers.MeasurementController.GetMeasurements().Count + 1;
            this.Volume = volume;
            this.Time = time;
            this.Method = method;
        }
    }
}