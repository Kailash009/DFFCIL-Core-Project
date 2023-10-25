using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClaim.DAL.Models
{
    public class EmpAdvanceTopUp : BaseModel
    {
        [Required]
        public long EmpAdvanceId { get; set; }
        [ForeignKey("EmpAdvanceId")]
        public virtual EmpAdvance EmpAdvance { get; set; }
        [Required]
        public double ReviseEstimentedAmount { get; set; }
        [Required]
        public double TopRequiredAmount { get; set; }
        public double? TopApprovedAmount { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public long? ApprovedById { get; set; }
        [ForeignKey("ApprovedById")]
        public virtual Employee? EmployeeApprovedBy { get; set; }
        public string PayTo { get; set; }
        public string? BankName { get; set; } = string.Empty;
        public string? AccountNumber { get; set; } = string.Empty;
        public string? IfscCode { get; set; } = string.Empty;
        public string? BeneficiaryName { get; set; }
    }
}
