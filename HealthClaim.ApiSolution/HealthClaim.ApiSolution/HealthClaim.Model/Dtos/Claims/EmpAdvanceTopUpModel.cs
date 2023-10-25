using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HealthClaim.Model.Dtos.Claims
{
    public class EmpAdvanceTopUpModel
    {

        [Required]
        public long AdvanceId { get; set; }
        [Required]
        public long EmpId { get; set; }
        [Required]
        public double ReviseEstimentedAmount { get; set; }
        [Required]
        public double TopRequiredAmount { get; set; }
        public string PayTo { get; set; }
        public string? BankName { get; set; } = string.Empty;
        public string? AccountNumber { get; set; } = string.Empty;
        public string? IfscCode { get; set; } = string.Empty;
        public string? BeneficiaryName { get; set; }
        [Required]
        public ReviseEstimate ReviseEstimateFile { get; set; }

    }
    public class ReviseEstimate
    {
        [Required]
        public List<IFormFile> Files { get; set; }
        public string? FileComment { get; set; }
    }
}
