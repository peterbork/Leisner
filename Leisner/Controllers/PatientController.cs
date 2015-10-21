using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers{
    public class PatientController : ApiController {

        List<Models.PatientDevice> patientDeviceList = new List<Models.PatientDevice>();
        List<Models.Patient> patientList = new List<Models.Patient>();
        List<Models.Device> deviceList = new List<Models.Device>();
        
        

        [HttpPost]
        public void RegisterPatient(string name, int age, string sex) {
            int id = patientList.Count;

            Models.Patient patient = new Models.Patient(id, name, age, sex);

            patientList.Add(patient);
        }

        [HttpGet]
        public List<Models.Patient> Get() {
            return patientList;
        }

        [HttpPost]
        public void HandOutDevice(Models.Patient patient, Models.Device device) {
            Models.PatientDevice patientDevice = new Models.PatientDevice();
            patientDevice.HandOutDate = DateTime.Now;
            patientDevice.Patient = patient;

            patientDeviceList.Add(patientDevice);
        }

        [HttpPost]
        public void HandInDevice(Models.PatientDevice patientDevice) { 
            patientDevice.HandInDate = DateTime.Now;
        }

        [HttpGet]
        public List<Models.Measurement> SearchMeasurements(string searchType, string searchValue) {
            List<Models.Measurement> measurementList = new List<Models.Measurement>();
            measurementList = MeasurementController.GetMeasurements();

            // Indsæt søgeprut og kriterierprut

            return measurementList;
        }
    }
}
