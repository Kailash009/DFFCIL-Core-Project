using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.Model.Dtos.OrgClaimLimit
{
    public class OrgClaimLimitModal
    {
        public string Lavel { get; set; }
        public int Limit { get; set; }
        //public DateTime ApplicableDate { get; set; }
        public int ApplicableYear { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
