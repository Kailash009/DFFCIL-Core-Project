using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class UplodDocType
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsBillable { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; internal set; }
    }
}
