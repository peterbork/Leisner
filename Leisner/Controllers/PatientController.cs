using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers{
    public class PatientController : ApiController {
        static List<Models.PatientDevice> patientDeviceList = new List<Models.PatientDevice>();
        static List<Models.Patient> patientList = new List<Models.Patient>() { new Models.Patient(0, "Nick", 22, "male") , new Models.Patient(1, "Jonas", 22, "male") };
        List<Models.Device> deviceList = new List<Models.Device>();

        [HttpGet]
        [ActionName("GetPatients")]
        // Get
        // api/Patient
        public List<Models.Patient> GetPatients() {
            return patientList;
        }

        [HttpGet]
        [ActionName("GetPatientDevices")]
        // Get
        // api/Patient
        public List<Models.PatientDevice> GetPatientDevices() {
            return patientDeviceList;
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
        public void HandOutDevice([FromBody]int patientID, int deviceID) {
            Models.PatientDevice _patientDevice = new Models.PatientDevice(patientID, deviceID);

            patientDeviceList.Add(_patientDevice);
        }

        [HttpPost]
        public void HandInDevice(Models.PatientDevice patientDevice) { 
            patientDevice.HandInDate = DateTime.Now;
        }

        [HttpGet]
        [ActionName("SearchMeasurements")]
        public List<Models.Measurement> SearchMeasurements(string searchType, string searchValue, Models.Patient patient) {
            List<Models.PatientDevice> tempPatientDeviceList = new List<Models.PatientDevice>();
            List<Models.Measurement> tempMeasurementList = new List<Models.Measurement>();
            List<Models.Measurement> measurementList = new List<Models.Measurement>();

            tempPatientDeviceList = patientDeviceList;

            foreach (Models.PatientDevice pd in tempPatientDeviceList) {
                if (pd.Patient.Name == patient.Name) {
                    foreach (Models.Measurement m in pd.Measurements) {
                        tempMeasurementList.Add(m);
                    }
                }
            }

            if (searchType == "volume") {
                foreach (Models.Measurement m in tempMeasurementList) {
                    if (double.Parse(searchValue) == m.Volume) {
                        measurementList.Add(m);
                    }
                }
            }

            if (searchType == "date") {
                foreach (Models.Measurement m in tempMeasurementList) {
                    if (Convert.ToDateTime(searchValue) == m.Time) {
                        measurementList.Add(m);
                    }
                }
            }

            if (searchType == "method") {
                foreach (Models.Measurement m in tempMeasurementList) {
                    if (searchValue.ToLower() == m.Method) {
                        measurementList.Add(m);
                    }
                }
            }

            return measurementList;
        }
    }
}
