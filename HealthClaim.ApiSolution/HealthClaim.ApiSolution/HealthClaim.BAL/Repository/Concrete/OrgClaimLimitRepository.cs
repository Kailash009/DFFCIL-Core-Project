using HealthClaim.BAL.Repository.Interface;
using HealthClaim.DAL;
using HealthClaim.DAL.Models;
using HealthClaim.Model.Dtos.Employee;
using HealthClaim.Model.Dtos.OrgClaimLimit;
using HealthClaim.Model.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.BAL.Repository.Concrete
{
    public class OrgClaimLimitRepository : GenricRepository<OrgClaimLimit>, IOrgClaimLimitRepository
    {
        private HealthClaimDbContext _dbContext;
        public OrgClaimLimitRepository(HealthClaimDbContext db) : base(db)
        {
            _dbContext = db;
        }

        public async Task<ResponeModel> CreateOrgLimit(OrgClaimLimitModal orgClaimLimt)
        {
            ResponeModel responeModel = new ResponeModel();
            if (orgClaimLimt != null)
            {
                OrgClaimLimit orgCllimit = new OrgClaimLimit()
                {
                    Lavel = orgClaimLimt.Lavel,
                    Limit = orgClaimLimt.Limit,
                    ApplicableDate = DateTime.Now,
                    ApplicableYear = orgClaimLimt.ApplicableYear,
                    IsActive = orgClaimLimt.IsActive,
                    CreatedBy = 15,
                    CreatedDate = DateTime.Now,
                    //UpdatedBy = orgClaimLimt.UpdatedBy,
                    //UpdatedDate=DateTime.Now,
                };
                _dbContext.Add(orgCllimit);
                int id = await _dbContext.SaveChangesAsync();
                responeModel.Data = orgCllimit;
                responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                responeModel.Error = false;
                responeModel.Message = "OrgClaimLimit created successfully.";

            }
            return responeModel;
        }

        public async Task<ResponeModel> DeleteOrgLimit(int id)
        {
            ResponeModel responeModel = new ResponeModel();
            if (id != 0)
            {
                var OrgClaimLimtDetails = _dbContext.OrgClaimLimits.Where(e => e.Id == id).FirstOrDefault();

                if (OrgClaimLimtDetails != null)
                {
                    OrgClaimLimtDetails.IsActive = false;
                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = null;
                    responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                    responeModel.Error = false;
                    responeModel.Message = "OrgClaimLimit deleted successfully.";

                }
            }
            return responeModel;
        }

        public async Task<ResponeModel> Get(int? id)
        {
            ResponeModel responeModel1 = new ResponeModel();
            var orgGetClaimLimit = _dbContext.OrgClaimLimits.Where(e => id == 0 ? e.Id == e.Id : e.Id == id && e.IsActive == true).ToList();
            responeModel1.Data = orgGetClaimLimit;
            responeModel1.DataLength = orgGetClaimLimit.Count;
            responeModel1.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel1.Error = false;
            responeModel1.Message = orgGetClaimLimit.Count + " GetOrgClaimLimit found.";

            return responeModel1;
        }

        public async Task<ResponeModel> UpdateOrgLimit(OrgClaimLimitModal orgClaimLimt, int id)
        {
            ResponeModel responeModel = new ResponeModel();
            if (orgClaimLimt != null && id != 0)
            {
                var OrgClaimLimit = _dbContext.OrgClaimLimits.Where(e => e.Id == id).FirstOrDefault();

                if (orgClaimLimt != null)
                {
                    orgClaimLimt.Lavel = orgClaimLimt.Lavel;
                    orgClaimLimt.Limit = orgClaimLimt.Limit;
                    //orgClaimLimt.ApplicableDate = orgClaimLimt.ApplicableDate;
                    orgClaimLimt.ApplicableYear = orgClaimLimt.ApplicableYear;
                    orgClaimLimt.IsActive = orgClaimLimt.IsActive;
                    orgClaimLimt.UpdatedDate = DateTime.Now;

                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = orgClaimLimt;
                    responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                    responeModel.Error = false;
                    responeModel.Message = "OrgClaimLimit updated successfully.";

                }

            }
            return responeModel;
        }
    }
}