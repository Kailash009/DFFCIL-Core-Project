using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.Model.Dtos.Employeefamily
{
    public class UpdateEmployeefamilyModel
    {
        
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public long RelationId { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string BloodGroup { get; set; }
        public bool IsActive { get; set; }
    }
}
