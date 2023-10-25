using HealthClaim.Model.Dtos.Employee;
using HealthClaim.Model.Dtos.Employeefamily;
using HealthClaim.Model.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.BAL.Repository.Interface
{
    public interface IEmployeefamilyRepository
    {
        public Task<ResponeModel> Create(EmployeefamilyModel employeefamily);
        public Task<ResponeModel> Update(UpdateEmployeefamilyModel employeefamily, int id);
        public Task<ResponeModel> Delete(int id);
        public Task<ResponeModel> GetFamily(int? EmpId, string baseUrl="");
    }
}
