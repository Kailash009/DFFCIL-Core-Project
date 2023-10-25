using HealthClaim.BAL.Repository.Interface;
using HealthClaim.DAL;
using HealthClaim.DAL.Models;
using HealthClaim.Model.Dtos.Common;
using HealthClaim.Model.Dtos.Employeefamily;
using HealthClaim.Model.Dtos.Response;
using HealthClaim.Utility.Eumus;
using HealthClaim.Utility.Resources;
using Microsoft.AspNetCore.Http;

namespace HealthClaim.BAL.Repository.Concrete
{
    public class EmployeefamilyRepository : GenricRepository<EmpFamily>, IEmployeefamilyRepository
    {
        private HealthClaimDbContext _dbContext;
        private ICommanRepository _commandRepo;
        #region Constructor
        /// <summary>
        /// This is constructor to set dependency injection
        /// </summary>
        /// <param name="db"></param>
        public EmployeefamilyRepository(HealthClaimDbContext db, ICommanRepository commandRepo) : base(db)
        {
            _dbContext = db;
            _commandRepo = commandRepo;
        }
        #endregion

        private async Task<List<UploadDocumentResponseModel>> UploadITRandPAN(List<IFormFile> files, string floderName)
        {
            bool status = false;
            var response = await _commandRepo.UploadDocumets(files, floderName);
            return response;
        }

        private async Task<bool> IsMemberAlreadyAdded(int relationId, long empId)
        {
            bool isMemberAlreadyAdded = false;

            var empFamily = _dbContext.EmpFamilys.Where(f => f.EmpId == empId && f.RelationId == relationId).FirstOrDefault();
            if (empFamily != null)
            {
                isMemberAlreadyAdded = true;
            }

            return isMemberAlreadyAdded;
        }

        #region Create Employee Family Member
        /// <summary>
        /// This method is used for add new employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        public async Task<ResponeModel> Create(EmployeefamilyModel employeefamily)
        {
            ResponeModel responeModel = new ResponeModel();
            if (employeefamily != null)
            {
                if (((long)employeefamily.RelationId) == 1 || ((long)employeefamily.RelationId) == 2 || ((long)employeefamily.RelationId) == 6)
                {
                    bool isAllreadAdded = await IsMemberAlreadyAdded(((int)employeefamily.RelationId), employeefamily.EmpId);
                    if (!isAllreadAdded)
                    {
                        long familyId = 0;
                        EmpFamily empFamily = null;
                        empFamily = new EmpFamily()
                        {
                            EmpId = employeefamily.EmpId,
                            Name = employeefamily.Name,
                            RelationId = ((long)employeefamily.RelationId),
                            BloodGroup = employeefamily.BloodGroup,
                            EmailId = employeefamily.EmailId,
                            MobileNo = employeefamily.MobileNo,
                            DateOfBirth = Convert.ToDateTime(employeefamily.DateOfBirth),
                            Gender = employeefamily.Gender,
                            IsActive = employeefamily.IsActive,
                            CreatedBy = employeefamily.EmpId,
                            CreatedDate = DateTime.Now,
                        };
                        _dbContext.Add(empFamily);
                        int id = await _dbContext.SaveChangesAsync();
                        familyId = empFamily.Id;

                        if (((long)employeefamily.RelationId) == 1 || ((long)employeefamily.RelationId) == 2)
                        {
                            // Upload ITR Details

                            if (employeefamily.ITRFile != null)
                            {

                                List<IFormFile> ITRFile = new List<IFormFile>() { employeefamily.ITRFile };

                                var responseUploadITR = await UploadITRandPAN(ITRFile, "ITR");
                                var financialYear = DateTime.Now.Month >= 4 ? DateTime.Now.Year + 1 : DateTime.Now.Year;

                                string itrFileName = string.Empty;
                                string itrFilePath = string.Empty;
                                if (responseUploadITR != null)
                                {
                                    itrFileName = responseUploadITR.FirstOrDefault().fileName;
                                    itrFilePath = responseUploadITR.FirstOrDefault().filePath;
                                }
                                var continueyear = Convert.ToInt32(DateTime.Now.AddYears(1).Year);

                                EmpFamilyITR empFamilyITR = new EmpFamilyITR()
                                {
                                    FamilyId = familyId,
                                    DocType = "ITR",
                                    FinancialYear = employeefamily.FinancialYear,
                                    CountingYear = continueyear,
                                    AnnualIncome = Convert.ToInt32(employeefamily.AnnualIncome),
                                    FileName = itrFileName,
                                    Path = itrFilePath,
                                    CreatedBy = employeefamily.EmpId,
                                    CreatedDate = DateTime.Now,
                                    IsActive = true
                                };

                                _dbContext.Add(empFamilyITR);
                                await _dbContext.SaveChangesAsync();


                            }

                            // Upload PAN Details

                            //if (employeefamily.PANFile != null)
                            //{
                            //    List<IFormFile> PANFile = new List<IFormFile>() { employeefamily.PANFile };

                            //    var responseUploadPAN = await UploadITRandPAN(PANFile, "PAN");

                            //    string panFileName = string.Empty;
                            //    string panFilePath = string.Empty;
                            //    if (responseUploadPAN != null)
                            //    {
                            //        panFileName = responseUploadPAN.FirstOrDefault().fileName;
                            //        panFilePath = responseUploadPAN.FirstOrDefault().filePath;
                            //    }

                            //    EmpFamilyPAN empFamilyPAN = new EmpFamilyPAN()
                            //    {
                            //        FamilyId = empFamily.Id,
                            //        PanNo = employeefamily.PANNo,
                            //        DateOfBirth = Convert.ToDateTime(employeefamily.DateOfBirth),
                            //        FileName = panFileName,
                            //        Path = panFilePath,
                            //        CreatedBy = employeefamily.EmpId,
                            //        CreatedDate = DateTime.Now,
                            //        IsActive = true
                            //    };

                            //    _dbContext.Add(empFamilyPAN);
                            //    await _dbContext.SaveChangesAsync();
                            //}

                        }
                        responeModel.Data = empFamily;
                        responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                        responeModel.Error = false;
                        responeModel.Message = CommonMessage.CreateMessage;

                    }
                    else
                    {
                        responeModel.Data = null;
                        responeModel.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        responeModel.Error = false;
                        responeModel.Message = EnumuDescription.GetEnumDescription(employeefamily.RelationId) + " is allready added.";

                    }
                }
                else
                {
                    EmpFamily empFamily = new EmpFamily()
                    {
                        EmpId = employeefamily.EmpId,
                        Name = employeefamily.Name,
                        RelationId = ((long)employeefamily.RelationId),
                        BloodGroup = employeefamily.BloodGroup,
                        EmailId = employeefamily.EmailId,
                        MobileNo = employeefamily.MobileNo,
                        DateOfBirth = Convert.ToDateTime(employeefamily.DateOfBirth),
                        Gender = employeefamily.Gender,
                        IsActive = employeefamily.IsActive,
                        CreatedBy = employeefamily.EmpId,
                        CreatedDate = DateTime.Now,
                    };
                    _dbContext.Add(empFamily);
                    int id = await _dbContext.SaveChangesAsync();
                    responeModel.Data = empFamily;
                    responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                    responeModel.Error = false;
                    responeModel.Message = CommonMessage.CreateMessage;

                }
            }
            return responeModel;
        }
        #endregion

        #region Delete
        /// <summary>
        /// This method is used for delete record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponeModel> Delete(int id)
        {
            ResponeModel responeModel = new ResponeModel();
            if (id != 0)
            {
                var empFamilyDetails = _dbContext.EmpFamilys.Where(e => e.Id == id).FirstOrDefault();

                if (empFamilyDetails != null)
                {
                    empFamilyDetails.IsActive = false;
                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = null;
                    responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                    responeModel.Error = false;
                    responeModel.Message = "Faimly record deleted successfully.";

                }
            }
            return responeModel;
        }
        #endregion

        private int CalulateAge(DateTime date)
        {
            DateTime dt1 = date;
            DateTime dt2 = DateTime.Now;


            int year = (dt2 - dt1).Days / 365;
            return year;
        }

        #region Get Faimly details
        /// <summary>
        /// This method is used for fetch the employee details and list of faimly
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponeModel> GetFamily(int? EmpId, string baseUrl = "")
        {
            ResponeModel responeModel = new ResponeModel();
            var empFaimly = _dbContext.EmpFamilys.Where(e => e.IsActive == true && EmpId == 0 ? e.EmpId == e.EmpId : e.EmpId == EmpId).ToList();
            var relationDetails = _dbContext.EmpRelations.Where(e => e.IsActive == true).ToList();
            var empFamilyITRsDetails = _dbContext.EmpFamilyITRs.Where(e => e.IsActive == true).ToList();

            List<object> dataFamilyMembers = new();
            if (empFaimly != null && empFaimly.Count != 0)
            {
                empFaimly = empFaimly.OrderByDescending(o => o.RelationId).ToList();
                foreach (var item in empFaimly)
                {
                    var iTR = empFamilyITRsDetails.Where(f => f.FamilyId == item.Id).FirstOrDefault();
                    string itrPath = string.Empty;
                    if (iTR != null)
                    {
                        itrPath = baseUrl + iTR.Path;
                    }
                    string relationName = relationDetails.Where(r => r.Id == item.RelationId).FirstOrDefault().Name;
                    var dataFamilyMember = new { id = item.Id, EmpId = item.Id, MemberName = item.Name, Relation = relationName, DOB = item.DateOfBirth.ToString("MM/dd/yyyy"), Age = CalulateAge(item.DateOfBirth), Gender = item.Gender, itrPath = itrPath };
                    dataFamilyMembers.Add(dataFamilyMember);
                }

            }

            responeModel.Data = dataFamilyMembers;
            responeModel.DataLength = empFaimly.Count;
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            responeModel.Message = empFaimly.Count + " Member found.";

            return responeModel;
        }
        #endregion

        #region Update Employee Details
        /// <summary>
        /// This method is used for update employee details
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponeModel> Update(UpdateEmployeefamilyModel employeefamilyModel, int id)
        {
            ResponeModel responeModel = new ResponeModel();
            if (employeefamilyModel != null && id != 0)
            {
                var employeefamilyDetails = _dbContext.Employees.Where(e => e.Id == id).FirstOrDefault();

                if (employeefamilyDetails != null)
                {
                    //employeeDetails.EmpId = employeeModel.EmpId;
                    employeefamilyDetails.BloodGroup = employeefamilyModel.BloodGroup;
                    employeefamilyDetails.EmailId = employeefamilyModel.EmailId;
                    employeefamilyDetails.Mobile = employeefamilyModel.MobileNo;
                    employeefamilyDetails.IsActive = employeefamilyModel.IsActive;
                    employeefamilyDetails.UpdatedDate = DateTime.Now;
                    employeefamilyDetails.UpdatedBy = 1;

                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = employeefamilyDetails;
                    responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                    responeModel.Error = false;
                    responeModel.Message = CommonMessage.UpdateMessage;

                }

            }
            return responeModel;
        }
        #endregion
    }
}
