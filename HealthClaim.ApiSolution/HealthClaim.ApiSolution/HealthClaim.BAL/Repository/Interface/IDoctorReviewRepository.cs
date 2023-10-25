using HealthClaim.Model.Dtos.DoctorReview;
using HealthClaim.Model.Dtos.EmpAccountDetail;
using HealthClaim.Model.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.BAL.Repository.Interface
{
    public interface IDoctorReviewRepository
    {
        public Task<ResponeModel> Create(DoctorReviewDetailsModel doctorReviewDetails);
        public Task<ResponeModel> Update(DoctorReviewDetailsModel doctorReviewDetails, int id);
       // public Task<ResponeModel> Delete(int id);
        public Task<ResponeModel> GetReviewDetail(int? id);

        // Get basic details for the doctor on to review the comment on claims
        Task<ResponeModel> GetReviewData(long advanceId, string url); 
    }
}
