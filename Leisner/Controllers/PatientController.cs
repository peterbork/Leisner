using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers{
    public class PatientController : ApiController {

        List<Models.PatientDevice> patientDeviceList = new List<Models.PatientDevice>();
        static List<Models.Patient> patientList = new List<Models.Patient>() { new Models.Patient(0, "Nick", 22, "male") , new Models.Patient(1, "Jonas", 22, "male") };
        List<Models.Device> deviceList = new List<Models.Device>();

        [HttpGet]
        [ActionName("GetPatients")]
        // Get
        // api/Patient
        public List<Models.Patient> GetPatients() {
            return patientList;
        }

        [HttpPost]
        [ActionName("RegisterPatient")]
        // Content-Type: application/json
        // {"ID":2,"Name":"peter","Age":22,"Sex":"male"}
        public void RegisterPatient([FromBody]Models.Patient patient) {
            //int id = patientList.Count;

            Models.Patient _patient = new Models.Patient(patient.ID, patient.Name, patient.Age, patient.Sex);

            patientList.Add(_patient);
        }

        [HttpPost]
        [ActionName("HandOutDevice")]
        // Content-Type: application/json
        // Request body: [patient: {"ID":2,"Name":"peter","Age":22,"Sex":"male"}, device: {"ID:"1}] virker ikke
        //FromBody]Models.Patient patient, [FromBody]Models.Device device --- old input
        public void HandOutDevice([FromBody]Models.PatientDevice patientDevice) {
            Models.Patient patient = patientDevice.Patient;
            Models.Device device = patientDevice.Device;

            Models.PatientDevice _patientDevice = new Models.PatientDevice();
            _patientDevice.HandOutDate = DateTime.Now;
            _patientDevice.Patient = patient;
            _patientDevice.Device = device;

            patientDeviceList.Add(_patientDevice);
        }

        //[HttpPost]
        //public void HandInDevice(Models.PatientDevice patientDevice) { 
        //    patientDevice.HandInDate = DateTime.Now;
        //}

        [HttpGet]
        [ActionName("SearchMeasurements")]
        public List<Models.Measurement> SearchMeasurements(string searchType, string searchValue) {
            List<Models.Measurement> measurementList = new List<Models.Measurement>();
            measurementList = MeasurementController.GetMeasurements();

            // Indsæt søgeprut og kriterierprut

            return measurementList;
        }
    }
}
