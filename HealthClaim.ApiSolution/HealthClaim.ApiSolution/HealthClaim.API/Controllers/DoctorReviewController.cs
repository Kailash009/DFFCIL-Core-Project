using HealthClaim.BAL.Repository.Interface;
using HealthClaim.Model.Dtos.DoctorReview;
using HealthClaim.Model.Dtos.EmpAdvance;
using HealthClaim.Model.Dtos.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthClaim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorReviewController : ControllerBase
    {
        private readonly IDoctorReviewRepository _doctorReviewRepository ;
        public DoctorReviewController(IDoctorReviewRepository doctorReviewRepository)
        {
            _doctorReviewRepository = doctorReviewRepository;
        }

        [HttpGet]
        public async Task<ResponeModel> Get()
        {
            var response = await _doctorReviewRepository.GetReviewDetail(0);
            return response;
        }
        [HttpGet("{id}")]
        public async Task<ResponeModel> Get(int id)
        {
            var response = await _doctorReviewRepository.GetReviewDetail(id);
            return response;
        }

        // GET api/<DoctorReviewController>/25
        // This is for getting basic details related to the claim patient for doctor review
        // Here doctor can see the hospital registration and hospital realated document only
        [HttpGet("GetAdvanceDetails/{advanceId}")]
        public async Task<ResponeModel> GetAdvanceDetails(long advanceId)
        {
            var url = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/";
            var response = await _doctorReviewRepository.GetReviewData(advanceId, url);
            return response;
        }

        // POST api/<DoctorReviewController>
        [HttpPost("CreateDoctorReview")]
        public async Task<ResponeModel> CreateDoctorReview([FromForm] DoctorReviewDetailsModel doctorReviewDetailsModel)
        {
            var response = await _doctorReviewRepository.Create(doctorReviewDetailsModel);
            return response;
        }

        // POST api/<DoctorReviewController>
        [HttpPost("UpdateDoctorReview/{id}")]
        public async Task<ResponeModel> UpdateDoctorReview(int id, [FromBody] DoctorReviewDetailsModel doctorReviewDetailsModel)
        {
            var response = await _doctorReviewRepository.Update(doctorReviewDetailsModel, id);
            return response;
        }
    }
}
