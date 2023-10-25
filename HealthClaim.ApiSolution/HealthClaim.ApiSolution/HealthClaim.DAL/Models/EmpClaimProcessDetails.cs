using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class EmpClaimProcessDetails
    {
        [Key]
        public long Id { get; set; }
        public long ClaimId { get; set; }
        [ForeignKey("ClaimId")]
        public virtual EmpClaim EmpClaim { get; set; }
        public long SenderId { get; set; }
        [ForeignKey("SenderId")]
        public virtual Employee EmployeeSender { get; set; }

        public long RecipientId { get; set; }
        [ForeignKey("RecipientId")]
        public virtual Employee EmployeeRecipient { get; set; }
        
        public long ClaimTypeId { get; set; }
        [ForeignKey("ClaimTypeId")]
        public virtual ClaimType ClaimType { get; set; }

        public long CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public virtual Employee EmployeeCreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
