using HealthClaim.Model.Dtos.Employee;
using HealthClaim.Model.Dtos.Finance;
using HealthClaim.Model.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.BAL.Repository.Interface
{
    public interface IFinanceRepository
    {
        public Task<ResponeModel> Create(FinanceModel financeModel);
        public Task<ResponeModel> Update(FinanceModel financeModel, int id);
        public Task<ResponeModel> Delete(int id);
        public Task<ResponeModel> Get(int? id);
    }
}
