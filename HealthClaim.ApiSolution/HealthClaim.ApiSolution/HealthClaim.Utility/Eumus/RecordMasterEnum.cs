
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HealthClaim.Utility.Eumus
{
    public static class EnumuDescription
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }
            return "";
        }
    }

    public enum RecordMasterClaimTypes
    {
        Advance = 1,
        AdvanceClaim = 2,
        DirectClaim = 3,
        TopUpAmount = 4
    }
    public enum RecordMasterIds
    {
        DoctorId = 15,
        HR_OneID = 16,
        HR_TwoID = 17,
        FinianceId = 20
    }

    public enum RecordMasterUplodDocType
    {
        Medicine = 1,
        MedicinenotinFinalBill = 2,
        Consultation = 3,
        RoomRent = 4,
        Investigation = 5,
        Other = 6,
        ConsultationNotFinalBill = 7,
        InvestigationNotFinalBill = 8,
        OtherBillNotFinalBill = 9,
        AdmissionAdviceUpload = 10,
        DischargeSummary = 11,
        InvestigationReports = 12,
        FinalHospitalBill = 13,
        Diagnosis = 14,
        PreHospitalizationExpensesMedicine = 15,
        PreHospitalizationExpensesConsultation = 16,
        PreHospitalizationExpensesInvestigation = 17,
        PreHospitalizationExpensesOther = 18,
        EstimateAmount = 19,
        ReviseEstimateFile = 20,
        HospitalRegstrationDetailsFile = 21,
        HospitalIncomeTaxFile = 22,
    }
    public enum RecordMasterEmpRelations
    {
        [Description("Father")]
        Father = 1,
        [Description("Mother")]
        Mother = 2,
        [Description("Son")]
        Son = 3,
        [Description("Daughter")]
        Daughter = 4,
        [Description("Spouse")]
        Spouse = 6,
        //[Description("Self")] 
        //Self = 7,
    }
    public enum RecordMasterClaimStatusCategory
    {
        [Display(Name = "ClaimInitiated")]
        ClaimInitiated = 1,
        [Display(Name = "Approved")]
        Approved = 2,
        [Display(Name = "HRProcessing")]
        HRProcessing = 3,
        [Display(Name = "FinanceProcessing")]
        FinanceProcessing = 4,
        [Display(Name = "UnderDoctorProcessing")]
        UnderDoctorProcessing = 5,
        [Display(Name = "Rejected")]
        Rejected = 6,
        [Display(Name = "TopUpInitiated")]
        TopUpInitiated = 20,
    }
}
