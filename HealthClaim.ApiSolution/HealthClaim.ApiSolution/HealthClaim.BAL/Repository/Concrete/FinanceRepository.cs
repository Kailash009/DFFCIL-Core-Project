using HealthClaim.BAL.Repository.Interface;
using HealthClaim.DAL;
using HealthClaim.DAL.Models;
using HealthClaim.Model.Dtos.Finance;
using HealthClaim.Model.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.BAL.Repository.Concrete
{
    public class FinanceRepository : GenricRepository<DoctorReview>, IFinanceRepository
    {
        private HealthClaimDbContext _dbContext;

        public FinanceRepository(HealthClaimDbContext db) : base(db)
        {
            _dbContext = db;
        }

        public Task<ResponeModel> Create(FinanceModel financeModel)
        {
            throw new NotImplementedException();
        }

        public Task<ResponeModel> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponeModel> Get(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponeModel> Update(FinanceModel financeModel, int id)
        {
            throw new NotImplementedException();
        }
    }
}
