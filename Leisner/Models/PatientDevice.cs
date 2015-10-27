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


        public PatientDevice() { }
        public PatientDevice(int patientID, int deviceID) {
            Controllers.PatientController pc = new Controllers.PatientController();

            List<Models.Patient> patientList = pc.GetPatients();
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

            this.ID = pc.GetPatientDevices().Count + 1;
            this.HandOutDate = DateTime.Now;
            this.HandInDate = new DateTime(0001, 1, 1); // definerer en dato for længe siden, for at simulerer den ikke er fastsat
            this.Patient = tempPatient;
            this.Device = tempDevice;
            this.Measurements = new List<Measurement>();
        }
    }
}