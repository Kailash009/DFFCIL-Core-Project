
using System.ComponentModel.DataAnnotations;


namespace HealthClaim.Model.Dtos.Common
{
    public class HospitalAccountDetailDto
    {
        [Required]
        public string BankName { get; set; } = string.Empty;
        [Required]
        public string AccountNumber { get; set; } = string.Empty;
        [Required]
        public string IfscCode { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
