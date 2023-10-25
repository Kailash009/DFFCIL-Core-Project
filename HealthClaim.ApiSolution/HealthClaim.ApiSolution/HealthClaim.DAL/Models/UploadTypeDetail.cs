using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class UploadTypeDetail : BaseModel
    {
        [Required]
        public long ClaimId { get; set; }
        public long ClaimTypeId { get; set; }// make candidate key (ClaimId,ClaimTypeId)
        public long UploadTypeId { get; set; }
        [ForeignKey("UploadTypeId")]
        public virtual UplodDocType UplodDocType { get; set; }
        public double Amount { get; set; }


        

    }
}
