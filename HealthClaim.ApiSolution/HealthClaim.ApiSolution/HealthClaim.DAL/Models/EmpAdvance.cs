using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClaim.DAL.Models
{
    public class EmpAdvance : BaseModel
    {

        public long EmplId { get; set; }
        [ForeignKey("EmplId")]
        public virtual Employee Employee { get; set; }
        public long PatientId { get; set; }
        [ForeignKey("PatientId")]
        public EmpFamily EmpFamily { get; set; }

        public long RequestSubmittedById { get; set; }
        [ForeignKey("RequestSubmittedById")]
        public virtual Employee EmployeeRequestSubmited { get; set; }

        public long ClaimId { get; set; }
        [ForeignKey("ClaimId")]
        public virtual EmpClaim EmpClaim { get; set; }

        public long Claim_TypeId { get; set; }
        [ForeignKey("Claim_TypeId")]
        public virtual ClaimType ClaimType { get; set; }

        public string RequestName { get; set; }
        public DateTime AdvanceRequestDate { get; set; }
        public double AdvanceAmount { get; set; }
       
        public string Reason { get; set; }
        public string PayTo { get; set; }
        public DateTime? LikelyDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public double? ApprovedAmount { get; set; }

        public long? ApprovedById { get; set; }
        [ForeignKey("ApprovedById")]
        public virtual Employee? EmployeeApproveBy { get; set; }

        [Required]
        public string HospitalName { get; set; }
        [Required]
        public string HospitalRegNo { get; set; }
        [Required]
        public DateTime DateOfAdmission { get; set; }
        public DateTime? DateofDischarge { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]
        public double EstimatedAmount { get; set; }
        public double FinalHospitalBill { get; set; }
        public bool IsPreHospitalizationExpenses { get; set; }
        public bool? Declaration { get; set; }

    }
}
