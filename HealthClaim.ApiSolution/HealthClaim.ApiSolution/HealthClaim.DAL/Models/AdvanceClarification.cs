using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class AdvanceClarification:BaseModel
    {
        public long EmpAdvanceId { get; set; }
        [ForeignKey("EmpAdvanceId")]
        public virtual EmpAdvance EmpAdvance { get; set; }

        public string Clarification { get; set; }
        public long SenderId { get; set; }
        [ForeignKey("SenderId")]
        public virtual Employee EmployeeSender { get; set; }

        public long RecipientId { get; set; }
        [ForeignKey("RecipientId")]
        public virtual Employee EmployeeRecipient { get; set; }

    }
}
