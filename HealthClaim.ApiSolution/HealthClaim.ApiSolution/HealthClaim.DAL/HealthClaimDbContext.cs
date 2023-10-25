using HealthClaim.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace HealthClaim.DAL
{
    public class HealthClaimDbContext : IdentityDbContext<ApplicationUser>
    {
        public HealthClaimDbContext(DbContextOptions<HealthClaimDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<ClaimStatusCategory> ClaimStatusCategory { get; set; }
        public DbSet<UploadDocument> UploadDocuments { get; set; }
        public DbSet<UploadTypeDetail> UploadTypeDetails { get; set; }
        public DbSet<EmpAccountDetail> EmpAccountDetails { get; set; }
        public DbSet<EmpAdvance> EmpAdvances { get; set; }
        public DbSet<EmpClaimStatus> EmpClaimStatus { get; set; }
        public DbSet<EmpFamily> EmpFamilys { get; set; }
        public DbSet<EmpFamilyITR> EmpFamilyITRs { get; set; }
        public DbSet<EmpFamilyPAN> EmpFamilyPANs { get; set; }
        public DbSet<EmpRelation> EmpRelations { get; set; }
        public DbSet<HospitalAccountDetail> HospitalAccountDetails { get; set; }

        //New
        public DbSet<EmpClaim> EmployeeClaims { get; set; }
        public DbSet<EmpClaimBill> EmployeeClaimBills { get; set; }
        public DbSet<ClaimType> ClaimTypes { get; set; }
        public DbSet<DoctorReview> DoctorReviews { get; set; }
        public DbSet<AdvanceUploadClarificationforType> AdvanceUploadClarificationforTypes { get; set; }

        public DbSet<UplodDocType> UplodDocType { get; set; }
        public DbSet<EmpProfile> EmpProfiles { get; set; }
        public DbSet<OrgClaimLimit> OrgClaimLimits { get; set; }
        public DbSet<EmpClaimNotInMailBill> EmpClaimNotInMailBills { get; set; }
        public DbSet<EmpClaimProcessDetails> EmpClaimProcessDetails { get; set; }
        public DbSet<EmpAdvanceTopUp> EmpAdvanceTopUp { get; set; }
        public DbSet<EmpAdvanceTopUpUpload> EmpAdvanceTopUpUpload { get; set; }
        public DbSet<ClaimClarification> ClaimClarification { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmpAdvance>().HasOne(e => e.Employee).WithMany()
                .HasForeignKey(e => e.EmplId)
                .OnDelete(DeleteBehavior.ClientSetNull); // Set the desired behavior

            modelBuilder.Entity<Employee>().HasOne(e => e.EmployeeCreatedBy).WithMany()
               .HasForeignKey(e => e.CreatedBy)
               .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Employee>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull); // Set the desired behavior


            modelBuilder.Entity<EmpAccountDetail>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpAccountDetail>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<HospitalAccountDetail>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpAdvance>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<EmpFamily>().HasOne(e => e.EmpRelation).WithMany()
                .HasForeignKey(e => e.RelationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpFamily>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpFamily>().HasOne(e => e.Employee).WithMany()
                .HasForeignKey(e => e.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpAdvance>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpAdvance>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpAdvance>().HasOne(e => e.EmpClaim).WithMany()
                .HasForeignKey(e => e.ClaimId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpAdvance>().HasOne(e => e.Employee).WithMany()
                .HasForeignKey(e => e.EmplId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpAdvance>().HasOne(e => e.EmployeeApproveBy).WithMany()
                .HasForeignKey(e => e.ApprovedById)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpAdvance>().HasOne(e => e.EmployeeRequestSubmited).WithMany()
                .HasForeignKey(e => e.RequestSubmittedById)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpFamilyITR>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpFamilyITR>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpFamilyPAN>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpFamilyPAN>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<HospitalAccountDetail>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<UploadTypeDetail>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<UploadTypeDetail>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<UploadTypeDetail>().HasOne(e => e.UplodDocType).WithMany()
                .HasForeignKey(e => e.UploadTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpClaimStatus>().HasOne(e => e.EmpClaim).WithMany()
                .HasForeignKey(e => e.ClaimId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpClaimStatus>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpClaimStatus>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpClaimStatus>().HasOne(e => e.ClaimType).WithMany()
                .HasForeignKey(e => e.ClaimTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<UploadDocument>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            //.......................

            //New Table

            modelBuilder.Entity<AdvanceUploadClarificationforType>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                    .HasForeignKey(e => e.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<AdvanceUploadClarificationforType>().HasOne(e => e.EmployeeRecipient).WithMany()
                    .HasForeignKey(e => e.RecipientId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<AdvanceUploadClarificationforType>().HasOne(e => e.EmployeeSender).WithMany()
                    .HasForeignKey(e => e.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<DoctorReview>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                    .HasForeignKey(e => e.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpClaim>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                    .HasForeignKey(e => e.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpClaimBill>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);



            modelBuilder.Entity<DoctorReview>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<EmpClaimBill>().HasOne(e => e.EmpClaim).WithMany()
                .HasForeignKey(e => e.EmpClaimId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpClaimBill>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpClaimBill>().HasOne(e => e.Employee).WithMany()
                .HasForeignKey(e => e.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpProfile>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);



            modelBuilder.Entity<EmpProfile>().HasOne(e => e.Employee).WithMany()
                .HasForeignKey(e => e.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpProfile>().HasOne(e => e.EmployeeReportingOfficer).WithMany()
                .HasForeignKey(e => e.ReportingOfficerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<OrgClaimLimit>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpClaimNotInMailBill>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<OrgClaimLimit>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpClaimProcessDetails>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpClaimProcessDetails>().HasOne(e => e.EmployeeSender).WithMany()
                .HasForeignKey(e => e.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpClaimProcessDetails>().HasOne(e => e.EmployeeRecipient).WithMany()
                .HasForeignKey(e => e.RecipientId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpAdvanceTopUp>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpAdvanceTopUp>().HasOne(e => e.EmployeeApprovedBy).WithMany()
                .HasForeignKey(e => e.ApprovedById)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpAdvanceTopUpUpload>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<ClaimClarification>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<ClaimClarification>().HasOne(e => e.EmployeeRecipient).WithMany()
                .HasForeignKey(e => e.RecipientId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            modelBuilder.Entity<ClaimClarification>().HasOne(e => e.EmployeeSender).WithMany()
                .HasForeignKey(e => e.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // Seeding (Table Master Data)
            SeedData_ClaimType(modelBuilder);
            SeedData_EmployeeRelation(modelBuilder);
            SeedData_UploadDocTypeType(modelBuilder);
            SeedData_ClaimStatusCategory(modelBuilder);

        }
        public void SeedData_ClaimType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClaimType>().HasData(
                 new ClaimType { Id = 1, Name = "Advance", Description = "Advance", IsActive = true, CreatedDate = DateTime.Now },
                 new ClaimType { Id = 2, Name = "Advance Claim", Description = "AdvanceClaim", IsActive = true, CreatedDate = DateTime.Now },
                 new ClaimType { Id = 3, Name = "Direct Claim", Description = "DirectClaim", IsActive = true, CreatedDate = DateTime.Now },
                 new ClaimType { Id = 4, Name = "Top Up Amount", Description = "Top Up Amount", IsActive = true, CreatedDate = DateTime.Now }
            );
        }
        public void SeedData_UploadDocTypeType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UplodDocType>().HasData(
                 new UplodDocType { Id = 1, IsBillable = true, Name = "Medicine", Description = "Medicine", IsActive = true, CreatedDate = DateTime.Now },
                 new UplodDocType { Id = 2, IsBillable = true, Name = "Medicine not in Final bill", Description = "Medicine not in Final bill", IsActive = true, CreatedDate = DateTime.Now },
                 new UplodDocType { Id = 3, IsBillable = true, Name = "Consultation", Description = "Consultation", IsActive = true, CreatedDate = DateTime.Now },
                 new UplodDocType { Id = 4, IsBillable = true, Name = "Room Rent", Description = "Room Rent", IsActive = true, CreatedDate = DateTime.Now },
                 new UplodDocType { Id = 5, IsBillable = true, Name = "Investigation", Description = "Investigation", IsActive = true, CreatedDate = DateTime.Now },
                 new UplodDocType { Id = 6, IsBillable = true, Name = "Other", Description = "Other", IsActive = true, CreatedDate = DateTime.Now },
                 new UplodDocType { Id = 7, IsBillable = true, Name = "ConsultationNotFinalBill", Description = "ConsultationNotFinalBill", IsActive = true, CreatedDate = DateTime.Now },
                 new UplodDocType { Id = 8, IsBillable = true, Name = "InvestigationNotFinalBill", Description = "InvestigationNotFinalBill", IsActive = true, CreatedDate = DateTime.Now },
                 new UplodDocType { Id = 9, IsBillable = true, Name = "OtherBillNotFinalBill", Description = "OtherBillNotFinalBill", IsActive = true, CreatedDate = DateTime.Now },
                 new UplodDocType { Id = 10, IsBillable = true, Name = "AdmissionAdviceUpload", Description = "AdmissionAdviceUpload", IsActive = true, CreatedDate = DateTime.Now },
                 new UplodDocType { Id = 11, IsBillable = true, Name = "DischargeSummary", Description = "DischargeSummary", IsActive = true, CreatedDate = DateTime.Now },
                 new UplodDocType { Id = 12, IsBillable = true, Name = "InvestigationReports", Description = "InvestigationReports", IsActive = true, CreatedDate = DateTime.Now },
                 new UplodDocType { Id = 13, IsBillable = true, Name = "FinalHospitalBill", Description = "FinalHospitalBill", IsActive = true, CreatedDate = DateTime.Now },
                 new UplodDocType { Id = 14, IsBillable = true, Name = "Diagnosis", Description = "Diagnosis", IsActive = true, CreatedDate = DateTime.Now },
                 new UplodDocType { Id = 15, IsBillable = true, Name = "PreHospitalizationExpensesMedicine", Description = "PreHospitalizationExpensesMedicine", IsActive = true, CreatedDate = DateTime.Now },
                 new UplodDocType { Id = 16, IsBillable = true, Name = "PreHospitalizationExpensesConsultation", Description = "PreHospitalizationExpensesConsultation", IsActive = true, CreatedDate = DateTime.Now },
                 new UplodDocType { Id = 17, IsBillable = true, Name = "PreHospitalizationExpensesInvestigation", Description = "PreHospitalizationExpensesInvestigation", IsActive = true, CreatedDate = DateTime.Now },
                 new UplodDocType { Id = 18, IsBillable = true, Name = "PreHospitalizationExpensesOther", Description = "PreHospitalizationExpensesOther", IsActive = true, CreatedDate = DateTime.Now },
                 new UplodDocType { Id = 19, IsBillable = true, Name = "EstimateAmount", Description = "EstimateAmount", IsActive = true, CreatedDate = DateTime.Now },
                 new UplodDocType { Id = 20, IsBillable = true, Name = "ReviseEstimateFile", Description = "ReviseEstimateFile", IsActive = true, CreatedDate = DateTime.Now },
                 new UplodDocType { Id = 21, IsBillable = true, Name = "HospitalRegstrationDetailsFile", Description = "HospitalRegstrationDetailsFile", IsActive = true, CreatedDate = DateTime.Now },
                 new UplodDocType { Id = 22, IsBillable = true, Name = "HospitalIncomeTaxFile", Description = "HospitalIncomeTaxFile", IsActive = true, CreatedDate = DateTime.Now }
            );

        }

        public void SeedData_EmployeeRelation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpRelation>().HasData(
         new EmpRelation { Id = 1, Name = "Father", Description = "Father", IsActive = true, CreatedDate = DateTime.Now },
         new EmpRelation { Id = 2, Name = "Mother", Description = "Mother", IsActive = true, CreatedDate = DateTime.Now },
         new EmpRelation { Id = 3, Name = "Son", Description = "Son", IsActive = true, CreatedDate = DateTime.Now },
         new EmpRelation { Id = 4, Name = "Daughter", Description = "Daughter", IsActive = true, CreatedDate = DateTime.Now },
         //new EmpRelation { Id = 5, Name = "Husband", Description = "Husband", IsActive = true, CreatedDate = DateTime.Now },
         new EmpRelation { Id = 6, Name = "Spouse", Description = "Spouse", IsActive = true, CreatedDate = DateTime.Now },
         new EmpRelation { Id = 7, Name = "Self", Description = "Self", IsActive = true, CreatedDate = DateTime.Now }

         );
        }
        public void SeedData_ClaimStatusCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClaimStatusCategory>().HasData(

                // Advance
         new ClaimStatusCategory { Id = 1, Name = "Claim Initiated", ClaimTypeId = 1, Description = "Claim Initiated", IsActive = true, CreatedDate = DateTime.Now },
         new ClaimStatusCategory { Id = 2, Name = "Approved", ClaimTypeId = 1, Description = "Approved", IsActive = true, CreatedDate = DateTime.Now },
         new ClaimStatusCategory { Id = 3, Name = "HR Processing", ClaimTypeId = 1, Description = "HR Processing", IsActive = true, CreatedDate = DateTime.Now },
         new ClaimStatusCategory { Id = 4, Name = "Finance processing", ClaimTypeId = 1, Description = "Finance processing", IsActive = true, CreatedDate = DateTime.Now },
         new ClaimStatusCategory { Id = 5, Name = "Under Doctor Processing", ClaimTypeId = 1, Description = "Under Doctor Processing", IsActive = true, CreatedDate = DateTime.Now },
         new ClaimStatusCategory { Id = 6, Name = "Rejected", ClaimTypeId = 1, Description = "Rejected", IsActive = true, CreatedDate = DateTime.Now },

         // Advance Claim
         new ClaimStatusCategory { Id = 7, Name = "Claim Initiated", ClaimTypeId = 2, Description = "Claim Initiated", IsActive = true, CreatedDate = DateTime.Now },
         new ClaimStatusCategory { Id = 8, Name = "Approved", ClaimTypeId = 2, Description = "Approved", IsActive = true, CreatedDate = DateTime.Now },
         new ClaimStatusCategory { Id = 9, Name = "HR Processing", ClaimTypeId = 2, Description = "HR Processing", IsActive = true, CreatedDate = DateTime.Now },
         new ClaimStatusCategory { Id = 10, Name = "Finance processing", ClaimTypeId = 2, Description = "Finance processing", IsActive = true, CreatedDate = DateTime.Now },
         new ClaimStatusCategory { Id = 12, Name = "Under Doctor Processing", ClaimTypeId = 2, Description = "Under Doctor Processing", IsActive = true, CreatedDate = DateTime.Now },
         new ClaimStatusCategory { Id = 13, Name = "Rejected", ClaimTypeId = 2, Description = "Rejected", IsActive = true, CreatedDate = DateTime.Now },

         // Direct Claim
         new ClaimStatusCategory { Id = 14, Name = "Claim Initiated", ClaimTypeId = 3, Description = "Claim Initiated", IsActive = true, CreatedDate = DateTime.Now },
         new ClaimStatusCategory { Id = 15, Name = "Approved", ClaimTypeId = 3, Description = "Approved", IsActive = true, CreatedDate = DateTime.Now },
         new ClaimStatusCategory { Id = 16, Name = "HR Processing", ClaimTypeId = 3, Description = "HR Processing", IsActive = true, CreatedDate = DateTime.Now },
         new ClaimStatusCategory { Id = 17, Name = "Finance processing", ClaimTypeId = 3, Description = "Finance processing", IsActive = true, CreatedDate = DateTime.Now },
         new ClaimStatusCategory { Id = 18, Name = "Under Doctor Processing", ClaimTypeId = 3, Description = "Under Doctor Processing", IsActive = true, CreatedDate = DateTime.Now },
         new ClaimStatusCategory { Id = 19, Name = "Rejected", ClaimTypeId = 3, Description = "Rejected", IsActive = true, CreatedDate = DateTime.Now },
         new ClaimStatusCategory { Id = 20, Name = "Top Up Initiated", ClaimTypeId = 2, Description = "Top Up Initiated", IsActive = true, CreatedDate = DateTime.Now }

         );
        }
    }
}