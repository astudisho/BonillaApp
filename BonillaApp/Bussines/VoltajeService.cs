using BonillaApp.Data.Models;
using BonillaApp.Data.Repository;
using BonillaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using System.Threading;

namespace BonillaApp.Bussines
{
    public class VoltajeService
    {
        public readonly VoltajeRepository _voltajeRepository;
        public readonly IMapper _mapper;
        public VoltajeService(VoltajeRepository voltajeRepository, IMapper mapper)
        {
            _voltajeRepository = voltajeRepository;
            _mapper = mapper;
        }

        public async Task<VoltajeDto> Save(VoltajeDto voltajeDto, CancellationToken ct)
        {
            var dbo = _mapper.Map<VoltageDbo>(voltajeDto);

            await _voltajeRepository.Insert(dbo, ct);

            await _voltajeRepository.SaveAsync(ct);

            return voltajeDto;
        }
    }
}
