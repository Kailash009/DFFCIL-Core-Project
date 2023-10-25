using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class BaseModel
    {
        [Key]
        public long Id { get; set; }
        public long CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public virtual Employee EmployeeCreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        [ForeignKey("UpdatedBy")]
        public virtual Employee? EmployeeUpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
