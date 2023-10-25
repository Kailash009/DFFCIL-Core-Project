using HealthClaim.BAL.Repository.Concrete;
using HealthClaim.BAL.Repository.Interface;
using HealthClaim.DAL.Models;
using HealthClaim.Model.Dtos.Common;
using HealthClaim.Model.Dtos.EmpAccountDetail;
using HealthClaim.Model.Dtos.Employee;
using HealthClaim.Model.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthClaim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommanRepository _commanRepository;
        public CommonController(ICommanRepository commanRepository)
        {
            _commanRepository = commanRepository;
        }
        // GET: api/<CommonController>

        [HttpGet]
        public async Task<ResponeModel> Get()
        {
            var response = await _commanRepository.Get(0);
            return response;
        }

        [HttpGet("GetHospitalAccountDetail")]
        public async Task<ResponeModel> GetHospitalAccountDetail()
        {
            var response = await _commanRepository.GetHospitalAccountDetail(0);
            return response;
        }
        // GET api/<CommonController>/5
        [HttpGet("{id}")]
        public async Task<ResponeModel> Get(int id)
        {
            var response = await _commanRepository.Get(id);
            return response;
        }

        [HttpGet("GetHospitalAccountDetail/{id}")]
        public async Task<ResponeModel> GetHospitalAccountDetail(int id)
        {
            var response = await _commanRepository.GetHospitalAccountDetail(id);
            return response;
        }
        [HttpGet("IFSCCodeChecker/{ifscCode}")]
        public async Task<ResponeModel> IFSCCodeChecker(string ifscCode)
        {
            var response = await _commanRepository.IsIFSCCodeValid(ifscCode);
            return response;
        }

        // POST api/<CommonController>
        [HttpPost]
        public async Task<ResponeModel> Create ([FromBody] UplodDocTypeModel uplodDocTypeModel)
        {
            var response = await _commanRepository.CreateUploadDocType(uplodDocTypeModel);
            return response;
        }

        // POST api/<CommonController>
        [HttpPost("CreateHospitalAccountDetail")]
        public async Task<ResponeModel> CreateHospitalAccountDetail([FromBody] HospitalAccountDetailDto hospitalAccountDetailDto)
        {
            var response = await _commanRepository.CreateHospitalAccountDetail(hospitalAccountDetailDto);
            return response;
        }

        // PUT api/<CommonController>/5
        [HttpPut("{id}")]
        public async Task<ResponeModel> Put(int id, [FromBody] UplodDocTypeModel uplodDocTypeModel)
        {
            var response = await _commanRepository.UpdateUploadDocType(uplodDocTypeModel, id);
            return response;
        }

        // PUT api/<CommonController>/5
        [HttpPut("PutHospitalAccountDetail/{id}")]
        public async Task<ResponeModel> PutHospitalAccountDetail(int id, [FromBody] HospitalAccountDetailDto hospitalAccountDetailDto)
        {
            var response = await _commanRepository.UpdateHospitalAccountDetail(hospitalAccountDetailDto, id);
            return response;
        }

        // DELETE api/<CommonController>/5
        [HttpDelete("DeleteHospitalAccountDetail/{id}")]
        public async Task<ResponeModel> Delete(int id)
        {
            var response = await _commanRepository.DeleteHospitalAccountDetail(id);
            return response;
        }
        [HttpGet("GetITRDetails/{patientId}")]
        public async Task<ResponeModel> GetITRDetails(int patientId)
        {
            var url = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/";

            var response = await _commanRepository.GetITRDetails(patientId, url);
            return response;
        }

        
    }
}
