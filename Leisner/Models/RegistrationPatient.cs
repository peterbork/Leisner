using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models {
    public class RegistrationPatient {
        public double Volume { get; set; }
        public DateTime Time { get; set; }
        public string Method { get; set; }
        public int PatientID { get; set; }
        public int DeviceID { get; set; }

        public RegistrationPatient(double volume, DateTime time, string method, int patientID, int deviceID) {
            this.Volume = volume;
            this.Time = time;
            this.Method = method;
            this.PatientID = patientID;
            this.DeviceID = deviceID;
        }
    }
}