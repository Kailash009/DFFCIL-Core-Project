using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class EmpFamilyPAN : BaseModel
    {
        
        public long FamilyId { get; set; }
        [ForeignKey("FamilyId")]
        public EmpFamily EmpFamily { get; set; }
        [Required]
        public string PanNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
    }
}
