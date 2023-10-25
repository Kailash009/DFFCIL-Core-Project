using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace HealthClaim.Model.Dtos.Claims
{
    public class AdvanceClaimDetailsModel
    {
        [Required]
        public int AdvanceId { get; set; }
        [Required]
        public long EmpId { get; set; }
        [Required]
        public bool IsSpecailDisease { get; set; }
        [Required]
        public bool IsTaxable { get; set; }
        [Required]
        public bool Declaration { get; set; }

        [Required]
        public List<IFormFile> DischargeSummaryUpload { get; set; }
        [Required]
        public List<IFormFile> InvestigationReportsUpload { get; set; }
        [Required]
        public double FinalHospitalBill { get; set; }
        [Required]
        public double ClaimAmount { get; set; }
        [Required]
        public List<IFormFile> FinalHospitalBillUpload { get; set; }
        [Required]
        public MedicenBill MedicenBill { get; set; }
        public MedicenNotFinalBill? MedicenNotFinalBill { get; set; }
        [Required]
        public Consultation Consultation { get; set; }
        public ConsultationNotFinalBill? ConsultationNotFinalBill { get; set; }
        [Required]
        public Investigation Investigation { get; set; }
        public InvestigationNotFinalBill? InvestigationNotFinalBill { get; set; }
        [Required]
        public RoomRent RoomRent { get; set; }
        public OtherBill OtherBill { get; set; }
        public OtherBillNotFinalBill? OtherBillNotFinalBill { get; set; }
        [Required]
        public DateTime DateofDischarge { get; set; }
        [Required]
        public bool IsPreHospitalizationExpenses { get; set; }
        public PreHospitalizationExpensesMedicine? PreHospitalizationExpensesMedicine { get; set; }
        public PreHospitalizationExpensesConsultation? PreHospitalizationExpensesConsultation { get; set; }
        public PreHospitalizationExpensesInvestigation? PreHospitalizationExpensesInvestigation { get; set; }
        public PreHospitalizationExpensesOther? PreHospitalizationExpensesOther { get; set; }
        public HospitalIncomeTaxFile? HospitalIncomeTaxFile { get; set; }
        public HospitalRegstrationDetailsFile? HospitalRegstrationDetailsFile { get; set; }
    }
}
public class MedicenBill
{
    public int Amount { get; set; }
    // public List<IFormFile> Files { get; set; }

}
public class MedicenNotFinalBill
{
    public int Amount { get; set; }
    public List<IFormFile> Files { get; set; }

}
public class Consultation
{
    public int Amount { get; set; }
    //  public List<IFormFile> Files { get; set; }

}
public class ConsultationNotFinalBill
{
    public int Amount { get; set; }
    public List<IFormFile> Files { get; set; }

}
public class Investigation
{
    public int Amount { get; set; }
    // public List<IFormFile> Files { get; set; }

}
public class InvestigationNotFinalBill
{
    public int Amount { get; set; }
    public List<IFormFile> Files { get; set; }

}
public class RoomRent
{
    public int Amount { get; set; }
    //   public List<IFormFile> Files { get; set; }

}


public class OtherBill
{
    public int Amount { get; set; }
    // public List<IFormFile> Files { get; set; }

}
public class OtherBillNotFinalBill
{
    public int Amount { get; set; }
    public List<IFormFile> Files { get; set; }

}
public class PreHospitalizationExpensesMedicine
{
    public int Amount { get; set; }
    public List<IFormFile> Files { get; set; }

}
public class PreHospitalizationExpensesConsultation
{
    public int Amount { get; set; }
    public List<IFormFile> Files { get; set; }

}
public class PreHospitalizationExpensesInvestigation
{
    public int Amount { get; set; }
    public List<IFormFile> Files { get; set; }

}
public class PreHospitalizationExpensesOther
{
    public int Amount { get; set; }
    public List<IFormFile> Files { get; set; }

}


