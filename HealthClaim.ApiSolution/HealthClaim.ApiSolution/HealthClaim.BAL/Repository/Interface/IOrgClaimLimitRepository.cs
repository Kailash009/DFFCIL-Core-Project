using HealthClaim.Model.Dtos.Common;
using HealthClaim.Model.Dtos.OrgClaimLimit;
using HealthClaim.Model.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.BAL.Repository.Interface
{
    public interface IOrgClaimLimitRepository
    {
        public Task<ResponeModel> CreateOrgLimit(OrgClaimLimitModal orgClaimLimt);
        public Task<ResponeModel> UpdateOrgLimit(OrgClaimLimitModal orgClaimLimt, int id);
        public Task<ResponeModel> DeleteOrgLimit(int id);
        public Task<ResponeModel> Get(int? id);
    }
}