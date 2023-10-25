using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class AdvanceUploadClarificationforType : BaseModel
    {
        public long AdvanceUploadTypeId { get; set; }
        [ForeignKey("AdvanceUploadTypeId")]
        public virtual UploadTypeDetail AdvanceUploadTypeDetail { get; set; }

        public string Clarification { get; set; }
        public long SenderId { get; set; }
        [ForeignKey("SenderId")]
        public virtual Employee EmployeeSender { get; set; }
        
        public long RecipientId { get; set; }
        [ForeignKey("RecipientId")]
        public virtual Employee EmployeeRecipient { get; set; }

    }
}
