using HealthClaim.BAL.Repository.Interface;
using HealthClaim.DAL;
using HealthClaim.DAL.Models;
using HealthClaim.Model.Dtos.Common;
using HealthClaim.Model.Dtos.Response;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using HealthClaim.Utility.Eumus;
using System.Collections.Generic;

namespace HealthClaim.BAL.Repository.Concrete
{
    public class CommanRepository : GenricRepository<UplodDocType>, ICommanRepository
    {
        private HealthClaimDbContext _dbContext;

        public CommanRepository(HealthClaimDbContext db) : base(db)
        {
            _dbContext = db;
        }

        public Task<int> Create(HospitalAccountDetailDto hospitalAccountDetail)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponeModel> GetEmpRelations(int? id)
        {
            ResponeModel responeModel = new ResponeModel();
            var employees = _dbContext.EmpRelations.Where(e => e.IsActive == true && e.Id != 7 && id == 0 ? e.Id == e.Id : e.Id == id).ToList();
            responeModel.Data = employees;
            responeModel.DataLength = employees.Count;
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            responeModel.Message = employees.Count + " Employee Relation found.";

            return responeModel;
        }

        public Task<int> Update(HospitalAccountDetailDto hospitalAccountDetail, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponeModel> IsIFSCCodeValid(string ifscCode)
        {
            ResponeModel responeModel = new ResponeModel()
            {
                Data = null,
                Message = "Invalid IFSC Code Please try with another IFSC Code",
                Error = true,
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                ErrorDetail = "Invalid IFSC Code",
            };
            IfscResponseDetail ifscResponseDetail = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://ifsc.razorpay.com/" + ifscCode + "");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                ifscResponseDetail = JsonConvert.DeserializeObject<IfscResponseDetail>(apiResponse);
                responeModel.Data = ifscResponseDetail;
                responeModel.Message = "Valid IFSC Code";
                responeModel.Error = true;
                responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                responeModel.ErrorDetail = null;
            }
            return responeModel;
        }

        public async Task<ResponeModel> CreateHospitalAccountDetail(HospitalAccountDetailDto hospitalAccountDetailDto)
        {
            ResponeModel responeModel = new ResponeModel();
            if (hospitalAccountDetailDto != null)
            {

                HospitalAccountDetail hospitalAccountDetail = new HospitalAccountDetail()
                {
                    BankName = hospitalAccountDetailDto.BankName,
                    AccountNumber = hospitalAccountDetailDto.AccountNumber,
                    IfscCode = hospitalAccountDetailDto.IfscCode,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = hospitalAccountDetailDto.IsActive
                };
                _dbContext.Add(hospitalAccountDetail);
                int id = await _dbContext.SaveChangesAsync();
                responeModel.Data = hospitalAccountDetail;
                responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                responeModel.Error = false;
                responeModel.Message = "Hospital Account Details created successfully.";
            }
            return responeModel;
        }

        public async Task<ResponeModel> UpdateHospitalAccountDetail(HospitalAccountDetailDto hospitalAccountDetailDto, int id)
        {
            ResponeModel responeModel = new ResponeModel();
            if (hospitalAccountDetailDto != null && id != 0)
            {
                var hospitalaccountdetail = _dbContext.HospitalAccountDetails.Where(e => e.Id == id).FirstOrDefault();

                if (hospitalaccountdetail != null)
                {
                    hospitalaccountdetail.BankName = hospitalAccountDetailDto.BankName;
                    hospitalaccountdetail.AccountNumber = hospitalAccountDetailDto.AccountNumber;
                    hospitalaccountdetail.IfscCode = hospitalAccountDetailDto.IfscCode;
                    hospitalaccountdetail.IsActive = hospitalAccountDetailDto.IsActive;
                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = hospitalaccountdetail;
                    responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                    responeModel.Error = false;
                    responeModel.Message = "Hospital Account Updated Successfully";
                }
            }
            return responeModel;

        }

        public async Task<ResponeModel> CreateUploadDocType(UplodDocTypeModel uplodDocType)
        {
            ResponeModel responeModel = new ResponeModel();
            if (uplodDocType != null)
            {
                UplodDocType uplodDoc = new UplodDocType()
                {
                    Name = uplodDocType.Name,
                    IsBillable = uplodDocType.IsBillable,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };
                _dbContext.Add(uplodDoc);
                int id = await _dbContext.SaveChangesAsync();
                responeModel.Data = uplodDoc;
                responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                responeModel.Error = false;
                responeModel.Message = "Doc Type created successfully.";
            }
            return responeModel;
        }



        public async Task<ResponeModel> UpdateUploadDocType(UplodDocTypeModel uplodDocType, int id)
        {
            ResponeModel responeModel = new ResponeModel();
            if (uplodDocType != null && id != 0)
            {
                var updateDocType = _dbContext.UplodDocType.Where(e => e.Id == id).FirstOrDefault();

                if (updateDocType != null)
                {
                    updateDocType.Name = uplodDocType.Name;
                    updateDocType.IsBillable = uplodDocType.IsBillable;
                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = updateDocType;
                    responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                    responeModel.Error = false;
                    responeModel.Message = "Updated DocType Successfully";
                }
            }
            return responeModel;
        }

        public async Task<ResponeModel> DeleteUploadDocType(int id)
        {
            ResponeModel responeModel = new ResponeModel();
            if (id != 0)
            {
                var empDeleteDocType = _dbContext.UplodDocType.Where(e => e.Id == id).FirstOrDefault();

                if (empDeleteDocType != null)
                {
                    empDeleteDocType.IsActive = false;
                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = null;
                    responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                    responeModel.Error = false;
                    responeModel.Message = "UploadDocType record deleted successfully.";

                }
            }
            return responeModel;
        }


        public async Task<ResponeModel> Get(int? id)
        {
            ResponeModel responeModel = new ResponeModel();
            var empDocType = await _dbContext.UplodDocType.Where(e => id == 0 ? e.Id == e.Id : e.Id == id && e.IsActive == true).ToListAsync();
            responeModel.Data = empDocType;
            responeModel.DataLength = empDocType.Count;
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            responeModel.Message = empDocType.Count + " Employee Doc Type found By Id.";

            return responeModel;
        }


        public async Task<ResponeModel> DeleteHospitalAccountDetail(int id)
        {
            ResponeModel responeModel = new ResponeModel();
            if (id != 0)
            {
                var empDeleteDocType = _dbContext.HospitalAccountDetails.Where(e => e.Id == id).FirstOrDefault();

                if (empDeleteDocType != null)
                {
                    empDeleteDocType.IsActive = false;
                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = null;
                    responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                    responeModel.Error = false;
                    responeModel.Message = "Hospital Account record deleted successfully.";
                }
            }
            return responeModel;
        }

        public async Task<ResponeModel> GetHospitalAccountDetail(int? id)
        {
            ResponeModel responeModel = new ResponeModel();
            var hospitalAccountDetails = await _dbContext.HospitalAccountDetails.Where(e => e.IsActive == true && id == 0 ? e.Id == e.Id : e.Id == id).ToListAsync();
            responeModel.Data = hospitalAccountDetails;
            responeModel.DataLength = hospitalAccountDetails.Count;
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            responeModel.Message = hospitalAccountDetails.Count + " Hosptial Details found By Id.";
            return responeModel;
        }

        public async Task<List<UploadDocumentResponseModel>> UploadDocumets(List<IFormFile> files, string folderPathName = "AdmissionAdvice")
        {
            List<UploadDocumentResponseModel> filePaths = new();
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string basePath = "wwwroot/UploadDocuments/" + folderPathName + "";
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string filePathName = basePath;
                        if (!Directory.Exists(filePathName))
                        {
                            Directory.CreateDirectory(filePathName);
                        }
                        string filePath = Path.Combine(filePathName, fileName); // Save in 'admission_advice' folder
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        // Save the file path to the model
                        filePath = filePath.Replace("wwwroot", "");
                        var uploadDocumentResponse = new UploadDocumentResponseModel { filePath = filePath, fileName = file.FileName };
                        filePaths.Add(uploadDocumentResponse);
                    }
                }
            }
            return filePaths;
        }

        public async Task<ResponeModel> GetITRDetails(int patientId, string url)
        {
            ResponeModel responeModel = new ResponeModel();

            var itrDetails = _dbContext.EmpFamilyITRs.Where(f => f.FamilyId == patientId).OrderByDescending(d => d.Id).FirstOrDefault();
            if (itrDetails != null)
            {
                var empId = _dbContext.EmpFamilys.Where(f => f.Id == patientId).Select(f => f.EmpId).FirstOrDefault();

                var directClaimApproved = from emp in _dbContext.Employees
                                          join empProfile1 in _dbContext.EmpProfiles on emp.Id equals empProfile1.EmpId
                                          join org in _dbContext.OrgClaimLimits on empProfile1.EmpLavel equals org.Lavel
                                          join empAdv in _dbContext.EmpAdvances on emp.Id equals empAdv.EmplId
                                          join ecs in _dbContext.EmpClaimStatus on empAdv.ClaimId equals ecs.ClaimId
                                          where emp.Id == empId && empAdv.PatientId == patientId
                                          group new { emp, org, empAdv } by new { emp.Id, org.Limit } into grouped
                                          select new
                                          {
                                              EmployeeId = grouped.Key.Id,
                                              TotalLimit = grouped.Key.Limit,
                                              TotalApprovedAmount = grouped.Sum(x => x.empAdv.ApprovedAmount ?? 0)
                                          };

                var _itrDetail = new { financialYear = itrDetails.FinancialYear, annualIncome = itrDetails.AnnualIncome, itrFilePath = url + itrDetails.Path, TotalLimit = Convert.ToDouble(directClaimApproved.FirstOrDefault()?.TotalLimit), UsedLimit = Convert.ToDouble(directClaimApproved.FirstOrDefault()?.TotalApprovedAmount) };


                responeModel.Data = _itrDetail;
                responeModel.DataLength = 1;
                responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                responeModel.Error = false;
                responeModel.Message = "ITR Details found.";

            }
            else
            {
                responeModel.Data = null;
                responeModel.DataLength = 0;
                responeModel.StatusCode = System.Net.HttpStatusCode.NotFound;
                responeModel.Error = false;
                responeModel.Message = "Patient id is not found.";

            }
            return responeModel;
        }
    }
}
