using HealthClaim.DAL.Models;
using HealthClaim.Model.Dtos.Claims;
using HealthClaim.Model.Dtos.EmpAdvance;
using HealthClaim.Model.Dtos.Response;

namespace HealthClaim.BAL.Repository.Interface
{
    public interface IEmpAdvanceRepository : IGenricRepository<EmpAdvance>
    {
        public Task<ResponeModel> Update(EmpAdvanceUpdateModel empAdvanceModel, int id);
        public Task<ResponeModel> Delete(int id);
        public Task<ResponeModel> Get(int? id);
        Task<ResponeModel> AdvanceRequest(EmpAdvanceModel empAdvanceModel);
        Task<ResponeModel> GetAdvanceApproved(long? empId);
        Task<ResponeModel> GetAdvanceRequest(long? empId, int recipientId);
        Task<ResponeModel> GetDirectClaimApproved(long? empId);
        Task<ResponeModel> GetDirectClaimRequest(long? empId, int recipientId);
        Task<ResponeModel> DirectCreateClaim(PatientAndOtherDetailsModel patientAndOtherDetails);
        public Task<ResponeModel> SubmitEmpClaimProcessDetails(EmpClaimProcessDetailsModel claimProcessDetailsModel);
        Task<ResponeModel> GetAdvanceDetails(long advanceId, string url);
        Task<ResponeModel> GetDirectClaimDetails(long advanceId, string url);
        Task<ResponeModel> GetClaimForDoctorUnderProcess(long recipientId);
        public Task<ResponeModel> UpdateInactiveEmpClaimProcessDetail(long id);

        Task<ResponeModel> EmpAdvanceTopUp(EmpAdvanceTopUpModel empAdvanceTopUp);
        Task<ResponeModel> AdvanceClaim(AdvanceClaimDetailsModel advanceClaimDetails);

    }

}
