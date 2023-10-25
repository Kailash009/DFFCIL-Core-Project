using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class AdvanceUploadDocument : BaseModel
    {
        [ForeignKey("AdvanceUploadTypeId")]
        public long AdvanceUploadTypeId { get; set; }
        public virtual AdvanceUploadTypeDetail AdvanceUploadTypeDetail { get; set; }
        public double Amount { get; set; }
        public string FileName { get; set; }
        public string PathUrl { get; set; }
        public string Comment { get; set; }

    }
}
