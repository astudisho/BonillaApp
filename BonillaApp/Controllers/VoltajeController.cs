using BonillaApp.Bussines;
using BonillaApp.Data.Context;
using BonillaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BonillaApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoltajeController : ControllerBase
    {
        private readonly VoltajeService _voltajeService;
        private readonly ILogger<VoltajeController> _logger;
        public VoltajeController(ILogger<VoltajeController> logger, VoltajeService voltajeService)
        {
            _voltajeService = voltajeService;
            _logger = logger;            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = new { NetVersion = Environment.Version, OsVersion = Environment.OSVersion };
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(VoltajeDto voltajeDto, CancellationToken ct)
        {
            var result = await _voltajeService.Save(voltajeDto, ct);
            return Ok(result);
        }
    }
}
