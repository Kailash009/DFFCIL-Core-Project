using HealthClaim.BAL.Repository.Concrete;
using HealthClaim.BAL.Repository.Interface;
using HealthClaim.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.BAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private HealthClaimDbContext _db;

        public UnitOfWork(HealthClaimDbContext db)
        {
            _db = db;

            //ProductUnit = new EmpAdvanceRepository(_db);
        }

        //public IEmpAdvanceRepository ProductUnit { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}


