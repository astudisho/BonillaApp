using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonillaApp.Models
{
    public class DeviceDto
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }
    }
}
