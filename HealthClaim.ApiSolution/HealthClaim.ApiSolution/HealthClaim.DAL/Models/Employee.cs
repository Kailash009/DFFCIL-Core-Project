using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    //[Index(nameof(EmpId), IsUnique = true)]
    public class Employee 
    {
        [Key]
        public long Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        [Required]
        public string DateofBirth { get; set; }
        
        public string? JoiningDate { get; set; }
        
        public string? LeavingDate { get; set; }


        [Required]
        public string EmpId { get; set; }
        public string EmailId { get; set; }
        [Required]
        public string Mobile { get; set; }
        public string Designation { get; set; }
        public string BloodGroup { get; set; }
        public string? PhotoFileName { get; set; }
        public string? PhotoPath { get; set; }

        public long? CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public virtual Employee? EmployeeCreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        [ForeignKey("UpdatedBy")]
        public virtual Employee? EmployeeUpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public string Gender { get; set; }
    }
}
