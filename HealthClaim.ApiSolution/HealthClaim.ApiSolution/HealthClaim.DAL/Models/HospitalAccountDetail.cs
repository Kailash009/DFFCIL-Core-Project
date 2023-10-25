using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class HospitalAccountDetail : BaseModel
    {
        public long EmpAdvanceId { get; set; }
        [ForeignKey("EmpAdvanceId")]
        public virtual EmpAdvance EmpAdvance { get; set; }
        [Required]
        public string BankName { get; set; } = string.Empty;
        [Required]
        public string AccountNumber { get; set; } = string.Empty;
        [Required]
        public string IfscCode { get; set; } = string.Empty;
        [Required]
        public string BeneficiaryName { get; set; }
    }
}
