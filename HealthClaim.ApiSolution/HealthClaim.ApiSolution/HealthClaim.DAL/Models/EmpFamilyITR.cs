using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class EmpFamilyITR : BaseModel
    {
        [Required]
        public long FamilyId { get; set; }
        [ForeignKey("FamilyId")]
        public virtual EmpFamily EmpFamily { get; set; }
        [Required]
        public string DocType { get; set; } = string.Empty;
        public string FinancialYear { get; set; }
        [Required]
        public long CountingYear { get; set; }
        public double AnnualIncome { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string Path { get; set; }
    }
}
