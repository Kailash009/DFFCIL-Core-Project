using HealthClaim.BAL.Repository.Concrete;
using HealthClaim.BAL.Repository.Interface;
using HealthClaim.Model.Dtos.Employee;
using HealthClaim.Model.Dtos.OrgClaimLimit;
using HealthClaim.Model.Dtos.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthClaim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgClaimLimitController : ControllerBase
    {
        private readonly IOrgClaimLimitRepository orgClaimLimitRepository;

        public OrgClaimLimitController(IOrgClaimLimitRepository _orgLimitclaim)
        {
            orgClaimLimitRepository = _orgLimitclaim;
        }

        [HttpGet("OrgClaimLimit")]
        public async Task<ResponeModel> Get()
        {
            var response = await orgClaimLimitRepository.Get(0);
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ResponeModel> Get(int id)
        {
            var response = await orgClaimLimitRepository.Get(id);
            return response;
        }

        [HttpPost]
        public async Task<ResponeModel> Post([FromBody] OrgClaimLimitModal orgClaimLimitModal)
        {
            var response = await orgClaimLimitRepository.CreateOrgLimit(orgClaimLimitModal);
            return response;
        }

        [HttpPut("{id}")]
        public async Task<ResponeModel> Put(int id, [FromBody] OrgClaimLimitModal orgClaimLimitModal)
        {
            var response = await orgClaimLimitRepository.UpdateOrgLimit(orgClaimLimitModal, id);
            return response;
        }

        [HttpDelete("{id}")]
        public async Task<ResponeModel> Delete(int id)
        {
            var response = await orgClaimLimitRepository.DeleteOrgLimit(id);
            return response;
        }

    }

}