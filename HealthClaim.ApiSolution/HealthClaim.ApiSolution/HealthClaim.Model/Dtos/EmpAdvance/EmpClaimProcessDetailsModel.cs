using HealthClaim.Utility.Eumus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HealthClaim.Model.Dtos.EmpAdvance
{
    public class EmpClaimProcessDetailsModel
    {
        [Required]
        public long AdvanceId { get; set; }
        [Required]
        public long SenderId { get; set; }
        [Required]
        public long RecipientId { get; set; }
        [Required]
        public RecordMasterClaimTypes ClaimTypeId { get; set; }
        [Required]
        public RecordMasterClaimStatusCategory StatusId { get; set; }
        [Required]
        public double ApprovalAmount { get; set; }
    }
}
