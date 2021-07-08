using BonillaApp.Bussines;
using BonillaApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BonillaApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly DeviceService _deviceService;
        public DeviceController(DeviceService deviceService)
        {
            _deviceService = deviceService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            var devices = await _deviceService.GetAll(ct);

            return Ok(devices);
        }
        [HttpPut]
        public async Task<IActionResult> Put(DeviceDto device, CancellationToken ct)
        {
            await _deviceService.Insert(device, ct);

            return Ok();
        }
    }
}
