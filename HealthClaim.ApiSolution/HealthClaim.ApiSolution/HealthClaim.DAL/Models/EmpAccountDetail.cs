using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class EmpAccountDetail : BaseModel
    {
        [Required]
        public long EmpId { get; set; }
        [ForeignKey("EmpId")]
        public virtual Employee Employee { get; set; }
        [Required]
        public string BankName { get;set; }
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public string IfscCode { get;set; }
        [Required]
        public bool IsDefault { get;set; }
        
    }
}
