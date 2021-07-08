using BonillaApp.Data.Context;
using BonillaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BonillaApp.Data.Repository
{
    public class DeviceRepository
    {
        private readonly MonitorContext _monitorContext;
        public DeviceRepository(MonitorContext monitorContext)
        {
            _monitorContext = monitorContext;
        }

        public async Task<EntityEntry<DeviceDbo>> InsertAsync(DeviceDbo device)
        {
            var task = await _monitorContext.Devices.AddAsync(device);

            return task;
        }

        public Task<List<DeviceDbo>> GetAllAsync(CancellationToken ct = default)
        {
            var task = _monitorContext.Devices.ToListAsync(ct);

            return task;
        }

        public Task<int> SaveAsync(CancellationToken ct = default)
        {
            var task = _monitorContext.SaveChangesAsync(ct);

            return task;
        }
    }
}
