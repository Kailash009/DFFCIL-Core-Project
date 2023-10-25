using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class EmpAdvanceStatus : BaseModel
    {
        [Required]
        public long AdvanceId { get; set; }
        [ForeignKey("AdvanceId")]
        public EmpAdvance EmpAdvance { get; set; } 
        [ForeignKey("StatusId")]
        public long StatusId { get; set; }
        public AdvanceStatusCategory AdvanceStatusCategory { get; set; } 
       // public string Status { get; set; }
    }
}
