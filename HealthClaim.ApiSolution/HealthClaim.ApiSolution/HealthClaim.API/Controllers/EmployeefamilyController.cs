using HealthClaim.BAL.Repository.Concrete;
using HealthClaim.BAL.Repository.Interface;
using HealthClaim.Model.Dtos.Employee;
using HealthClaim.Model.Dtos.Employeefamily;
using HealthClaim.Model.Dtos.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthClaim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeefamilyController : ControllerBase
    {
        private readonly IEmployeefamilyRepository _employeefamilyRepository;
        private readonly ICommanRepository _commanRepository;
        public EmployeefamilyController(IEmployeefamilyRepository employeefamilyRepository, ICommanRepository commanRepository)
        {
            _employeefamilyRepository = employeefamilyRepository;
            _commanRepository = commanRepository;
        }

        // GET: api/<EmployeefamilyController>
        [HttpGet("GetFamily")]
        public async Task<ResponeModel> Get()
        {
            var url = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/";
            var response = await _employeefamilyRepository.GetFamily(0, url);
            return response;
        }

        // GET api/<EmployeefamilyController>/5
        [HttpGet("GetFamily/{EmpId}")]
        public async Task<ResponeModel> Get(int EmpId)
        {
            var url = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/";
            var response = await _employeefamilyRepository.GetFamily(EmpId, url);
            return response;
        }
        [HttpGet("GetRelation/{id}")]
        public async Task<ResponeModel> GetRelation(int id)
        {
            var response = await _commanRepository.GetEmpRelations(id);
            return response;
        }

        // POST api/<EmployeefamilyController>
        [HttpPost("CreateEmpRelation")]
        //[Route("/api/CreateEmpRelation")]
        public async Task<ResponeModel> CreateEmpFaimly([FromForm] EmployeefamilyModel employeefamilyModel)
        {

            var response = await _employeefamilyRepository.Create(employeefamilyModel);
            return response;
        }

        // PUT api/<EmployeefamilyController>/5
        [HttpPut("{id}")]
        public async Task<ResponeModel> Put(int id, [FromBody] UpdateEmployeefamilyModel employee)
        {
            var response = await _employeefamilyRepository.Update(employee, id);
            return response;
        }

        // DELETE api/<EmployeefamilyController>/5
        [HttpDelete("{id}")]
        public async Task<ResponeModel> Delete(int id)
        {
            var response = await _employeefamilyRepository.Delete(id);
            return response;
        }
    }
}
