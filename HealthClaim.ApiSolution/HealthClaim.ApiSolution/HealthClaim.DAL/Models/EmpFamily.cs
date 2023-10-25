using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class EmpFamily : BaseModel
    {
        
        [Required]
        public long EmpId { get; set; }
        [ForeignKey("EmpId")]
        public virtual Employee Employee { get; set; } 
        [Required]
        public string Name { get;set; } = string.Empty;
        [Required]
        public long RelationId { get;set; }
        [ForeignKey("RelationId")]
        public EmpRelation EmpRelation { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get;set; }
        public string BloodGroup { get;set; }

    }
}
