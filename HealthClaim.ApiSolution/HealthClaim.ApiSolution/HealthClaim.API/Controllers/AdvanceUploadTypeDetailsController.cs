using HealthClaim.BAL.Repository.Concrete;
using HealthClaim.BAL.Repository.Interface;
using HealthClaim.Model.Dtos.Common;
using HealthClaim.Model.Dtos.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthClaim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvanceUploadTypeDetailsController : ControllerBase
    {
        private readonly IAdvanceUploadTypeDetails _advanceUploadTypeDetails;
        public AdvanceUploadTypeDetailsController(IAdvanceUploadTypeDetails advanceUploadTypeDet)
        {
            _advanceUploadTypeDetails = advanceUploadTypeDet;
        }

        [HttpGet]
        public async Task<ResponeModel> Get()
        {

            var response = await _advanceUploadTypeDetails.Get(0);
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ResponeModel> Get(int id)
        {
            var response = await _advanceUploadTypeDetails.Get(id);
            return response;
        }

        [HttpPost]
        public async Task<ResponeModel> Create([FromBody] AdvanceUploadTypeDetails advanceUploadTypeDet)
        {
            var response = await _advanceUploadTypeDetails.Create(advanceUploadTypeDet);
            return response;
        }

        [HttpPut("{id}")]
        public async Task<ResponeModel> Put(int id, [FromBody] AdvanceUploadTypeDetails advanceUploadTypeDet)
        {
            var response = await _advanceUploadTypeDetails.Update(advanceUploadTypeDet, id);
            return response;
        }

        [HttpDelete("{id}")]
        public async Task<ResponeModel> Delete(int id)
        {
            var response = await _advanceUploadTypeDetails.Delete(id);
            return response;
        }

    }
}
