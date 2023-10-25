using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class EmpClaimNotInMailBill:BaseModel
    {
        public long EmpClaimBillId { get; set; }
        [ForeignKey("EmpClaimBillId")]
        public virtual EmpClaimBill EmpClaimBill { get; set; }
        [Required]
        public string BillType { get; set; }
        [Required]
        public double Amount { get; set; }
    }
}
