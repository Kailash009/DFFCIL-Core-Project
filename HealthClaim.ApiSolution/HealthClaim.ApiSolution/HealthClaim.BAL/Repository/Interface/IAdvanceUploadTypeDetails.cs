using HealthClaim.BAL.Repository.Concrete;
using HealthClaim.DAL.Models;
using HealthClaim.Model.Dtos.Common;
using HealthClaim.Model.Dtos.EmpAccountDetail;
using HealthClaim.Model.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.BAL.Repository.Interface
{
    public interface IAdvanceUploadTypeDetails
    {
        public Task<ResponeModel> Create(AdvanceUploadTypeDetails advanceUploadTypeDetails);
        public Task<ResponeModel> Update(AdvanceUploadTypeDetails advanceUploadTypeDetails, int id);
        public Task<ResponeModel> Delete(int id);
        public Task<ResponeModel> Get(int? id);
    }
}
