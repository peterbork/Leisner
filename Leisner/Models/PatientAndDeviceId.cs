using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models {
    public class PatientAndDeviceId {
        public int PatientID { get; set; }
        public int DeviceID { get; set; }

        public PatientAndDeviceId(int patientid, int deviceid) {
            this.PatientID = patientid;
            this.DeviceID = deviceid;
        }
    }
}