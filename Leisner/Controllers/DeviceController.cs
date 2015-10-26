using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class DeviceController : ApiController {
        List<Models.Device> deviceList = new List<Models.Device>() { new Models.Device(1)};

        [HttpGet]
        [ActionName("GetDevices")]
        // /api/device/GetDevices
        public List<Models.Device> GetDevices() {
            return deviceList;
        }
    }
}
