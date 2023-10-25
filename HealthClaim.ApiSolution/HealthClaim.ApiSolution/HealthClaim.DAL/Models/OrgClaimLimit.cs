using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class OrgClaimLimit:BaseModel
    {
        [Required]
        public string Lavel { get; set; }
        public int Limit { get; set; }
        public DateTime ApplicableDate { get; set; }
        public int ApplicableYear { get; set; }
    }
}
