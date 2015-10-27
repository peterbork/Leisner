using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class MeasurementController : ApiController {
        static List<Models.Measurement> measurementsList = new List<Models.Measurement>();

        [HttpGet]
        [ActionName("GetMeasurements")]
        public static List<Models.Measurement> GetMeasurements() {
            return measurementsList;
        }

        [HttpPost]
        [ActionName("Registration")]
        // /api/Measurement/Registration
        // Content-Type: application/json
        // Request body: [patient: {"PatientID": 1, "DeviceID": 1}]
        public void Registration([FromBody]Models.RegistrationPatient rp) {
            PatientController pc = new PatientController();
            Models.PatientDevice patientDevice = new Models.PatientDevice();

            List<Models.PatientDevice> patientDeviceList = pc.GetPatientDevices();

            foreach (Models.PatientDevice pd in patientDeviceList) {
                if (rp.PatientID == pd.Patient.ID && rp.DeviceID == pd.Device.ID) {
                    patientDevice = pd;
                }
            }

            int id = measurementsList.Count;
            patientDevice.Measurements.Add(new Models.Measurement(rp.Volume, rp.Time, rp.Method));
        }
    }
}
