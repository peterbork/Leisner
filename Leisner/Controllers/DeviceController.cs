using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class DeviceController : ApiController {
        List<Models.Device> deviceList = new List<Models.Device>();

        [HttpGet]
        public List<Models.Device> GetDevices() {
            return deviceList;
        }
    }
}
