using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonillaApp.Data.Models
{
    public class DeviceDbo
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<VoltageDbo> Voltajes { get; set; }
    }
}
