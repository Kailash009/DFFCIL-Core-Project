using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.Model.Dtos.Common
{
    public class AdvanceUploadTypeDetails
    {
        public long AdvanceId { get; set; }
        public long UploadTypeId { get; set; }
        public double Amount { get; set; }
    }
}
