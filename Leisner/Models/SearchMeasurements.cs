using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models {
    public class SearchMeasurements {
        public string SearchType { get; set; }
        public string SearchValue { get; set; }
        public Patient Patient { get; set; }

        public SearchMeasurements(string searchType, string searchValue, int patientID) {

            Controllers.PatientController pc = new Controllers.PatientController();
            List<Models.Patient> patientList = pc.GetPatients();
            Patient patient = new Patient();


            foreach (Models.Patient p in patientList) {
                if (patientID == p.ID) {
                    patient = p;
                }
            }

            this.SearchType = searchType;
            this.SearchValue = searchValue;
            this.Patient = patient;
        }
    }
}