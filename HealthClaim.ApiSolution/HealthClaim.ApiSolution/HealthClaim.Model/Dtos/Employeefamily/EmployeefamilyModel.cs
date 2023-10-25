using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using HealthClaim.Utility.Eumus;

namespace HealthClaim.Model.Dtos.Employeefamily
{
    public class EmployeefamilyModel
    {
        [Required]
        public long EmpId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public RecordMasterEmpRelations RelationId { get; set; }
         
        public string Gender { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string MobileNo { get; set; }
        public string BloodGroup { get; set; }
        public bool IsActive { get; set; }

        public IFormFile? ITRFile { get; set; }
        public string? FinancialYear { get; set; }
        public double? AnnualIncome { get; set; }
        //public IFormFile? PANFile { get; set; }
        public string? PANNo { get; set; }
        
    }
}
