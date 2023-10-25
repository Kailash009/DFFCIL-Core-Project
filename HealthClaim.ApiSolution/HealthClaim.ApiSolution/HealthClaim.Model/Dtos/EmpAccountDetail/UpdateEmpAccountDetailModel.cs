using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.Model.Dtos.EmpAccountDetail
{
    public class UpdateEmpAccountDetailModel
    {
        public string BankName { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public string IfscCode { get; set; }
        [Required]
        public bool IsDefault { get; set; }
    }
}
