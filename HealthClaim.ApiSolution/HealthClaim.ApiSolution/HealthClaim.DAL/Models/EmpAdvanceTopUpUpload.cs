using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class EmpAdvanceTopUpUpload:BaseModel
    {
        [Required]
        public long EmpAdvanceTopUpId { get; set; }
        [ForeignKey("EmpAdvanceTopUpId")]
        public virtual EmpAdvanceTopUp EmpAdvanceTopUp { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Comment { get; set; }
    }
}
