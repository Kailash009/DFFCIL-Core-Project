using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClaim.DAL.Models
{
    public class EmpClaimBill:BaseModel
    {
        public long EmpClaimId { get; set; }
        [ForeignKey("EmpClaimId")]
        public virtual EmpClaim EmpClaim { get; set; }
        public long EmpId { get; set; }
        [ForeignKey("EmpId")]
        public virtual Employee Employee { get; set; }
        public long StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual ClaimStatusCategory ClaimStatusCategory { get; set; }
        public double HospitalCompleteBill { get; set; }
        public double MedicineBill { get; set; }
        public double ConsultationBill { get; set; }
        public double InvestigationBill { get; set; }
        public double RoomRentBill { get; set; }
        public double OthersBill { get; set; }
    }
}
