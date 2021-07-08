using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using BonillaApp.Data.Models;
using BonillaApp.Models;

namespace BonillaApp.Mapper
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap<DeviceDto, DeviceDbo>().ReverseMap();
            CreateMap<VoltajeDto, VoltageDbo>();
        }
    }
}
