using HealthClaim.Model.Dtos.EmpAccountDetail;
using HealthClaim.Model.Dtos.Employeefamily;
using HealthClaim.Model.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.BAL.Repository.Interface
{
    public interface IEmpAccountDetailRepository
    {
        public Task<ResponeModel> Create(EmpAccountDetailModel employeefamily);
        public Task<ResponeModel> Update(UpdateEmpAccountDetailModel employeefamily, int id);
        public Task<ResponeModel> Delete(int id);
        public Task<ResponeModel> GetEmpDetail(int? id);
    }
}
