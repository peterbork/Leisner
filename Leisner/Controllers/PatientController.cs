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
        // api/Patient/GetPatients
        public List<Models.Patient> GetPatients() {
            return patientList;
        }

        [HttpGet]
        [ActionName("GetPatientDevices")]
        // Get
        // api/Patient/GetPatientDevices
        public List<Models.PatientDevice> GetPatientDevices() {
            return patientDeviceList;
        }

        [HttpPost]
        [ActionName("RegisterPatient")]
        // Content-Type: application/json
        // api/Patient/RegisterPatient
        // {"ID":2,"Name":"peter","Age":22,"Sex":"male"}
        public void RegisterPatient([FromBody]Models.Patient patient) {
            //int id = patientList.Count;
            Models.Patient _patient = new Models.Patient(patient.ID, patient.Name, patient.Age, patient.Sex);

            patientList.Add(_patient);
        }

        [HttpPost]
        [ActionName("HandOutDevice")]
        // /api/Patient/HandOutDevice
        // Content-Type: application/json
        // Request body: [patient: {"PatientID": 1, "DeviceID": 1}]
        public void HandOutDevice([FromBody]Models.PatientAndDeviceId patientanddeviceid) {
            Models.PatientDevice _patientDevice = new Models.PatientDevice(patientanddeviceid.PatientID, patientanddeviceid.DeviceID);

            patientDeviceList.Add(_patientDevice);
        }

        [HttpPost]
        [ActionName("HandInDevice")]
        // /api/Patient/HandInDevice
        // Content-Type: application/json
        // Request body: [patient: {"PatientID": 1, "DeviceID": 1}]
        public void HandInDevice([FromBody]Models.PatientAndDeviceId patientanddeviceid) {

            int patientID = patientanddeviceid.PatientID;
            int deviceID = patientanddeviceid.DeviceID;
            Models.PatientDevice patientDevice = new Models.PatientDevice();

            foreach (Models.PatientDevice pd in patientDeviceList) {
                if (patientID == pd.Patient.ID && deviceID == pd.Device.ID) {
                    patientDevice = pd;
                }
            }

            patientDevice.HandInDate = DateTime.Now;
        }

        [HttpGet]
        [ActionName("SearchMeasurements")]
        // /api/Patient/SearchMeasurements?searchType=volume&searchValue=5&patientID=1
        // Content-Type: application/json
        public List<Models.Measurement> SearchMeasurements([FromBody]Models.SearchMeasurements searchMeasurement) {
            List<Models.PatientDevice> tempPatientDeviceList = new List<Models.PatientDevice>();
            List<Models.Measurement> tempMeasurementList = new List<Models.Measurement>();
            List<Models.Measurement> measurementList = new List<Models.Measurement>();

            tempPatientDeviceList = patientDeviceList;

            foreach (Models.PatientDevice pd in tempPatientDeviceList) {
                if (pd.Patient.Name == searchMeasurement.Patient.Name) {
                    foreach (Models.Measurement m in pd.Measurements) {
                        tempMeasurementList.Add(m);
                    }
                }
            }

            if (searchMeasurement.SearchType == "volume") {
                foreach (Models.Measurement m in tempMeasurementList) {
                    if (double.Parse(searchMeasurement.SearchValue) == m.Volume) {
                        measurementList.Add(m);
                    }
                }
            }

            if (searchMeasurement.SearchType == "date") {
                foreach (Models.Measurement m in tempMeasurementList) {
                    if (Convert.ToDateTime(searchMeasurement.SearchValue) == m.Time) {
                        measurementList.Add(m);
                    }
                }
            }

            if (searchMeasurement.SearchType == "method") {
                foreach (Models.Measurement m in tempMeasurementList) {
                    if (searchMeasurement.SearchValue.ToLower() == m.Method) {
                        measurementList.Add(m);
                    }
                }
            }

            return measurementList;
        }
    }
}
