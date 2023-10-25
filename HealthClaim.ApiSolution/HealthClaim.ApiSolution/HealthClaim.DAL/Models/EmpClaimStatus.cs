using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class EmpClaimStatus : BaseModel
    {
        [Required]
        public long ClaimId { get; set; }
        [ForeignKey("ClaimId")]
        public virtual EmpClaim EmpClaim { get; set; }
        public long ClaimTypeId { get; set; }
        [ForeignKey("ClaimTypeId")]
        public virtual ClaimType ClaimType { get; set; }

        public long StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual ClaimStatusCategory ClaimStatusCategory { get; set; }
        // public string Status { get; set; }
        public long? EmpAdvanceTopId { get; set; }
        [ForeignKey("EmpAdvanceTopId")]
        public virtual EmpAdvanceTopUp? EmpAdvanceTopUp { get; set; }

    }
}
