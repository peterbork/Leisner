using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class MeasurementController : ApiController {
        static List<Models.Measurement> measurementsList;

        [HttpGet]
        public static List<Models.Measurement> GetMeasurements() {
            return measurementsList;
        }

        [HttpPost]
        public void Registration(double volume, DateTime time, string method) {
            if (method.ToLower() == "manual") {
                int id = measurementsList.Count;

                measurementsList.Add(new Models.Measurement(id, volume, time, method));
            } else if (method.ToLower() == "automatic") {
                // Automatic
            }
        }
    }
}
