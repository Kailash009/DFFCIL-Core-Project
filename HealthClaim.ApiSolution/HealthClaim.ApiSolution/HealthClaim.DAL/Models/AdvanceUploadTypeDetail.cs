using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class AdvanceUploadTypeDetail : BaseModel
    {
        
        public long AdvanceId { get; set; }
        [ForeignKey("AdvanceId")]
        public virtual EmpAdvance EmpAdvance { get; set; }
        public long UploadTypeId { get; set; }
        [ForeignKey("UploadTypeId")]
        public virtual UplodDocType UplodDocType { get; set; }
        public double Amount { get; set; }


        

    }
}
