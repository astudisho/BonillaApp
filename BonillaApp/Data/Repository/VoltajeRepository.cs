using BonillaApp.Data.Context;
using BonillaApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace BonillaApp.Data.Repository
{
    public class VoltajeRepository
    {
        private readonly MonitorContext _monitorContext;
        public VoltajeRepository(MonitorContext monitorContext)
        {
            _monitorContext = monitorContext;
        }

        public async Task Insert(VoltageDbo voltage, CancellationToken ct)
        {
            var task = await _monitorContext.Voltajes.AddAsync(voltage, ct);
        }

        public Task<int> SaveAsync(CancellationToken ct = default)
        {
            var task = _monitorContext.SaveChangesAsync(ct);

            return task;
        }
    }
}
