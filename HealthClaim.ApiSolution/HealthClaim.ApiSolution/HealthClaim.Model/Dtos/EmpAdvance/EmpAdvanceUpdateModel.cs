using HealthClaim.Utility.Eumus;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.Model.Dtos.EmpAdvance
{
    public class EmpAdvanceUpdateModel
    {
        //public long EmplId { get; set; }
        ////public long PatientId { get; set; }
        //public long RequestSubmittedById { get; set; }
        ////public string RequestName { get; set; }
        //public DateTime AdvanceRequestDate { get; set; }
        //public double AdvanceAmount { get; set; }
        //public string Reason { get; set; }
        //public string PayTo { get; set; }
        public DateTime ApprovalDate { get; set; }
        public double ApprovedAmount { get; set; }

        public long? ApprovedById { get; set; }

        //[Required]
        //public string HospitalName { get; set; }
        //[Required]
        //public string HospitalRegNo { get; set; }
        //[Required]
        //public DateTime DateOfAdmission { get; set; }
        //[Required]
        //public string DoctorName { get; set; }
        //public List<IFormFile> AdmissionAdviceFile { get; set; }
        //public List<IFormFile> EstimateAmountFile { get; set; }
        //public List<IFormFile> DiagnosisFile { get; set; }

        //public string? BankName { get; set; }
        //public string? BeneficiaryAccountNo { get; set; }
        //// public string BeneficiaryName { get; set; }
        //public string? IFSCCode { get; set; }
        //public string? BeneficiaryName { get; set; }
        ////public long AdvanceUploadTypeId { get; set; }
        //public RecordMasterClaimTypes ClaimTypeId { get; set; }
        //public RecordMasterClaimStatusCategory StatusId { get; set; }
        //public RecordMasterUplodDocType UploadTypeId { get; set; }

    }
}
