using HealthClaim.BAL.Repository.Interface;
using HealthClaim.Model.Dtos.EmpAccountDetail;
using HealthClaim.Model.Dtos.Employeefamily;
using HealthClaim.Model.Dtos.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthClaim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpAccountDetailController : ControllerBase
    {
        private readonly IEmpAccountDetailRepository _empAccountDetailRepository;
        public EmpAccountDetailController(IEmpAccountDetailRepository empAccountDetailRepository)
        {
            _empAccountDetailRepository = empAccountDetailRepository;
        }

        // GET: api/<EmpAccountDetailController>
        [HttpGet("GetDetails")]
        public async Task<ResponeModel> Get()
        {
            var response = await _empAccountDetailRepository.GetEmpDetail(0);
            return response;
        }

        // GET api/<EmpAccountDetailController>/5
        [HttpGet("GetDetails/{id}")]
        public async Task<ResponeModel> Get(int id)
        {
            var response = await _empAccountDetailRepository.GetEmpDetail(id);
            return response;
        }

        // POST api/<EmployeefamilyController>
        [HttpPost("CreateEmpDetail")]
        //[Route("/api/CreateEmpRelation")]
        public async Task<ResponeModel> CreateEmpDetail([FromBody] EmpAccountDetailModel empAccountDetailModel)
        {
            var response = await _empAccountDetailRepository.Create(empAccountDetailModel);
            return response;
        }

        // PUT api/<EmployeefamilyController>/5
        [HttpPut("{id}")]
        public async Task<ResponeModel> Put(int id, [FromBody] UpdateEmpAccountDetailModel updateEmpAccountDetailModel)
        {
            var response = await _empAccountDetailRepository.Update(updateEmpAccountDetailModel, id);
            return response;
        }

        // DELETE api/<EmployeefamilyController>/5
        [HttpDelete("{id}")]
        public async Task<ResponeModel> Delete(int id)
        {
            var response = await _empAccountDetailRepository.Delete(id);
            return response;
        }
    }
}
