using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class DoctorReview:BaseModel
    {
        public long ClaimId { get; set; }
        [ForeignKey("ClaimId")]
        public virtual EmpClaim EmpClaim { get; set; }
        public string? AddmisionAdviseComment { get; set; }
        public string? DischargeSummaryComment { get; set; }
        public string? InvestigationReportComment { get; set; }
        [Required]
        public bool IsSpecialDisease { get; set; }
        public bool? IsTaxable { get; set; }
        public string? Comment_1 { get; set; }
        public string? Comment_2 { get; set; }
        public string? Comment_3 { get; set; }
        public string? Comment_4 { get; set; }
        public string? Comment_5 { get; set; }
    }
}
