using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models {
    public class PatientDevice {
        public int ID { get; set; }
        public DateTime HandOutDate { get; set; }
        public DateTime HandInDate { get; set; }
        public Patient Patient { get; set; }
        public Device Device { get; set; }
        public List<Measurement> Measurements { get; set; }

        public PatientDevice(int patientID, int deviceID) {
            List<Models.Patient> patientList = Controllers.PatientController.GetPatients();
            List<Models.Device> deviceList = Controllers.DeviceController.GetDevices();
            Models.Patient tempPatient = new Models.Patient();
            Models.Device tempDevice = new Models.Device();

            foreach (Models.Patient p in patientList) {
                if (patientID == p.ID) {
                    tempPatient = p;
                }
            }

            foreach (Models.Device d in deviceList) {
                if (deviceID == d.ID) {
                    tempDevice = d;
                }
            }

            this.ID = Controllers.PatientController.GetPatientDevices().Count + 1;
            this.HandOutDate = DateTime.Now;
            this.HandInDate = new DateTime(0000, 0, 0);
            this.Patient = tempPatient;
            this.Device = tempDevice;
            this.Measurements = new List<Measurement>();
        }
    }
}