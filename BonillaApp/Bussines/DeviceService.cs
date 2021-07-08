using AutoMapper;
using BonillaApp.Data.Models;
using BonillaApp.Data.Repository;
using BonillaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BonillaApp.Bussines
{
    public class DeviceService
    {
        public readonly DeviceRepository _deviceRepository;
        public readonly IMapper _mapper;
        public DeviceService(DeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }

        public async Task<DeviceDto> Insert(DeviceDto device, CancellationToken ct)
        {
            var dbo = _mapper.Map<DeviceDbo>(device);

            var entry = await _deviceRepository.InsertAsync(dbo);
            await _deviceRepository.SaveAsync(ct);

            var dto = _mapper.Map<DeviceDto>(entry.Entity);

            return dto;
        }

        public async Task<List<DeviceDto>> GetAll(CancellationToken ct)
        {
            var devices = await _deviceRepository.GetAllAsync(ct);

            var devicesDto = _mapper.Map<List<DeviceDto>>(devices);

            return devicesDto;
        }
    }
}
