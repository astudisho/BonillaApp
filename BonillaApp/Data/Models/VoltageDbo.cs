using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BonillaApp.Data.Models
{
    public class VoltageDbo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Device")]
        public int DeviceId { get; set; }
        public float Voltaje { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }
        public DateTime InsertedAt { get; set; }
        public virtual DeviceDbo Device { get; set; }
    }
}
