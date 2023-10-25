using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class EmpProfile 
    {
        [Key]
        public long Id { get; set; }
        
        [Required]
        public long EmpId { get; set; }
        [ForeignKey("EmpId")]
        public virtual Employee Employee { get; set; }
        public string? OrgPrimaryName { get; set; }
        public string? OrgUnitName { get; set; }
        public string? WrapperName { get; set; }
        public string? PostAssignedInWrapperName { get; set; }
        public string? PostAssignedInOrgUnit { get; set; }
        public string? PostNameEn { get; set; }
        public string? MarkingAbbr { get; set; }
        public string? Location { get; set; }
        public string? EmpLavel { get; set; }
        public string? Designation { get; set; }
        public string? Department { get; set; }
        public bool? IsPrimary { get; set; }
        public DateTime? ApplicabelDate { get; set; }
        public long? ReportingOfficerId { get; set; }
        [ForeignKey("ReportingOfficerId")]
        public virtual Employee? EmployeeReportingOfficer { get; set; }
        public long? CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public virtual Employee? EmployeeCreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public long? UpdatedBy { get; set; }
        [ForeignKey("UpdatedBy")]
        public virtual Employee? EmployeeUpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
