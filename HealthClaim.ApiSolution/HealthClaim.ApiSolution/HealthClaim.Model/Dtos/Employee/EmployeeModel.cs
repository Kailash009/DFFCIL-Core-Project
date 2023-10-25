using HealthClaim.Model.Dtos.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.Model.Dtos.Employee
{
    public class EmployeeModel
    {
        
        [Required]
        public string EmpId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DateofBirth { get; set; }

        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public string Designation { get; set; }
        public string BloodGroup { get; set; }
        public string? JoiningDate { get; set; }
        public string? LeavingDate { get; set; }
        public bool IsActive { get; set; }
        public IFormFile? ProfilePhotoPath { get; set; }
        public long? CreatedBy { get; set; }
        public string Location { get; set; }
        public string EmpLavel { get; set; }
        public long? ReportingOfficerId { get; set; }
        public string Department { get; set; }
        public bool? IsPrimary { get; set; }
        public string OrgPrimaryName { get; set; }
        public string OrgUnitName { get; set; }
        public string PostAssignedInOrgUnit { get; set; }
        public DateTime? ApplicabelDate { get; set; }
        public string PostAssignedInWrapperName { get; set; }
        public string MarkingAbbr { get; set; }
        public string PostNameEn { get; set; }
        public string WrapperName { get; set; }
    }
}
