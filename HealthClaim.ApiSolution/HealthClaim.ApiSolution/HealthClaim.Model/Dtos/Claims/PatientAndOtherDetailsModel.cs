using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HealthClaim.Model.Dtos.Claims
{
    public class PatientAndOtherDetailsModel
    {
        public bool? IsSpecailDisease { get; set; }
        public double? ClaimAmount { get; set; }
        public List<IFormFile> AdmissionAdviceUpload { get; set; }
        public List<IFormFile> DischargeSummaryUpload { get; set; }
        public List<IFormFile> InvestigationReportsUpload { get; set; }
        public List<IFormFile> DiagnosisUpload { get; set; }
        public long EmpId { get; set; }
        public double FinalHospitalBill { get; set; }
        public List<IFormFile> FinalHospitalBillUpload { get; set; }
        public MedicenBill MedicenBill { get; set; }
        public MedicenNotFinalBill? MedicenNotFinalBill { get; set; }
        public Consultation Consultation { get; set; }
        public ConsultationNotFinalBill? ConsultationNotFinalBill { get; set; }
        public Investigation Investigation { get; set; }
        public InvestigationNotFinalBill? InvestigationNotFinalBill { get; set; }
        public RoomRent RoomRent { get; set; }
        public OtherBill OtherBill { get; set; }
        public OtherBillNotFinalBill? OtherBillNotFinalBill { get; set; }
        public long PatientId { get; set; }
        public string RequestName { get; set; }
        public string Reason { get; set; }
        public string PayTo { get; set; }
        [Required]
        public string HospitalName { get; set; }
        [Required]
        public string HospitalRegNo { get; set; }
        [Required]
        public DateTime DateOfAdmission { get; set; }
        [Required]
        public DateTime DateofDischarge { get; set; }
        public string? DoctorName { get; set; }
        
        public bool IsPreHospitalizationExpenses { get; set; }
        public PreHospitalizationExpensesMedicine? PreHospitalizationExpensesMedicine { get; set; }
        public PreHospitalizationExpensesConsultation? PreHospitalizationExpensesConsultation { get; set; }
        public PreHospitalizationExpensesInvestigation? PreHospitalizationExpensesInvestigation { get; set; }
        public PreHospitalizationExpensesOther? PreHospitalizationExpensesOther { get; set; }
    }

    public class MedicenBill
    {
        [Required]
        public int Amount { get; set; }
        // public List<IFormFile> Files { get; set; }

    }
    public class MedicenNotFinalBill
    {

        public int? Amount { get; set; }
        public List<IFormFile>? Files { get; set; }

    }
    public class Consultation
    {
        [Required]
        public int Amount { get; set; }
        //  public List<IFormFile> Files { get; set; }

    }
    public class ConsultationNotFinalBill
    {
        public int? Amount { get; set; }
        public List<IFormFile>? Files { get; set; }

    }
    public class Investigation
    {
        [Required]
        public int Amount { get; set; }
        // public List<IFormFile> Files { get; set; }

    }
    public class InvestigationNotFinalBill
    {

        public int? Amount { get; set; }
        public List<IFormFile>? Files { get; set; }

    }
    public class RoomRent
    {
        [Required]
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
        public int? Amount { get; set; }
        public List<IFormFile>? Files { get; set; }

    }
    public class PreHospitalizationExpensesMedicine
    {
        public int? Amount { get; set; }
        public List<IFormFile>? Files { get; set; }

    }
    public class PreHospitalizationExpensesConsultation
    {
        public int? Amount { get; set; }
        public List<IFormFile>? Files { get; set; }

    }
    public class PreHospitalizationExpensesInvestigation
    {
        public int? Amount { get; set; }
        public List<IFormFile>? Files { get; set; }

    }
    public class PreHospitalizationExpensesOther
    {
        public int? Amount { get; set; }
        public List<IFormFile>? Files { get; set; }

    }
    public class HospitalRegstrationDetailsFile
    {
        public List<IFormFile>? Files { get; set; }

    }
    public class HospitalIncomeTaxFile
    {
        public List<IFormFile>? Files { get; set; }

    }
}
