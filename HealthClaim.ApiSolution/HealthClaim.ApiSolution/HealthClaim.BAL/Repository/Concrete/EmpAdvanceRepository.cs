using HealthClaim.BAL.Repository.Interface;
using HealthClaim.DAL;
using HealthClaim.DAL.Models;
using HealthClaim.Model.Dtos.Claims;
using HealthClaim.Model.Dtos.EmpAdvance;
using HealthClaim.Model.Dtos.Response;
using HealthClaim.Utility.Eumus;
using HealthClaim.Utility.Resources;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace HealthClaim.BAL.Repository.Concrete
{
    public class EmpAdvanceRepository : GenricRepository<EmpAdvance>, IEmpAdvanceRepository
    {
        private HealthClaimDbContext _dbContext;
        private ICommanRepository _commandRepo;
        #region Constructor
        /// <summary>
        /// This is constructor to set dependency injection
        /// </summary>
        /// <param name="db"></param>
        public EmpAdvanceRepository(HealthClaimDbContext db, ICommanRepository commandRepo) : base(db)
        {
            _dbContext = db;
            _commandRepo = commandRepo;
            //_commandRepo = commandRepo;
        }
        #endregion

        public async Task<ResponeModel> Delete(int id)
        {
            ResponeModel responeModel = new ResponeModel();
            if (id != 0)
            {
                var employeeAdvanceDetails = _dbContext.EmpAdvances.Where(e => e.Id == id).FirstOrDefault();

                if (employeeAdvanceDetails != null)
                {
                    employeeAdvanceDetails.IsActive = false;
                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = null;
                    responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                    responeModel.Error = false;
                    responeModel.Message = "Employee Advance deleted successfully.";

                }
            }
            return responeModel;
        }

        public async Task<ResponeModel> Get(int? id)
        {
            ResponeModel responeModel = new ResponeModel();
            var employeesAdvance = _dbContext.EmpAdvances.Where(e => id == 0 ? e.Id == e.Id : e.Id == id && e.IsActive == true).ToList();
            responeModel.Data = employeesAdvance;
            responeModel.DataLength = employeesAdvance.Count;
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            responeModel.Message = employeesAdvance.Count + " Employee Advance found.";

            return responeModel;
        }

        public async Task<ResponeModel> Update(EmpAdvanceUpdateModel empAdvanceModel, int id)
        {
            ResponeModel responeModel = new ResponeModel();
            if (empAdvanceModel != null && id != 0)
            {
                var employeeAdvanceUpdateDetails = _dbContext.EmpAdvances.Where(e => e.Id == id).FirstOrDefault();

                if (employeeAdvanceUpdateDetails != null)
                {
                    employeeAdvanceUpdateDetails.ApprovalDate = empAdvanceModel.ApprovalDate;
                    employeeAdvanceUpdateDetails.ApprovedAmount = empAdvanceModel.ApprovedAmount;
                    employeeAdvanceUpdateDetails.ApprovedById = empAdvanceModel.ApprovedById;
                    employeeAdvanceUpdateDetails.UpdatedDate = DateTime.Now;

                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = employeeAdvanceUpdateDetails;
                    responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                    responeModel.Error = false;
                    responeModel.Message = CommonMessage.UpdateMessage;

                }

            }
            return responeModel;
        }
        /// <summary>
        /// Get advance list for the employee on the base of employee Id 
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>

        public async Task<ResponeModel> AdvanceRequest(EmpAdvanceModel empAdvanceModel)
        {
            ResponeModel responeModel = new ResponeModel();
            if (empAdvanceModel != null)
            {
                // first add record in EmpClaim

                EmpClaim empClaim = new EmpClaim()
                {
                    IsSpecailDisease = false,
                    HospitalTotalBill = 0,
                    ClaimAmount = 0,
                    ClaimRequetsDate = DateTime.Now,
                    CreatedBy = empAdvanceModel.EmplId,
                    CreatedDate = DateTime.Now
                };

                _dbContext.Add(empClaim);
                await _dbContext.SaveChangesAsync();

                // then add record in EmpAdvance
                EmpAdvance employeeAdvanceData = new EmpAdvance()
                {
                    EmplId = empAdvanceModel.EmplId,
                    PatientId = empAdvanceModel.PatientId,
                    ClaimId = empClaim.Id,
                    RequestSubmittedById = empAdvanceModel.EmplId,
                    RequestName = empAdvanceModel.RequestName,
                    LikelyDate = empAdvanceModel.LikelyDateofAddmison,
                    AdvanceRequestDate = DateTime.Now, // Is input reuired or DateTime.Now() ?
                    AdvanceAmount = empAdvanceModel.AdvanceAmount,
                    EstimatedAmount = empAdvanceModel.EstimateAmount,

                    FinalHospitalBill = 0,
                    Reason = empAdvanceModel.Reason,
                    PayTo = empAdvanceModel.PayTo,
                    Claim_TypeId = ((long)RecordMasterClaimTypes.Advance),
                    //ApprovalDate = empAdvanceModel.ApprovalDate,
                    //ApprovedAmount = empAdvanceModel.ApprovedAmount,
                    // ApprovedById = empAdvanceModel.ApprovedById,
                    HospitalName = empAdvanceModel.HospitalName,
                    HospitalRegNo = empAdvanceModel.HospitalRegNo,
                    DateOfAdmission = empAdvanceModel.DateOfAdmission,
                    DoctorName = empAdvanceModel.DoctorName,
                    CreatedDate = DateTime.Now,
                    CreatedBy = empAdvanceModel.EmplId,
                    IsActive = true

                };

                _dbContext.Add(employeeAdvanceData);
                await _dbContext.SaveChangesAsync();

                // then add record in UploadDocument
                List<UploadDocument> uploadedDocuments = await FileUpload(empAdvanceModel, empClaim.Id);
                await _dbContext.AddRangeAsync(uploadedDocuments);
                await _dbContext.SaveChangesAsync();


                // Add status in EmpClaimStatus

                EmpClaimStatus empClaimStatus = new EmpClaimStatus()
                {
                    ClaimId = empClaim.Id,
                    ClaimTypeId = ((long)RecordMasterClaimTypes.Advance),
                    StatusId = ((long)RecordMasterClaimStatusCategory.ClaimInitiated),
                    CreatedBy = empAdvanceModel.EmplId,
                    CreatedDate = DateTime.Now
                };

                await _dbContext.AddAsync(empClaimStatus);
                await _dbContext.SaveChangesAsync();



                EmpClaimProcessDetails empClaimProcessDetails = new EmpClaimProcessDetails()
                {
                    ClaimId = empClaim.Id,
                    ClaimTypeId = ((long)RecordMasterClaimTypes.Advance),
                    SenderId = empAdvanceModel.EmplId,
                    RecipientId = ((long)RecordMasterIds.HR_OneID),
                    CreatedBy = empAdvanceModel.EmplId,
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                };

                await _dbContext.AddAsync(empClaimProcessDetails);
                await _dbContext.SaveChangesAsync();


                if (empAdvanceModel.PayTo == "Hospital" || empAdvanceModel.PayTo == "hospital")
                {
                    HospitalAccountDetail hospitalAccountDetail = new HospitalAccountDetail()
                    {
                        BankName = empAdvanceModel.BankName,
                        EmpAdvanceId = employeeAdvanceData.Id,
                        IfscCode = empAdvanceModel.IFSCCode,
                        AccountNumber = empAdvanceModel.BeneficiaryAccountNo,
                        BeneficiaryName = empAdvanceModel.BeneficiaryName,
                        CreatedBy = empAdvanceModel.EmplId,
                        CreatedDate = DateTime.Now
                    };
                    _dbContext.Add(hospitalAccountDetail);
                    await _dbContext.SaveChangesAsync();
                }

                var responseData = new { emplId = employeeAdvanceData.EmplId, patientId = employeeAdvanceData.PatientId, empclaimId = employeeAdvanceData.ClaimId, claimId = employeeAdvanceData.Id, requestSubmittedById = employeeAdvanceData.RequestSubmittedById };

                responeModel.Data = responseData;
                responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                responeModel.Error = false;
                responeModel.Message = CommonMessage.CreateMessage;
            }
            return responeModel;
        }

        public async Task<ResponeModel> SubmitEmpClaimProcessDetails(EmpClaimProcessDetailsModel claimProcessDetailsModel)
        {
            ResponeModel responeModel = new ResponeModel();
            var claimId = _dbContext.EmpAdvances.Where(f => f.Id == claimProcessDetailsModel.AdvanceId).Select(s => s.ClaimId).FirstOrDefault();
            if (claimId != 0)
            {

                EmpClaimProcessDetails empClaimProcessDetails = new EmpClaimProcessDetails()
                {
                    ClaimId = claimId,
                    ClaimTypeId = ((long)claimProcessDetailsModel.ClaimTypeId),
                    SenderId = claimProcessDetailsModel.SenderId,
                    RecipientId = claimProcessDetailsModel.RecipientId,
                    CreatedBy = claimProcessDetailsModel.SenderId,
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                };

                await _dbContext.AddAsync(empClaimProcessDetails);
                await _dbContext.SaveChangesAsync();

                EmpClaimStatus empClaimStatus = new EmpClaimStatus()
                {
                    ClaimId = claimId,
                    ClaimTypeId = ((long)claimProcessDetailsModel.ClaimTypeId),
                    StatusId = ((long)claimProcessDetailsModel.StatusId),
                    CreatedBy = claimProcessDetailsModel.SenderId,
                    CreatedDate = DateTime.Now
                };
                _dbContext.Add(empClaimStatus);
                await _dbContext.SaveChangesAsync();

                if (claimProcessDetailsModel.ClaimTypeId == RecordMasterClaimTypes.Advance)
                {
                    var empAdvance = _dbContext.EmpAdvances.Where(f => f.Id == claimProcessDetailsModel.AdvanceId).FirstOrDefault();
                    empAdvance.ApprovalDate = DateTime.Now;
                    empAdvance.ApprovedById = claimProcessDetailsModel.SenderId;
                    empAdvance.ApprovedAmount = claimProcessDetailsModel.ApprovalAmount;
                    _dbContext.Update(empAdvance);
                    await _dbContext.SaveChangesAsync();

                }
                if (claimProcessDetailsModel.ClaimTypeId == RecordMasterClaimTypes.TopUpAmount)
                {
                    var empAdvanceTopUp = _dbContext.EmpAdvanceTopUp.Where(f => f.Id == claimProcessDetailsModel.AdvanceId).FirstOrDefault();
                    empAdvanceTopUp.ApprovedDate = DateTime.Now;
                    empAdvanceTopUp.ApprovedById = claimProcessDetailsModel.SenderId;
                    empAdvanceTopUp.TopApprovedAmount = claimProcessDetailsModel.ApprovalAmount;
                    _dbContext.Update(empAdvanceTopUp);
                    await _dbContext.SaveChangesAsync();

                    var empAdvance = _dbContext.EmpAdvances.Where(f => f.Id == claimProcessDetailsModel.AdvanceId).FirstOrDefault();
                    empAdvance.ApprovalDate = DateTime.Now;
                    empAdvance.ApprovedById = claimProcessDetailsModel.SenderId;
                    empAdvance.ApprovedAmount = claimProcessDetailsModel.ApprovalAmount;
                    _dbContext.Update(empAdvance);
                    await _dbContext.SaveChangesAsync();

                }
                if (claimProcessDetailsModel.ClaimTypeId == RecordMasterClaimTypes.AdvanceClaim)
                {
                    var empClaim = _dbContext.EmployeeClaims.Where(f => f.Id == claimId).FirstOrDefault();

                    empClaim.ClaimApprovedDate = DateTime.Now;
                    empClaim.ClaimApprovedAmount = claimProcessDetailsModel.ApprovalAmount;
                    empClaim.ApprovedById = claimProcessDetailsModel.SenderId;
                    _dbContext.Update(empClaim);
                    await _dbContext.SaveChangesAsync();

                }
                if (claimProcessDetailsModel.ClaimTypeId == RecordMasterClaimTypes.DirectClaim)
                {
                    var empClaim = _dbContext.EmployeeClaims.Where(f => f.Id == claimId).FirstOrDefault();

                    empClaim.ClaimApprovedDate = DateTime.Now;
                    empClaim.ClaimApprovedAmount = claimProcessDetailsModel.ApprovalAmount;
                    empClaim.ApprovedById = claimProcessDetailsModel.SenderId;
                    _dbContext.Update(empClaim);
                    await _dbContext.SaveChangesAsync();

                }

                responeModel.Data = null;
                responeModel.DataLength = 0;
                responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                responeModel.Error = false;
                responeModel.Message = "Record updated succesfully.";
            }
            else
            {
                responeModel.Data = null;
                responeModel.DataLength = 0;
                responeModel.StatusCode = System.Net.HttpStatusCode.NotFound;
                responeModel.Error = false;
                responeModel.Message = "Advance id is invaid.";

            }
            return responeModel;
        }

        /// <summary>
        /// For uploading files from Emp Advance Model
        /// </summary>
        /// <param name="empAdvanceModel"></param>
        /// <returns></returns>
        private async Task<List<UploadDocument>> FileUpload(EmpAdvanceModel empAdvanceModel, long empClaimId)
        {
            List<UploadDocument> uploadedDocuments = new List<UploadDocument>();

            // Your existing file upload logic...
            List<string> filePathsAdmissionAdviceFile = new List<string>();
            // Handle AdmissionAdviceFile
            if (empAdvanceModel.AdmissionAdviceFile != null && empAdvanceModel.AdmissionAdviceFile.Count > 0)
            {
                foreach (var file in empAdvanceModel.AdmissionAdviceFile)
                {
                    if (file.Length > 0)
                    {
                        string basePath = "wwwroot/UploadDocuments/AdmissionAdvice";
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
                        filePathsAdmissionAdviceFile.Add(filePath);
                    }
                }
            }
            List<string> diagnosisFile = new List<string>();
            if (empAdvanceModel.DiagnosisFile != null && empAdvanceModel.DiagnosisFile.Count > 0)
            {
                foreach (var file in empAdvanceModel.DiagnosisFile)
                {
                    if (file.Length > 0)
                    {
                        string basePath = "wwwroot/UploadDocuments/DiagnosisUpload";
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
                        diagnosisFile.Add(filePath);
                    }
                }
            }
            List<string> estimateAmountFile = new List<string>();
            if (empAdvanceModel.EstimateAmountFile != null && empAdvanceModel.EstimateAmountFile.Count > 0)
            {
                foreach (var file in empAdvanceModel.EstimateAmountFile)
                {
                    if (file.Length > 0)
                    {
                        string basePath = "wwwroot/UploadDocuments/EstimateAmountFile";
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
                        estimateAmountFile.Add(filePath);
                    }
                }
            }

            if (filePathsAdmissionAdviceFile != null && filePathsAdmissionAdviceFile.Count != 0)
            {
                UploadTypeDetail AdmissionAdviceUploadType = new UploadTypeDetail()
                {
                    ClaimId = empClaimId,
                    ClaimTypeId = ((long)RecordMasterClaimTypes.Advance),
                    UploadTypeId = ((long)RecordMasterUplodDocType.AdmissionAdviceUpload),
                    Amount = empAdvanceModel.AdvanceAmount,
                    CreatedBy = empAdvanceModel.EmplId,
                    CreatedDate = DateTime.Now
                };
                _dbContext.Add(AdmissionAdviceUploadType);
                await _dbContext.SaveChangesAsync();
                // Add the file paths and other details to the UploadDocument list
                foreach (var filePath in filePathsAdmissionAdviceFile)
                {

                    var admissionAdviceDocument = new UploadDocument
                    {
                        AdvanceUploadTypeId = AdmissionAdviceUploadType.Id, // Set the appropriate type ID
                                                                            //Amount = empAdvanceModel.AdvanceAmount,
                        FileName = Path.GetFileName(filePath),
                        PathUrl = filePath,
                        Comment = "Admission Advice",
                        CreatedBy = empAdvanceModel.EmplId,
                        CreatedDate = DateTime.Now,

                    };
                    uploadedDocuments.Add(admissionAdviceDocument);
                }
            }
            if (diagnosisFile != null && diagnosisFile.Count != 0)
            {
                UploadTypeDetail diagnosisFileUploadType = new UploadTypeDetail()
                {
                    ClaimId = empClaimId,
                    ClaimTypeId = ((long)RecordMasterClaimTypes.Advance),
                    UploadTypeId = ((long)RecordMasterUplodDocType.Diagnosis),
                    Amount = empAdvanceModel.AdvanceAmount,
                    CreatedBy = empAdvanceModel.EmplId,
                    CreatedDate = DateTime.Now
                };
                _dbContext.Add(diagnosisFileUploadType);
                await _dbContext.SaveChangesAsync();
                foreach (var filePath in diagnosisFile)
                {
                    var diagnosisDocument = new UploadDocument
                    {
                        AdvanceUploadTypeId = diagnosisFileUploadType.Id, // Set the appropriate type ID
                                                                          // Amount = empAdvanceModel.AdvanceAmount,
                        FileName = Path.GetFileName(filePath),
                        PathUrl = filePath,
                        Comment = "Diagnosis Upload",
                        CreatedBy = empAdvanceModel.EmplId,
                        CreatedDate = DateTime.Now

                    };
                    uploadedDocuments.Add(diagnosisDocument);
                }

            }
            if (estimateAmountFile != null && estimateAmountFile.Count != 0)
            {
                UploadTypeDetail estimateAmountUploadType = new UploadTypeDetail()
                {
                    ClaimId = empClaimId,
                    ClaimTypeId = ((long)RecordMasterClaimTypes.Advance),
                    UploadTypeId = ((long)RecordMasterUplodDocType.EstimateAmount),
                    Amount = empAdvanceModel.AdvanceAmount,
                    CreatedBy = empAdvanceModel.EmplId,
                    CreatedDate = DateTime.Now
                };
                _dbContext.Add(estimateAmountUploadType);
                await _dbContext.SaveChangesAsync();
                foreach (var filePath in estimateAmountFile)
                {
                    var estimateAmountDocument = new UploadDocument
                    {
                        AdvanceUploadTypeId = estimateAmountUploadType.Id, // Set the appropriate type ID
                        Amount = empAdvanceModel.AdvanceAmount,
                        FileName = Path.GetFileName(filePath),
                        PathUrl = filePath,
                        Comment = "Estimate Amount File",
                        CreatedBy = empAdvanceModel.EmplId,
                        CreatedDate = DateTime.Now

                    };
                    uploadedDocuments.Add(estimateAmountDocument);
                }
            }



            return uploadedDocuments;
        }

        //Added On 16 Oct

        private async Task<List<UploadDocument>> UploadBillFiles(List<IFormFile> files, string floderName)
        {
            bool status = false;
            var response = await _commandRepo.UploadDocumets(files, floderName);
            List<UploadDocument> uploadDocuments = new List<UploadDocument>();
            if (response != null && response.Count != 0)
            {
                foreach (var item in response)
                {
                    UploadDocument uploadDocument = new UploadDocument()
                    {
                        FileName = item.fileName,
                        PathUrl = item.filePath
                    };

                    uploadDocuments.Add(uploadDocument);
                }

            }
            return uploadDocuments;
        }

        #region Claim Create
        /// <summary>
        /// This method is used for add new employee
        /// </summary>
        /// <param name="patientAndOtherDetails"></param>
        /// <returns></returns>
        public async Task<ResponeModel> DirectCreateClaim(PatientAndOtherDetailsModel patientAndOtherDetails)
        {
            ResponeModel responeModel = new ResponeModel();
            if (patientAndOtherDetails != null)
            {
                // Add Employee direct claim

                EmpClaim empClaim = new EmpClaim()
                {
                    IsSpecailDisease = patientAndOtherDetails.IsSpecailDisease,
                    HospitalTotalBill = patientAndOtherDetails.FinalHospitalBill,
                    ClaimAmount = patientAndOtherDetails.ClaimAmount,
                    ClaimRequetsDate = DateTime.Now,
                    CreatedBy = patientAndOtherDetails.EmpId,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                };
                _dbContext.Add(empClaim);
                await _dbContext.SaveChangesAsync();


                /// Then send data to the EmpClaimStatus
                EmpClaimStatus empClaimStatus = new EmpClaimStatus()
                {
                    ClaimId = empClaim.Id,
                    ClaimTypeId = ((long)RecordMasterClaimTypes.DirectClaim),
                    StatusId = ((long)RecordMasterClaimStatusCategory.ClaimInitiated),
                    CreatedBy = patientAndOtherDetails.EmpId,
                    CreatedDate = DateTime.Now
                };
                _dbContext.Add(empClaimStatus);
                await _dbContext.SaveChangesAsync();

                /// Then send data into EmpClaimBill

                EmpClaimBill empClaimBill = new EmpClaimBill()
                {
                    EmpClaimId = empClaim.Id,
                    EmpId = patientAndOtherDetails.EmpId,
                    StatusId = 1, // Claim Insited(Pending),
                    HospitalCompleteBill = patientAndOtherDetails.FinalHospitalBill,
                    MedicineBill = patientAndOtherDetails.MedicenBill.Amount,
                    ConsultationBill = patientAndOtherDetails.Consultation.Amount,
                    InvestigationBill = patientAndOtherDetails.Investigation.Amount,
                    RoomRentBill = patientAndOtherDetails.RoomRent.Amount,
                    OthersBill = patientAndOtherDetails.OtherBill.Amount,
                    CreatedBy = patientAndOtherDetails.EmpId,
                    CreatedDate = DateTime.Now
                };

                _dbContext.Add(empClaimBill);
                await _dbContext.SaveChangesAsync();

                if (patientAndOtherDetails.AdmissionAdviceUpload != null)
                {
                    var UploadDocuments = await UploadBillFiles(patientAndOtherDetails.AdmissionAdviceUpload, "AdmissionAdvice");
                    if (UploadDocuments != null && UploadDocuments.Count != 0)
                    {
                        UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                        {
                            ClaimId = empClaim.Id,
                            ClaimTypeId = ((long)RecordMasterClaimTypes.DirectClaim),
                            UploadTypeId = ((long)RecordMasterUplodDocType.AdmissionAdviceUpload),
                            Amount = 101,
                            CreatedBy = patientAndOtherDetails.EmpId,
                            CreatedDate = DateTime.Now
                        };

                        _dbContext.Add(uploadTypeDetail);
                        await _dbContext.SaveChangesAsync();

                        UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = patientAndOtherDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                        await _dbContext.AddRangeAsync(UploadDocuments);
                        await _dbContext.SaveChangesAsync();
                    }

                }
                if (patientAndOtherDetails.DischargeSummaryUpload != null)
                {
                    var UploadDocuments = await UploadBillFiles(patientAndOtherDetails.DischargeSummaryUpload, "DischargeSummary");
                    if (UploadDocuments != null && UploadDocuments.Count != 0)
                    {
                        UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                        {
                            ClaimId = empClaim.Id,
                            ClaimTypeId = ((long)RecordMasterClaimTypes.DirectClaim),
                            UploadTypeId = ((long)RecordMasterUplodDocType.DischargeSummary),
                            Amount = 101,
                            CreatedBy = patientAndOtherDetails.EmpId,
                            CreatedDate = DateTime.Now
                        };

                        _dbContext.Add(uploadTypeDetail);
                        await _dbContext.SaveChangesAsync();

                        UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = patientAndOtherDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                        await _dbContext.AddRangeAsync(UploadDocuments);
                        await _dbContext.SaveChangesAsync();
                    }

                }
                if (patientAndOtherDetails.InvestigationReportsUpload != null)
                {
                    var UploadDocuments = await UploadBillFiles(patientAndOtherDetails.InvestigationReportsUpload, "Investigation");
                    if (UploadDocuments != null && UploadDocuments.Count != 0)
                    {
                        UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                        {
                            ClaimId = empClaim.Id,
                            ClaimTypeId = ((long)RecordMasterClaimTypes.DirectClaim),
                            UploadTypeId = ((long)RecordMasterUplodDocType.Investigation),
                            Amount = 101,
                            CreatedBy = patientAndOtherDetails.EmpId,
                            CreatedDate = DateTime.Now
                        };

                        _dbContext.Add(uploadTypeDetail);
                        await _dbContext.SaveChangesAsync();

                        UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = patientAndOtherDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                        await _dbContext.AddRangeAsync(UploadDocuments);
                        await _dbContext.SaveChangesAsync();

                    }
                }
                if (patientAndOtherDetails.FinalHospitalBillUpload != null)
                {
                    var UploadDocuments = await UploadBillFiles(patientAndOtherDetails.FinalHospitalBillUpload, "FinalHospitalBillUpload");
                    if (UploadDocuments != null && UploadDocuments.Count != 0)
                    {

                        UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                        {
                            ClaimId = empClaim.Id,
                            ClaimTypeId = ((long)RecordMasterClaimTypes.DirectClaim),
                            UploadTypeId = ((long)RecordMasterUplodDocType.FinalHospitalBill),
                            Amount = patientAndOtherDetails.FinalHospitalBill,
                            CreatedBy = patientAndOtherDetails.EmpId,
                            CreatedDate = DateTime.Now
                        };

                        _dbContext.Add(uploadTypeDetail);
                        await _dbContext.SaveChangesAsync();

                        UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = patientAndOtherDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                        await _dbContext.AddRangeAsync(UploadDocuments);
                        await _dbContext.SaveChangesAsync();
                    }
                }
                if (patientAndOtherDetails.DiagnosisUpload != null)
                {
                    var UploadDocuments = await UploadBillFiles(patientAndOtherDetails.DiagnosisUpload, "DiagnosisUpload");
                    if (UploadDocuments != null && UploadDocuments.Count != 0)
                    {

                        UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                        {
                            ClaimId = empClaim.Id,
                            ClaimTypeId = ((long)RecordMasterClaimTypes.DirectClaim),
                            UploadTypeId = ((long)RecordMasterUplodDocType.Diagnosis),
                            Amount = 101,
                            CreatedBy = patientAndOtherDetails.EmpId,
                            CreatedDate = DateTime.Now
                        };

                        _dbContext.Add(uploadTypeDetail);
                        await _dbContext.SaveChangesAsync();

                        UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = patientAndOtherDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                        await _dbContext.AddRangeAsync(UploadDocuments);
                        await _dbContext.SaveChangesAsync();
                    }

                }



                // if bill is not in final bill then add to EmpClaimNotInMailBill table

                if (patientAndOtherDetails.MedicenNotFinalBill != null)
                {
                    var UploadDocuments = await UploadBillFiles(patientAndOtherDetails.MedicenNotFinalBill.Files, "MedicenNotFinalBill");

                    if (UploadDocuments != null && UploadDocuments.Count != 0)
                    {
                        UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                        {
                            ClaimId = empClaim.Id,
                            ClaimTypeId = ((long)RecordMasterClaimTypes.DirectClaim),
                            UploadTypeId = ((long)RecordMasterUplodDocType.MedicinenotinFinalBill),
                            Amount = Convert.ToDouble(patientAndOtherDetails.MedicenNotFinalBill.Amount),
                            CreatedBy = patientAndOtherDetails.EmpId,
                            CreatedDate = DateTime.Now
                        };
                        _dbContext.Add(uploadTypeDetail);
                        await _dbContext.SaveChangesAsync();


                        UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = patientAndOtherDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                        await _dbContext.AddRangeAsync(UploadDocuments);
                        await _dbContext.SaveChangesAsync();


                        EmpClaimNotInMailBill empClaimNotInMailBill = new EmpClaimNotInMailBill()
                        {
                            Amount = Convert.ToDouble(patientAndOtherDetails.MedicenNotFinalBill.Amount),
                            BillType = "Medicen Not In Final Bill",
                            EmpClaimBillId = empClaimBill.Id,
                            IsActive = true,
                            CreatedBy = empClaimBill.EmpId,
                            CreatedDate = DateTime.Now
                        };

                        _dbContext.Add(empClaimNotInMailBill);
                        await _dbContext.SaveChangesAsync();
                    }
                }
                if (patientAndOtherDetails.ConsultationNotFinalBill != null)
                {
                    var UploadDocuments = await UploadBillFiles(patientAndOtherDetails.ConsultationNotFinalBill.Files, "ConsultationNotFinalBill");
                    if (UploadDocuments != null && UploadDocuments.Count != 0)
                    {


                        UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                        {
                            ClaimId = empClaim.Id,
                            ClaimTypeId = ((long)RecordMasterClaimTypes.DirectClaim),
                            UploadTypeId = ((long)RecordMasterUplodDocType.ConsultationNotFinalBill),
                            Amount = Convert.ToDouble(patientAndOtherDetails.ConsultationNotFinalBill.Amount),
                            CreatedBy = patientAndOtherDetails.EmpId,
                            CreatedDate = DateTime.Now
                        };

                        _dbContext.Add(uploadTypeDetail);
                        await _dbContext.SaveChangesAsync();

                        UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = patientAndOtherDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                        await _dbContext.AddRangeAsync(UploadDocuments);
                        await _dbContext.SaveChangesAsync();


                        EmpClaimNotInMailBill empClaimNotInMailBill = new EmpClaimNotInMailBill()
                        {
                            Amount = Convert.ToDouble(patientAndOtherDetails.ConsultationNotFinalBill.Amount),
                            BillType = "Consultation Not In Final Bill",
                            EmpClaimBillId = empClaimBill.Id,
                            IsActive = true,
                            CreatedBy = empClaimBill.EmpId,
                            CreatedDate = DateTime.Now
                        };

                        _dbContext.Add(empClaimNotInMailBill);
                        await _dbContext.SaveChangesAsync();
                    }
                }
                if (patientAndOtherDetails.InvestigationNotFinalBill != null)
                {
                    var UploadDocuments = await UploadBillFiles(patientAndOtherDetails.InvestigationNotFinalBill.Files, "InvestigationNotFinalBill");
                    if (UploadDocuments != null && UploadDocuments.Count != 0)
                    {

                        UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                        {
                            ClaimId = empClaim.Id,
                            ClaimTypeId = ((long)RecordMasterClaimTypes.DirectClaim),
                            UploadTypeId = ((long)RecordMasterUplodDocType.InvestigationNotFinalBill),
                            Amount = Convert.ToDouble(patientAndOtherDetails.InvestigationNotFinalBill.Amount),
                            CreatedBy = patientAndOtherDetails.EmpId,
                            CreatedDate = DateTime.Now
                        };

                        _dbContext.Add(uploadTypeDetail);
                        await _dbContext.SaveChangesAsync();

                        UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = patientAndOtherDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                        await _dbContext.AddRangeAsync(UploadDocuments);
                        await _dbContext.SaveChangesAsync();


                        EmpClaimNotInMailBill empClaimNotInMailBill = new EmpClaimNotInMailBill()
                        {
                            Amount = Convert.ToDouble(patientAndOtherDetails.InvestigationNotFinalBill.Amount),
                            BillType = "Investigation Not In FinalBill",
                            EmpClaimBillId = empClaimBill.Id,
                            IsActive = true,
                            CreatedBy = empClaimBill.EmpId,
                            CreatedDate = DateTime.Now
                        };

                        _dbContext.Add(empClaimNotInMailBill);
                        await _dbContext.SaveChangesAsync();
                    }
                }
                if (patientAndOtherDetails.OtherBillNotFinalBill != null)
                {
                    var UploadDocuments = await UploadBillFiles(patientAndOtherDetails.OtherBillNotFinalBill.Files, "OtherBillNotFinalBill");
                    if (UploadDocuments != null && UploadDocuments.Count != 0)
                    {
                        UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                        {
                            ClaimId = empClaim.Id,
                            ClaimTypeId = ((long)RecordMasterClaimTypes.DirectClaim),
                            UploadTypeId = ((long)RecordMasterUplodDocType.OtherBillNotFinalBill),
                            Amount = Convert.ToDouble(patientAndOtherDetails.OtherBillNotFinalBill.Amount),
                            CreatedBy = patientAndOtherDetails.EmpId,
                            CreatedDate = DateTime.Now
                        };

                        _dbContext.Add(uploadTypeDetail);
                        await _dbContext.SaveChangesAsync();

                        UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = patientAndOtherDetails.EmpId; s.CreatedDate = DateTime.Now; s.Comment = ""; s.IsActive = true; return s; }).ToList();

                        await _dbContext.AddRangeAsync(UploadDocuments);
                        await _dbContext.SaveChangesAsync();

                        EmpClaimNotInMailBill empClaimNotInMailBill = new EmpClaimNotInMailBill()
                        {
                            Amount = Convert.ToDouble(patientAndOtherDetails.OtherBillNotFinalBill.Amount),
                            BillType = "Other Bill Not In FinalBill",
                            EmpClaimBillId = empClaimBill.Id,
                            IsActive = true,
                            CreatedBy = empClaimBill.EmpId,
                            CreatedDate = DateTime.Now
                        };

                        _dbContext.Add(empClaimNotInMailBill);
                        await _dbContext.SaveChangesAsync();
                    }
                }

                // Pre Hospitalization Expenses Save if IsPreHospitalizationExpenses is True
                if (patientAndOtherDetails.IsPreHospitalizationExpenses)
                {
                    if (patientAndOtherDetails.PreHospitalizationExpensesMedicine != null)
                    {
                        var UploadDocuments = await UploadBillFiles(patientAndOtherDetails.PreHospitalizationExpensesMedicine.Files, "PreHospitalizationExpensesMedicine");
                        if (UploadDocuments != null && UploadDocuments.Count != 0)
                        {

                            UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                            {
                                ClaimId = empClaim.Id,
                                ClaimTypeId = ((long)RecordMasterClaimTypes.DirectClaim),
                                UploadTypeId = ((long)RecordMasterUplodDocType.PreHospitalizationExpensesMedicine),
                                Amount = Convert.ToDouble(patientAndOtherDetails.PreHospitalizationExpensesMedicine.Amount),
                                CreatedBy = patientAndOtherDetails.EmpId,
                                CreatedDate = DateTime.Now,
                                IsActive = true,
                            };

                            _dbContext.Add(uploadTypeDetail);
                            await _dbContext.SaveChangesAsync();

                            UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = patientAndOtherDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                            await _dbContext.AddRangeAsync(UploadDocuments);
                            await _dbContext.SaveChangesAsync();
                        }
                    }
                    if (patientAndOtherDetails.PreHospitalizationExpensesConsultation != null)
                    {
                        var UploadDocuments = await UploadBillFiles(patientAndOtherDetails.PreHospitalizationExpensesConsultation.Files, "PreHospitalizationExpensesConsultation");
                        if (UploadDocuments != null && UploadDocuments.Count != 0)
                        {

                            UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                            {
                                ClaimId = empClaim.Id,
                                ClaimTypeId = ((long)RecordMasterClaimTypes.DirectClaim),
                                UploadTypeId = ((long)RecordMasterUplodDocType.PreHospitalizationExpensesConsultation),
                                Amount = Convert.ToDouble(patientAndOtherDetails.PreHospitalizationExpensesConsultation.Amount),
                                CreatedBy = patientAndOtherDetails.EmpId,
                                CreatedDate = DateTime.Now,
                                IsActive = true,
                            };

                            _dbContext.Add(uploadTypeDetail);
                            await _dbContext.SaveChangesAsync();

                            UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = patientAndOtherDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                            await _dbContext.AddRangeAsync(UploadDocuments);
                            await _dbContext.SaveChangesAsync();
                        }
                    }
                    if (patientAndOtherDetails.PreHospitalizationExpensesInvestigation != null)
                    {
                        var UploadDocuments = await UploadBillFiles(patientAndOtherDetails.PreHospitalizationExpensesInvestigation.Files, "PreHospitalizationExpensesInvestigation");
                        if (UploadDocuments != null && UploadDocuments.Count != 0)
                        {

                            UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                            {
                                ClaimId = empClaim.Id,
                                ClaimTypeId = ((long)RecordMasterClaimTypes.DirectClaim),
                                UploadTypeId = ((long)RecordMasterUplodDocType.PreHospitalizationExpensesInvestigation),
                                Amount = Convert.ToDouble(patientAndOtherDetails.PreHospitalizationExpensesInvestigation.Amount),
                                CreatedBy = patientAndOtherDetails.EmpId,
                                CreatedDate = DateTime.Now,
                                IsActive = true,
                            };

                            _dbContext.Add(uploadTypeDetail);
                            await _dbContext.SaveChangesAsync();

                            UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = patientAndOtherDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                            await _dbContext.AddRangeAsync(UploadDocuments);
                            await _dbContext.SaveChangesAsync();
                        }
                    }
                    if (patientAndOtherDetails.PreHospitalizationExpensesOther != null)
                    {
                        var UploadDocuments = await UploadBillFiles(patientAndOtherDetails.PreHospitalizationExpensesOther.Files, "PreHospitalizationExpensesOther");
                        if (UploadDocuments != null && UploadDocuments.Count != 0)
                        {

                            UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                            {
                                ClaimId = empClaim.Id,
                                ClaimTypeId = ((long)RecordMasterClaimTypes.DirectClaim),
                                UploadTypeId = ((long)RecordMasterUplodDocType.PreHospitalizationExpensesOther),
                                Amount = Convert.ToDouble(patientAndOtherDetails.PreHospitalizationExpensesOther.Amount),
                                CreatedBy = patientAndOtherDetails.EmpId,
                                CreatedDate = DateTime.Now,
                                IsActive = true,
                            };

                            _dbContext.Add(uploadTypeDetail);
                            await _dbContext.SaveChangesAsync();

                            UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = patientAndOtherDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                            await _dbContext.AddRangeAsync(UploadDocuments);
                            await _dbContext.SaveChangesAsync();
                        }

                    }

                }


                //Then send data to EmpAdvance
                EmpAdvance employeeAdvanceData = new EmpAdvance()
                {
                    EmplId = patientAndOtherDetails.EmpId,
                    PatientId = patientAndOtherDetails.PatientId,
                    ClaimId = empClaim.Id,
                    Claim_TypeId = ((long)RecordMasterClaimTypes.DirectClaim),
                    RequestSubmittedById = patientAndOtherDetails.EmpId,
                    RequestName = patientAndOtherDetails.RequestName,
                    AdvanceRequestDate = DateTime.Now, // Is input reuired or DateTime.Now() ?
                    AdvanceAmount = 0,
                    FinalHospitalBill = patientAndOtherDetails.FinalHospitalBill,
                    Reason = patientAndOtherDetails.Reason,
                    PayTo = patientAndOtherDetails.PayTo,
                    //ApprovalDate = patientAndOtherDetails.ApprovalDate,
                    //ApprovedAmount = patientAndOtherDetails.ApprovedAmount,
                    // ApprovedById = empAdvanceModel.ApprovedById,
                    HospitalName = patientAndOtherDetails.HospitalName,
                    HospitalRegNo = patientAndOtherDetails.HospitalRegNo,
                    DateOfAdmission = patientAndOtherDetails.DateOfAdmission,
                    DateofDischarge = patientAndOtherDetails.DateofDischarge,
                    DoctorName = patientAndOtherDetails.DoctorName,
                    IsPreHospitalizationExpenses = patientAndOtherDetails.IsPreHospitalizationExpenses,
                    CreatedDate = DateTime.Now,
                    CreatedBy = patientAndOtherDetails.EmpId
                };

                _dbContext.Add(employeeAdvanceData);
                await _dbContext.SaveChangesAsync();


                EmpClaimProcessDetails empClaimProcessDetails = new EmpClaimProcessDetails()
                {
                    ClaimId = empClaim.Id,
                    ClaimTypeId = ((long)RecordMasterClaimTypes.DirectClaim),
                    SenderId = patientAndOtherDetails.EmpId,
                    RecipientId = ((long)RecordMasterIds.HR_OneID),
                    CreatedBy = patientAndOtherDetails.EmpId,
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                };

                await _dbContext.AddAsync(empClaimProcessDetails);
                await _dbContext.SaveChangesAsync();


                var responseData = new { emplId = employeeAdvanceData.EmplId, patientId = employeeAdvanceData.PatientId, empclaimId = employeeAdvanceData.ClaimId, claimId = employeeAdvanceData.Id, requestSubmittedById = employeeAdvanceData.RequestSubmittedById };


                responeModel.Data = responseData;
                responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                responeModel.Error = false;
                responeModel.Message = CommonMessage.CreateMessage;
            }
            return responeModel;
        }


        #endregion End Claim Create
        public async Task<ResponeModel> GetAdvanceApproved(long? empId)
        {
            ResponeModel responeModel = new ResponeModel();
            var query = from ecpd in _dbContext.EmpClaimProcessDetails
                        join empadv in _dbContext.EmpAdvances on ecpd.ClaimId equals empadv.ClaimId
                        join ef in _dbContext.EmpFamilys on empadv.PatientId equals ef.Id
                        join emp in _dbContext.Employees on empadv.EmplId equals emp.Id
                        join empRel in _dbContext.EmpRelations on ef.RelationId equals empRel.Id
                        join ec in _dbContext.EmployeeClaims on empadv.ClaimId equals ec.Id
                        join claimType in _dbContext.ClaimTypes on ecpd.ClaimTypeId equals claimType.Id
                        join topUp in _dbContext.EmpAdvanceTopUp on empadv.Id equals topUp.EmpAdvanceId into topUpGroup
                        from topUp in topUpGroup.DefaultIfEmpty()
                        where ecpd.RecipientId == (from e in _dbContext.EmpClaimProcessDetails
                                                   where e.ClaimId == empadv.ClaimId
                                                   orderby e.Id descending
                                                   select e.RecipientId).FirstOrDefault()
                           && ecpd.ClaimTypeId == (from e in _dbContext.EmpClaimProcessDetails
                                                   where e.ClaimId == empadv.ClaimId
                                                   orderby e.Id descending
                                                   select e.ClaimTypeId).FirstOrDefault()
                        select new
                        {
                            empAdvId = empadv.Id,
                            EmpAdvanceObject = empadv,
                            EmployeeObject = emp,
                            EmployeeName = emp.Name,
                            patientId = empadv.PatientId,
                            patientName = ef.Name,
                            relation = empRel.Name,
                            claimType = claimType.Name,
                            claimId = ecpd.ClaimId,
                            SenderId = (from e in _dbContext.EmpClaimProcessDetails
                                        where e.ClaimId == ecpd.ClaimId
                                        orderby e.Id descending
                                        select e.SenderId).FirstOrDefault(),
                            RecipientId = ecpd.RecipientId,
                            ClaimTypeId = (from e in _dbContext.EmpClaimProcessDetails
                                           where e.ClaimId == ecpd.ClaimId
                                           orderby e.Id descending
                                           select e.ClaimTypeId).FirstOrDefault(),
                            Status = (from cs in _dbContext.ClaimStatusCategory
                                      where cs.Id == (from e in _dbContext.EmpClaimStatus
                                                      where e.ClaimId == ecpd.ClaimId
                                                      orderby e.Id descending
                                                      select e.StatusId).FirstOrDefault()
                                      select cs.Name).FirstOrDefault(),
                            StatusId = (from e in _dbContext.EmpClaimStatus
                                        where e.ClaimId == ecpd.ClaimId
                                        orderby e.Id descending
                                        select e.StatusId).FirstOrDefault(),
                            AdvanceAmount = ecpd.ClaimTypeId == 1 ? empadv.AdvanceAmount
                                            : ecpd.ClaimTypeId == 4 ? topUp.TopRequiredAmount
                                            : ecpd.ClaimTypeId == 2 || ecpd.ClaimTypeId == 3 ? ec.ClaimAmount : 0,
                            AdvanceRequestDate = ecpd.ClaimTypeId == 1 ? empadv.AdvanceRequestDate
                                                 : ecpd.ClaimTypeId == 4 ? topUp.CreatedDate
                                                 : ecpd.ClaimTypeId == 2 || ecpd.ClaimTypeId == 3 ? ec.ClaimRequetsDate : null,
                            ApprovedAmount = ecpd.ClaimTypeId == 1 ? empadv.ApprovedAmount
                                            : ecpd.ClaimTypeId == 4 ? topUp.TopApprovedAmount
                                            : 0,
                            ApprovalDate = ecpd.ClaimTypeId == 1 ? empadv.ApprovalDate
                                          : ecpd.ClaimTypeId == 4 ? topUp.ApprovedDate
                                          : null
                        };

            var claimAdvanceData = query.ToList().Where(f => (f.StatusId == ((long)RecordMasterClaimStatusCategory.Approved)) && (f.ClaimTypeId == ((long)RecordMasterClaimTypes.Advance)));

            if (empId != null)
            {
                claimAdvanceData = claimAdvanceData.Where(f => f.EmployeeObject.Id == empId).ToList();
            }
            List<object> empAdvanceData = new();
            if (claimAdvanceData != null && claimAdvanceData.Count() != 0)
            {

                foreach (var item in claimAdvanceData)
                {
                    var dataEmpAdvance = new
                    {
                        AdvanceId = item.EmpAdvanceObject.Id,
                        patientid = item.EmpAdvanceObject.PatientId,
                        EmpId = item.EmployeeObject.Id,
                        EmployeeName = item.EmployeeName,
                        PatientName = item.patientName,
                        Relation = item.relation,
                        AdvanceAmount = item.AdvanceAmount,
                        RequestDate = Convert.ToDateTime(item.AdvanceRequestDate).ToString("MM/dd/yyyy hh:mm tt"),
                        ApprovedAmount = item.ApprovedAmount,
                        ApprovedDate = item.ApprovalDate
                    };
                    empAdvanceData.Add(dataEmpAdvance);
                }
            }

            responeModel.Data = empAdvanceData;
            responeModel.DataLength = empAdvanceData.Count;
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            responeModel.Message = empAdvanceData.Count + " record detail found.";

            return responeModel;
        }
        public async Task<ResponeModel> GetAdvanceRequest(long? empId, int recipientId)
        {
            ResponeModel responeModel = new ResponeModel();

            var query = from ecpd in _dbContext.EmpClaimProcessDetails
                        join empadv in _dbContext.EmpAdvances on ecpd.ClaimId equals empadv.ClaimId
                        join ef in _dbContext.EmpFamilys on empadv.PatientId equals ef.Id
                        join emp in _dbContext.Employees on empadv.EmplId equals emp.Id
                        join empRel in _dbContext.EmpRelations on ef.RelationId equals empRel.Id
                        join ec in _dbContext.EmployeeClaims on empadv.ClaimId equals ec.Id
                        join claimType in _dbContext.ClaimTypes on ecpd.ClaimTypeId equals claimType.Id
                        join topUp in _dbContext.EmpAdvanceTopUp on empadv.Id equals topUp.EmpAdvanceId into topUpGroup
                        from topUp in topUpGroup.DefaultIfEmpty()
                        where ecpd.RecipientId == (from e in _dbContext.EmpClaimProcessDetails
                                                   where e.ClaimId == empadv.ClaimId
                                                   orderby e.Id descending
                                                   select e.RecipientId).FirstOrDefault()
                           && ecpd.ClaimTypeId == (from e in _dbContext.EmpClaimProcessDetails
                                                   where e.ClaimId == empadv.ClaimId
                                                   orderby e.Id descending
                                                   select e.ClaimTypeId).FirstOrDefault()
                        select new
                        {
                            empAdvId = empadv.Id,
                            EmpAdvanceObject = empadv,
                            EmployeeObject = emp,
                            EmployeeName = emp.Name,
                            patientId = empadv.PatientId,
                            patientName = ef.Name,
                            relation = empRel.Name,
                            claimType = claimType.Name,
                            claimId = ecpd.ClaimId,
                            SenderId = (from e in _dbContext.EmpClaimProcessDetails
                                        where e.ClaimId == ecpd.ClaimId
                                        orderby e.Id descending
                                        select e.SenderId).FirstOrDefault(),
                            RecipientId = ecpd.RecipientId,
                            ClaimTypeId = (from e in _dbContext.EmpClaimProcessDetails
                                           where e.ClaimId == ecpd.ClaimId
                                           orderby e.Id descending
                                           select e.ClaimTypeId).FirstOrDefault(),
                            Status = (from cs in _dbContext.ClaimStatusCategory
                                      where cs.Id == (from e in _dbContext.EmpClaimStatus
                                                      where e.ClaimId == ecpd.ClaimId
                                                      orderby e.Id descending
                                                      select e.StatusId).FirstOrDefault()
                                      select cs.Name).FirstOrDefault(),
                            StatusId = (from e in _dbContext.EmpClaimStatus
                                        where e.ClaimId == ecpd.ClaimId
                                        orderby e.Id descending
                                        select e.StatusId).FirstOrDefault(),
                            AdvanceAmount = ecpd.ClaimTypeId == 1 ? empadv.AdvanceAmount
                                            : ecpd.ClaimTypeId == 4 ? topUp.TopRequiredAmount
                                            : ecpd.ClaimTypeId == 2 || ecpd.ClaimTypeId == 3 ? ec.ClaimAmount : 0,
                            AdvanceRequestDate = ecpd.ClaimTypeId == 1 ? empadv.AdvanceRequestDate
                                                 : ecpd.ClaimTypeId == 4 ? topUp.CreatedDate
                                                 : ecpd.ClaimTypeId == 2 || ecpd.ClaimTypeId == 3 ? ec.ClaimRequetsDate : null,
                            ApprovedAmount = ecpd.ClaimTypeId == 1 ? empadv.ApprovedAmount
                                            : ecpd.ClaimTypeId == 4 ? topUp.TopApprovedAmount
                                            : 0,
                            ApprovalDate = ecpd.ClaimTypeId == 1 ? empadv.ApprovalDate
                                          : ecpd.ClaimTypeId == 4 ? topUp.ApprovedDate
                                          : null
                        };

            var claimAdvanceData = query.ToList().Where(f => f.RecipientId == recipientId && (f.StatusId == ((long)RecordMasterClaimStatusCategory.ClaimInitiated) || f.StatusId == ((long)RecordMasterClaimStatusCategory.TopUpInitiated)) && (f.ClaimTypeId == ((long)RecordMasterClaimTypes.Advance) || f.ClaimTypeId == ((long)RecordMasterClaimTypes.TopUpAmount)));

            if (empId != null)
            {
                claimAdvanceData = claimAdvanceData.Where(f => f.EmployeeObject.Id == empId).ToList();
            }

            List<object> empAdvanceData = new();
            if (claimAdvanceData != null && claimAdvanceData.Count() != 0)
            {

                foreach (var item in claimAdvanceData)
                {
                    var dataEmpAdvance = new
                    {
                        AdvanceId = item.EmpAdvanceObject.Id,
                        patientId = item.patientId,
                        claimType = item.claimType,
                        EmpId = item.EmployeeObject.Id,
                        EmployeeName = item.EmployeeName,
                        PatientName = item.patientName,
                        Relation = item.relation,
                        AdvanceAmount = item.AdvanceAmount,
                        RequestDate = Convert.ToDateTime(item.AdvanceRequestDate).ToString("MM/dd/yyyy"),
                        ApprovedAmount = item.ApprovedAmount,
                        ApprovedDate = item.ApprovalDate
                    };
                    empAdvanceData.Add(dataEmpAdvance);
                }
            }

            responeModel.Data = empAdvanceData;
            responeModel.DataLength = empAdvanceData.Count;
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            responeModel.Message = empAdvanceData.Count + " record found.";

            return responeModel;
        }

        public async Task<ResponeModel> GetDirectClaimApproved(long? empId)
        {
            ResponeModel responeModel = new ResponeModel();

            var query = from empAdv in _dbContext.EmpAdvances
                        join emp in _dbContext.Employees on empAdv.EmplId equals emp.Id
                        join empFaim in _dbContext.EmpFamilys on empAdv.PatientId equals empFaim.Id
                        join empRel in _dbContext.EmpRelations on empFaim.RelationId equals empRel.Id
                        join empclmStatus in _dbContext.EmpClaimStatus on empAdv.ClaimId equals empclmStatus.ClaimId
                        join claimStatus in _dbContext.ClaimStatusCategory on empclmStatus.StatusId equals claimStatus.Id
                        join empCreatedBy in _dbContext.Employees on empclmStatus.CreatedBy equals empCreatedBy.Id
                        join empUpdatedBy in _dbContext.Employees on empclmStatus.UpdatedBy equals empUpdatedBy.Id into empUpdatedByGroup
                        from empUpdatedBy in empUpdatedByGroup.DefaultIfEmpty()
                        select new
                        {
                            EmployeeObject = emp,
                            EmpclmStatusObject = empclmStatus,
                            EmpAdvanceObject = empAdv,
                            EmployeeName = emp.Name,
                            PatientName = empFaim.Name,
                            Relation = empRel.Name,
                            AdvanceAmount = empAdv.AdvanceAmount,
                            RequestDate = empAdv.AdvanceRequestDate,
                            ApprovedAmount = empAdv.ApprovedAmount == null ? 0 : empAdv.ApprovedAmount,
                            ApprovedDate = empAdv.ApprovalDate == null ? "NA" : Convert.ToDateTime(empAdv.ApprovalDate).ToString("MM/dd/yyyy hh:mm tt"),
                            Status = claimStatus.Name,
                            CreatedBy = empCreatedBy.Name,
                            CreatedDate = empclmStatus.CreatedDate,
                            UpdatedBy = empUpdatedBy != null ? empUpdatedBy.Name : null,
                            UpdatedDate = empclmStatus.UpdatedDate
                        };


            var claimAdvanceData = query.ToList().Where(f => f.EmpclmStatusObject.StatusId == ((long)RecordMasterClaimStatusCategory.Approved) && f.EmpclmStatusObject.ClaimTypeId == ((long)RecordMasterClaimTypes.DirectClaim)).OrderByDescending(o => o.CreatedDate).ToList();

            if (empId != null)
            {
                claimAdvanceData = claimAdvanceData.Where(f => f.EmployeeObject.Id == empId).ToList();
            }
            List<object> empAdvanceData = new();
            if (claimAdvanceData != null && claimAdvanceData.Count() != 0)
            {

                foreach (var item in claimAdvanceData)
                {
                    var dataEmpAdvance = new
                    {
                        DirectClaimId = item.EmpAdvanceObject.Id,
                        patientId = item.EmpAdvanceObject.PatientId,
                        EmpId = item.EmployeeObject.Id,
                        EmployeeName = item.EmployeeName,
                        PatientName = item.PatientName,
                        Relation = item.Relation,
                        AdvanceAmount = item.AdvanceAmount,
                        RequestDate = item.RequestDate.ToString("MM/dd/yyyy"),
                        ApprovedAmount = item.ApprovedAmount,
                        ApprovedDate = item.ApprovedDate
                    };
                    empAdvanceData.Add(dataEmpAdvance);
                }
            }

            responeModel.Data = empAdvanceData;
            responeModel.DataLength = empAdvanceData.Count;
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            responeModel.Message = empAdvanceData.Count + " Direct claim approved details found.";

            return responeModel;
        }

        public async Task<ResponeModel> GetDirectClaimRequest(long? empId, int recipientId)
        {
            ResponeModel responeModel = new ResponeModel();
            var query = from ecpd in _dbContext.EmpClaimProcessDetails
                        join empadv in _dbContext.EmpAdvances on ecpd.ClaimId equals empadv.ClaimId
                        join ef in _dbContext.EmpFamilys on empadv.PatientId equals ef.Id
                        join emp in _dbContext.Employees on empadv.EmplId equals emp.Id
                        join empRel in _dbContext.EmpRelations on ef.RelationId equals empRel.Id
                        join ec in _dbContext.EmployeeClaims on empadv.ClaimId equals ec.Id
                        join claimType in _dbContext.ClaimTypes on ecpd.ClaimTypeId equals claimType.Id
                        join topUp in _dbContext.EmpAdvanceTopUp on empadv.Id equals topUp.EmpAdvanceId into topUpGroup
                        from topUp in topUpGroup.DefaultIfEmpty()
                        where ecpd.RecipientId == (from e in _dbContext.EmpClaimProcessDetails
                                                   where e.ClaimId == empadv.ClaimId
                                                   orderby e.Id descending
                                                   select e.RecipientId).FirstOrDefault()
                           && ecpd.ClaimTypeId == (from e in _dbContext.EmpClaimProcessDetails
                                                   where e.ClaimId == empadv.ClaimId
                                                   orderby e.Id descending
                                                   select e.ClaimTypeId).FirstOrDefault()
                        select new
                        {
                            empAdvId = empadv.Id,
                            EmpAdvanceObject = empadv,
                            EmployeeObject = emp,
                            EmployeeName = emp.Name,
                            patientId = empadv.PatientId,
                            patientName = ef.Name,
                            relation = empRel.Name,
                            claimType = claimType.Name,
                            claimId = ecpd.ClaimId,
                            SenderId = (from e in _dbContext.EmpClaimProcessDetails
                                        where e.ClaimId == ecpd.ClaimId
                                        orderby e.Id descending
                                        select e.SenderId).FirstOrDefault(),
                            RecipientId = ecpd.RecipientId,
                            ClaimTypeId = (from e in _dbContext.EmpClaimProcessDetails
                                           where e.ClaimId == ecpd.ClaimId
                                           orderby e.Id descending
                                           select e.ClaimTypeId).FirstOrDefault(),
                            Status = (from cs in _dbContext.ClaimStatusCategory
                                      where cs.Id == (from e in _dbContext.EmpClaimStatus
                                                      where e.ClaimId == ecpd.ClaimId
                                                      orderby e.Id descending
                                                      select e.StatusId).FirstOrDefault()
                                      select cs.Name).FirstOrDefault(),
                            StatusId = (from e in _dbContext.EmpClaimStatus
                                        where e.ClaimId == ecpd.ClaimId
                                        orderby e.Id descending
                                        select e.StatusId).FirstOrDefault(),
                            AdvanceAmount = ecpd.ClaimTypeId == 1 ? empadv.AdvanceAmount
                                            : ecpd.ClaimTypeId == 4 ? topUp.TopRequiredAmount
                                            : ecpd.ClaimTypeId == 2 || ecpd.ClaimTypeId == 3 ? ec.ClaimAmount : 0,
                            AdvanceRequestDate = ecpd.ClaimTypeId == 1 ? empadv.AdvanceRequestDate
                                                 : ecpd.ClaimTypeId == 4 ? topUp.CreatedDate
                                                 : ecpd.ClaimTypeId == 2 || ecpd.ClaimTypeId == 3 ? ec.ClaimRequetsDate : null,
                            ApprovedAmount = ecpd.ClaimTypeId == 1 ? empadv.ApprovedAmount
                                            : ecpd.ClaimTypeId == 4 ? topUp.TopApprovedAmount
                                            : 0,
                            ApprovalDate = ecpd.ClaimTypeId == 1 ? empadv.ApprovalDate
                                          : ecpd.ClaimTypeId == 4 ? topUp.ApprovedDate
                                          : null
                        };

            var claimAdvanceData = query.ToList().Where(f => f.RecipientId == recipientId && (f.StatusId == ((long)RecordMasterClaimStatusCategory.ClaimInitiated)) && (f.ClaimTypeId == ((long)RecordMasterClaimTypes.AdvanceClaim) || f.ClaimTypeId == ((long)RecordMasterClaimTypes.DirectClaim)));

            //var claimAdvanceData = query.ToList().OrderByDescending(o => o.CreatedDate).ToList();

            if (empId != null)
            {
                claimAdvanceData = claimAdvanceData.Where(f => f.EmployeeObject.Id == empId).ToList();
            }
            List<object> empAdvanceData = new();
            if (claimAdvanceData != null && claimAdvanceData.Count() != 0)
            {

                foreach (var item in claimAdvanceData)
                {
                    var dataEmpAdvance = new
                    {
                        DirectClaimId = item.EmpAdvanceObject.Id,
                        EmpId = item.EmployeeObject.Id,
                        EmployeeName = item.EmployeeName,
                        PatientName = item.patientName,
                        patientId = item.EmpAdvanceObject.PatientId,
                        Relation = item.relation,
                        AdvanceAmount = item.AdvanceAmount,
                        RequestDate = Convert.ToDateTime(item.AdvanceRequestDate).ToString("MM/dd/yyyy"),
                        ApprovedAmount = item.ApprovedAmount,
                        ApprovedDate = item.ApprovalDate
                    };
                    empAdvanceData.Add(dataEmpAdvance);
                }
            }

            responeModel.Data = empAdvanceData;
            responeModel.DataLength = empAdvanceData.Count;
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            responeModel.Message = empAdvanceData.Count + " Direct claim details found.";

            return responeModel;
        }

        #region Get advance details

        public async Task<ResponeModel> GetAdvanceDetails(long advanceId, string url)
        {
            ResponeModel responeModel = new ResponeModel();
            var query = from empAdv in _dbContext.EmpAdvances
                        join faimly in _dbContext.EmpFamilys on empAdv.PatientId equals faimly.Id
                        join rel in _dbContext.EmpRelations on faimly.RelationId equals rel.Id
                        join empClaimStatus in _dbContext.EmpClaimStatus on empAdv.ClaimId equals empClaimStatus.ClaimId
                        join claimStatus in _dbContext.ClaimStatusCategory on empClaimStatus.StatusId equals claimStatus.Id
                        join claimtype in _dbContext.ClaimTypes on empClaimStatus.ClaimTypeId equals claimtype.Id
                        where empAdv.Id == advanceId && empClaimStatus.ClaimTypeId == ((long)RecordMasterClaimTypes.Advance)
                        select new
                        {
                            empAdvId = empAdv.Id,
                            claimtype.Name,
                            empAdv.ClaimId,
                            claimStatus,
                            faimly.EmpId,
                            patientId = empAdv.PatientId,
                            patientName = faimly.Name,
                            relation = rel.Name,
                            dateOfBirth = faimly.DateOfBirth.ToString("MM/dd/yyyy"),
                            faimly.Gender,
                            hospitalName = empAdv.HospitalName,
                            hospitalRegNo = empAdv.HospitalRegNo,
                            likelyDateofAddmission = empAdv.LikelyDate,
                            doctorName = empAdv.DoctorName,
                            advanceReqAmount = empAdv.AdvanceAmount,
                            estimatedAmount = empAdv.EstimatedAmount,
                            empAdv.PayTo,
                            RequestedDate = empClaimStatus.CreatedDate.ToString("MM/dd/yyyy HH:mm tt"),
                            ApprovalDate = empAdv.ApprovalDate == null ? "NA" : empAdv.ApprovalDate.Value.ToString("MM/dd/yyyy HH:mm tt"),
                            ApprovedAmount = empAdv.ApprovedAmount ?? 0
                        };

            List<object> documentLists = new List<object>();
            List<object> topUpList = new List<object>();



            if (query != null && query.Count() != 0)
            {
                //var documentsType = query;

                var documentsType = _dbContext.UploadTypeDetails.Where(f => f.ClaimId == query.FirstOrDefault().ClaimId && f.ClaimTypeId == ((long)RecordMasterClaimTypes.Advance)).Select(d => new { d.Id, d.UploadTypeId }).ToList();

                if (documentsType != null)
                {
                    for (int i = 0; i < documentsType.Count; i++)
                    {
                        var uploadDocuments = _dbContext.UploadDocuments.Where(f => f.AdvanceUploadTypeId == documentsType[i].Id).ToList();
                        if (uploadDocuments != null && uploadDocuments.Count != 0)
                        {
                            var uploadType = _dbContext.UplodDocType.Where(f => f.Id == documentsType[i].UploadTypeId).FirstOrDefault();
                            foreach (var itemuploadDocument in uploadDocuments)
                            {
                                var document = new { category = uploadType?.Name, remark = itemuploadDocument.Comment, pathUrl = url + itemuploadDocument.PathUrl };
                                documentLists.Add(document);
                            }

                        }

                    }


                }

                var advance = query.FirstOrDefault();
                var advanceBasicDetails = new
                {
                    patientName = advance.patientName,
                    patientId = advance.patientId,
                    relation = advance.relation,
                    dateOfBirth = advance.dateOfBirth,
                    gender = advance.Gender,
                    hospitalName = advance.hospitalName,
                    hospitalRegNo = advance.hospitalRegNo,
                    //dateOfAdmission = advance.dateOfAdmission,
                    doctorName = advance.doctorName,
                    advanceReqAmount = advance.advanceReqAmount,
                    likelyDateofAddmission = advance.likelyDateofAddmission,
                    estimatedAmount = advance.estimatedAmount,
                    claimStatus = advance.claimStatus,
                    requestedDate = advance.RequestedDate,
                    claimApprovedDate = advance.ApprovalDate,
                    claimApprovedAmount = advance.ApprovedAmount
                };
                HospitalAccoundetail hospitalAccoundetail = new HospitalAccoundetail();
                if (advance.PayTo == "Hospital")
                {
                    var hospitalDetailsDto = _dbContext.HospitalAccountDetails.Where(f => f.EmpAdvanceId == advanceId).FirstOrDefault();
                    if (hospitalDetailsDto != null)
                    {

                        hospitalAccoundetail.BeneficiaryName = hospitalDetailsDto.BeneficiaryName;
                        hospitalAccoundetail.AccountNumber = hospitalDetailsDto.AccountNumber;
                        hospitalAccoundetail.BankName = hospitalDetailsDto.BankName;
                        hospitalAccoundetail.UTRNo = "";

                    }
                }
                else
                {

                }

                var queryGetTopList = (from topUp in _dbContext.EmpAdvanceTopUp
                                       join empAdv in _dbContext.EmpAdvances on topUp.EmpAdvanceId equals empAdv.Id
                                       join ecs in _dbContext.EmpClaimStatus on topUp.Id equals ecs.EmpAdvanceTopId
                                       join claimStatus in _dbContext.ClaimStatusCategory on ecs.StatusId equals claimStatus.Id
                                       where empAdv.Id == advanceId
                                       select new
                                       {
                                           topUpId = topUp.Id,
                                           topUpApprovedStatus = claimStatus.Name,
                                           empAdv.ClaimId,
                                           topUp.ReviseEstimentedAmount,
                                           topUp.TopRequiredAmount,
                                           ApprovedAmount = topUp.TopApprovedAmount ?? 0,
                                           ApprovedDate = topUp.ApprovedDate != null ? topUp.ApprovedDate.ToString() : "NA",
                                           topUp.PayTo,
                                           topUp.BankName,
                                           topUp.AccountNumber,
                                           topUp.IfscCode,
                                           topUp.BeneficiaryName
                                       }).ToList();

                foreach (var item in queryGetTopList)
                {
                    List<object> estimateFiles = null;
                    var uploadTypeDetails = _dbContext.UploadTypeDetails.Where(f => f.ClaimId == item.ClaimId && f.ClaimTypeId == ((long)RecordMasterClaimTypes.TopUpAmount)).Select(d => d.Id).ToList();
                    if (uploadTypeDetails != null)
                    {
                        for (int i = 0; i < uploadTypeDetails.Count; i++)
                        {
                            estimateFiles = new List<object>();
                            var uploadDocuments = _dbContext.UploadDocuments.Where(f => f.AdvanceUploadTypeId == uploadTypeDetails[i]).ToList();
                            if (uploadDocuments != null && uploadDocuments.Count != 0)
                            {
                                foreach (var itemuploadDocument in uploadDocuments)
                                {
                                    var _estimetFileMode = new { filePath = url + itemuploadDocument.PathUrl, comment = itemuploadDocument.Comment };
                                    estimateFiles.Add(_estimetFileMode);

                                }

                            }

                        }


                    }
                    var topUpModel = new
                    {
                        reviseEstimentedAmount = item.ReviseEstimentedAmount,
                        topRequiredAmount = item.TopRequiredAmount,
                        approvedAmount = item.ApprovedAmount,
                        approvedDate = item.ApprovedDate,
                        payTo = item.PayTo,
                        bankName = item.BankName,
                        accountNumber = item.AccountNumber,
                        ifscCode = item.IfscCode,
                        beneficiaryName = item.BeneficiaryName,
                        topUpStatus = item.topUpApprovedStatus,
                        reviseEstimateFiles = estimateFiles,
                    };
                    topUpList.Add(topUpModel);
                }

                var advanceDetails = new { advanceBasicDetails = advanceBasicDetails, hospitalAccoundetail = hospitalAccoundetail, topUpDetails = topUpList, documentLists = documentLists };
                responeModel.Data = advanceDetails;
                responeModel.DataLength = 0;
                responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                responeModel.Error = false;
                responeModel.Message = "Advance details get successfuly";
            }
            else
            {
                responeModel.Data = null;
                responeModel.DataLength = 0;
                responeModel.StatusCode = System.Net.HttpStatusCode.NotFound;
                responeModel.Error = false;
                responeModel.Message = "record not found.";
            }
            return responeModel;
        }

        public async Task<ResponeModel> GetDirectClaimDetails(long advanceId, string url)
        {
            ResponeModel responeModel = new ResponeModel();
            var query = from empAdv in _dbContext.EmpAdvances
                        join f in _dbContext.EmpFamilys on empAdv.PatientId equals f.Id
                        join r in _dbContext.EmpRelations on f.RelationId equals r.Id
                        join ecs in _dbContext.EmpClaimStatus on empAdv.ClaimId equals ecs.ClaimId
                        join csc in _dbContext.ClaimStatusCategory on ecs.StatusId equals csc.Id
                        join e in _dbContext.Employees on ecs.CreatedBy equals e.Id
                        join ec in _dbContext.EmployeeClaims on empAdv.ClaimId equals ec.Id
                        join empClaimBill in _dbContext.EmployeeClaimBills on empAdv.ClaimId equals empClaimBill.EmpClaimId
                        where empAdv.Id == advanceId && (ecs.ClaimTypeId == 3 || ecs.ClaimTypeId == 2)
                        select new
                        {
                            empAdv.Id,
                            empAdv.ClaimId,
                            patientId = empAdv.PatientId,
                            ClaimStatus = csc.Name,
                            f.EmpId,
                            empAdv.PatientId,
                            PatientName = f.Name,
                            Relation = r.Name,
                            DateOfBirth = f.DateOfBirth.ToString("MM/dd/yyyy"),
                            f.Gender,
                            HospitalName = empAdv.HospitalName,
                            HospitalRegNo = empAdv.HospitalRegNo,
                            DateOfAdmission = empAdv.DateOfAdmission.ToString("MM/dd/yyyy"),
                            DateofDischarge = Convert.ToDateTime(empAdv.DateofDischarge).ToString("MM/dd/yyyy"),
                            DoctorName = empAdv.DoctorName,
                            FinalHospitalBill = empAdv.FinalHospitalBill,
                            empAdv.PayTo,
                            CreatedBy = e.Name,
                            RequestedDate = ecs.CreatedDate.ToString("MM/dd/yyyy"),
                            ClaimApprovedDate = empAdv.ApprovalDate != null ? empAdv.ApprovalDate.Value.ToString("MM/dd/yyyy hh:mm tt") : "NA",
                            ClaimApprovedAmount = empAdv.ApprovedAmount ?? 0,
                            MedicineBill = empClaimBill.MedicineBill,
                            ConsultationBill = empClaimBill.ConsultationBill,
                            InvestigationBill = empClaimBill.InvestigationBill,
                            RoomRentBill = empClaimBill.RoomRentBill,
                            OthersBill = empClaimBill.OthersBill
                        };

            List<object> documentLists = new List<object>();
            List<object> topUpList = new List<object>();



            if (query != null && query.Count() != 0)
            {
                var documentsType = _dbContext.UploadTypeDetails.Where(f => f.ClaimId == query.FirstOrDefault().ClaimId && f.ClaimTypeId == ((long)RecordMasterClaimTypes.DirectClaim)).Select(d => new { d.Id, d.UploadTypeId }).ToList();

                if (documentsType != null)
                {
                    for (int i = 0; i < documentsType.Count; i++)
                    {
                        var uploadDocuments = _dbContext.UploadDocuments.Where(f => f.AdvanceUploadTypeId == documentsType[i].Id).ToList();
                        if (uploadDocuments != null && uploadDocuments.Count != 0)
                        {
                            var uploadType = _dbContext.UplodDocType.Where(f => f.Id == documentsType[i].UploadTypeId).FirstOrDefault();
                            foreach (var itemuploadDocument in uploadDocuments)
                            {
                                var document = new { category = uploadType?.Name, remark = itemuploadDocument.Comment, pathUrl = url + itemuploadDocument.PathUrl };
                                documentLists.Add(document);
                            }

                        }

                    }


                }

                var advance = query.FirstOrDefault();
                var advanceBasicDetails = new
                {
                    patientName = advance.PatientName,
                    patientId = advance.patientId,
                    relation = advance.Relation,
                    dateOfBirth = advance.DateOfBirth,
                    gender = advance.Gender,
                    hospitalName = advance.HospitalName,
                    hospitalRegNo = advance.HospitalRegNo,
                    dateOfAdmission = advance.DateOfAdmission,
                    dateofDischarge = advance.DateofDischarge,
                    doctorName = advance.DoctorName,
                    finalHospitalBill = advance.FinalHospitalBill,
                    claimStatus = advance.ClaimStatus,
                    requestedDate = advance.RequestedDate,
                    claimApprovedDate = advance.ClaimApprovedDate == null ? "NA" : advance.ClaimApprovedDate,
                    ClaimApprovedAmount = advance.ClaimApprovedAmount == null ? 0 : advance.ClaimApprovedAmount
                };
                var billDetails = new
                {
                    MedicineBill = advance.MedicineBill,
                    ConsultationBill = advance.ConsultationBill,
                    InvestigationBill = advance.InvestigationBill,
                    RoomRentBill = advance.RoomRentBill,
                    OthersBill = advance.OthersBill
                };
                HospitalAccoundetail hospitalAccoundetail = new HospitalAccoundetail();
                if (advance.PayTo == "Hospital")
                {
                    var hospitalDetailsDto = _dbContext.HospitalAccountDetails.Where(f => f.EmpAdvanceId == advanceId).FirstOrDefault();
                    if (hospitalDetailsDto != null)
                    {

                        hospitalAccoundetail.BeneficiaryName = hospitalDetailsDto.BeneficiaryName;
                        hospitalAccoundetail.AccountNumber = hospitalDetailsDto.AccountNumber;
                        hospitalAccoundetail.BankName = hospitalDetailsDto.BankName;
                        hospitalAccoundetail.UTRNo = "";

                    }
                }
                else
                {

                }


                var queryGetTopList = (from topUp in _dbContext.EmpAdvanceTopUp
                                       join empAdv in _dbContext.EmpAdvances on topUp.EmpAdvanceId equals empAdv.Id
                                       join ecs in _dbContext.EmpClaimStatus on topUp.Id equals ecs.EmpAdvanceTopId
                                       join claimStatus in _dbContext.ClaimStatusCategory on ecs.StatusId equals claimStatus.Id
                                       where empAdv.Id == advanceId
                                       select new
                                       {
                                           topUpId = topUp.Id,
                                           topUpApprovedStatus = claimStatus.Name,
                                           empAdv.ClaimId,
                                           topUp.ReviseEstimentedAmount,
                                           topUp.TopRequiredAmount,
                                           ApprovedAmount = topUp.TopApprovedAmount ?? 0,
                                           ApprovedDate = topUp.ApprovedDate != null ? topUp.ApprovedDate.ToString() : "NA",
                                           topUp.PayTo,
                                           topUp.BankName,
                                           topUp.AccountNumber,
                                           topUp.IfscCode,
                                           topUp.BeneficiaryName
                                       }).ToList();

                foreach (var item in queryGetTopList)
                {
                    List<object> estimateFiles = null;
                    var uploadTypeDetails = _dbContext.UploadTypeDetails.Where(f => f.ClaimId == item.ClaimId && f.ClaimTypeId == ((long)RecordMasterClaimTypes.TopUpAmount)).Select(d => d.Id).ToList();
                    if (uploadTypeDetails != null)
                    {
                        for (int i = 0; i < uploadTypeDetails.Count; i++)
                        {
                            estimateFiles = new List<object>();
                            var uploadDocuments = _dbContext.UploadDocuments.Where(f => f.AdvanceUploadTypeId == uploadTypeDetails[i]).ToList();
                            if (uploadDocuments != null && uploadDocuments.Count != 0)
                            {
                                foreach (var itemuploadDocument in uploadDocuments)
                                {
                                    var _estimetFileMode = new { filePath = url + itemuploadDocument.PathUrl, comment = itemuploadDocument.Comment };
                                    estimateFiles.Add(_estimetFileMode);

                                }

                            }

                        }


                    }
                    var topUpModel = new
                    {
                        reviseEstimentedAmount = item.ReviseEstimentedAmount,
                        topRequiredAmount = item.TopRequiredAmount,
                        approvedAmount = item.ApprovedAmount,
                        approvedDate = item.ApprovedDate,
                        payTo = item.PayTo,
                        bankName = item.BankName,
                        accountNumber = item.AccountNumber,
                        ifscCode = item.IfscCode,
                        beneficiaryName = item.BeneficiaryName,
                        topUpStatus = item.topUpApprovedStatus,
                        reviseEstimateFiles = estimateFiles,
                    };
                    topUpList.Add(topUpModel);
                }


                var advanceDetails = new { advanceBasicDetails = advanceBasicDetails, hospitalAccoundetail = hospitalAccoundetail, billDetails, topUpDetails = topUpList, documentLists = documentLists };
                responeModel.Data = advanceDetails;
                responeModel.DataLength = 0;
                responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                responeModel.Error = false;
                responeModel.Message = "Claim details get successfuly.";
            }
            else
            {
                responeModel.Data = null;
                responeModel.DataLength = 0;
                responeModel.StatusCode = System.Net.HttpStatusCode.NotFound;
                responeModel.Error = false;
                responeModel.Message = "record not found.";
            }



            return responeModel;

        }
        #region Get Claim lsit for doctor review 

        public async Task<ResponeModel> GetClaimForDoctorUnderProcess(long recipientId)
        {
            ResponeModel responeModel = new ResponeModel();
            var targetStatusIds = new List<long> { ((int)RecordMasterClaimStatusCategory.UnderDoctorProcessing) };

            var query = from ecpd in _dbContext.EmpClaimProcessDetails
                        join empadv in _dbContext.EmpAdvances on ecpd.ClaimId equals empadv.ClaimId
                        join ef in _dbContext.EmpFamilys on empadv.PatientId equals ef.Id
                        join emp in _dbContext.Employees on empadv.EmplId equals emp.Id
                        join empRel in _dbContext.EmpRelations on ef.RelationId equals empRel.Id
                        join ec in _dbContext.EmployeeClaims on empadv.ClaimId equals ec.Id
                        join claimType in _dbContext.ClaimTypes on ecpd.ClaimTypeId equals claimType.Id
                        join topUp in _dbContext.EmpAdvanceTopUp on empadv.Id equals topUp.EmpAdvanceId into topUpGroup
                        from topUp in topUpGroup.DefaultIfEmpty()
                        where ecpd.RecipientId == (from e in _dbContext.EmpClaimProcessDetails
                                                   where e.ClaimId == empadv.ClaimId
                                                   orderby e.Id descending
                                                   select e.RecipientId).FirstOrDefault()
                           && ecpd.ClaimTypeId == (from e in _dbContext.EmpClaimProcessDetails
                                                   where e.ClaimId == empadv.ClaimId
                                                   orderby e.Id descending
                                                   select e.ClaimTypeId).FirstOrDefault()
                        select new
                        {
                            empAdvId = empadv.Id,
                            EmpAdvanceObject = empadv,
                            EmployeeObject = emp,
                            EmployeeName = emp.Name,
                            patientId = empadv.PatientId,
                            patientName = ef.Name,
                            relation = empRel.Name,
                            claimType = claimType.Name,
                            claimId = ecpd.ClaimId,
                            SenderId = (from e in _dbContext.EmpClaimProcessDetails
                                        where e.ClaimId == ecpd.ClaimId
                                        orderby e.Id descending
                                        select e.SenderId).FirstOrDefault(),
                            RecipientId = ecpd.RecipientId,
                            ClaimTypeId = (from e in _dbContext.EmpClaimProcessDetails
                                           where e.ClaimId == ecpd.ClaimId
                                           orderby e.Id descending
                                           select e.ClaimTypeId).FirstOrDefault(),
                            Status = (from cs in _dbContext.ClaimStatusCategory
                                      where cs.Id == (from e in _dbContext.EmpClaimStatus
                                                      where e.ClaimId == ecpd.ClaimId
                                                      orderby e.Id descending
                                                      select e.StatusId).FirstOrDefault()
                                      select cs.Name).FirstOrDefault(),
                            StatusId = (from e in _dbContext.EmpClaimStatus
                                        where e.ClaimId == ecpd.ClaimId
                                        orderby e.Id descending
                                        select e.StatusId).FirstOrDefault(),
                            AdvanceAmount = ecpd.ClaimTypeId == 1 ? empadv.AdvanceAmount
                                            : ecpd.ClaimTypeId == 4 ? topUp.TopRequiredAmount
                                            : ecpd.ClaimTypeId == 2 || ecpd.ClaimTypeId == 3 ? ec.ClaimAmount : 0,
                            AdvanceRequestDate = ecpd.ClaimTypeId == 1 ? empadv.AdvanceRequestDate
                                                 : ecpd.ClaimTypeId == 4 ? topUp.CreatedDate
                                                 : ecpd.ClaimTypeId == 2 || ecpd.ClaimTypeId == 3 ? ec.ClaimRequetsDate : null,
                            ApprovedAmount = ecpd.ClaimTypeId == 1 ? empadv.ApprovedAmount
                                            : ecpd.ClaimTypeId == 4 ? topUp.TopApprovedAmount
                                            : 0,
                            ApprovalDate = ecpd.ClaimTypeId == 1 ? empadv.ApprovalDate
                                          : ecpd.ClaimTypeId == 4 ? topUp.ApprovedDate
                                          : null
                        };

            var claimAdvanceData = query.ToList().Where(f => f.RecipientId == recipientId && (f.StatusId == ((long)RecordMasterClaimStatusCategory.UnderDoctorProcessing)));



            
            List<object> empAdvanceData = new();
            if (claimAdvanceData != null && claimAdvanceData.Count() != 0)
            {

                foreach (var item in claimAdvanceData)
                {
                    var dataEmpAdvance = new
                    {
                        DirectClaimId = item.EmpAdvanceObject.Id,
                        EmpId = item.EmployeeObject.Id,
                        EmployeeName = item.EmployeeName,
                        PatientName = item.patientName,
                        patientId = item.EmpAdvanceObject.PatientId,
                        Relation = item.relation,
                        AdvanceAmount = item.AdvanceAmount,
                        RequestDate = Convert.ToDateTime(item.AdvanceRequestDate).ToString("MM/dd/yyyy"),
                        ApprovedAmount = item.ApprovedAmount,
                        ApprovedDate = item.ApprovalDate
                    };
                    empAdvanceData.Add(dataEmpAdvance);
                }
            }


            if (empAdvanceData != null)
            {
                responeModel.Data = empAdvanceData;
                responeModel.DataLength = empAdvanceData.Count();
                responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                responeModel.Error = false;
                responeModel.Message = empAdvanceData.Count() + " Claim found.";
                return responeModel;
            }
            return responeModel;
        }

        #endregion

        #region Update Status Claim Process
        public async Task<ResponeModel> UpdateInactiveEmpClaimProcessDetail(long id)
        {
            ResponeModel responeModel = new ResponeModel();
            if (id != 0)
            {
                var updateInactiveEmpClaims = _dbContext.EmpClaimProcessDetails.Where(e => e.Id == id && e.IsActive == true).FirstOrDefault();
                if (updateInactiveEmpClaims != null)
                {
                    updateInactiveEmpClaims.Id = id;
                    updateInactiveEmpClaims.IsActive = false;
                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = updateInactiveEmpClaims;
                    responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                    responeModel.Error = false;
                    responeModel.Message = CommonMessage.UpdateMessage;

                }
            }
            return responeModel;
        }

        #endregion
        #region Employee Advance Top Up
        public async Task<ResponeModel> EmpAdvanceTopUp(EmpAdvanceTopUpModel empAdvanceTopUp)
        {
            ResponeModel responeModel = new ResponeModel();

            var empAdvance = _dbContext.EmpAdvances.Where(e => e.Id == empAdvanceTopUp.AdvanceId).FirstOrDefault();
            if (empAdvance != null)
            {
                var claimStatus = _dbContext.EmpClaimStatus.Where(c => c.ClaimId == empAdvance.ClaimId && c.ClaimTypeId == ((long)RecordMasterClaimTypes.Advance)).OrderByDescending(d => d.Id).FirstOrDefault();
                if (claimStatus != null && claimStatus.StatusId == ((long)RecordMasterClaimStatusCategory.Approved))
                {
                    var claimStatusTopUp = _dbContext.EmpClaimStatus.Where(c => c.ClaimId == empAdvance.ClaimId && c.ClaimTypeId == ((long)RecordMasterClaimTypes.TopUpAmount)).OrderByDescending(d => d.Id).FirstOrDefault();
                    if (claimStatusTopUp == null || claimStatusTopUp.StatusId == ((long)RecordMasterClaimStatusCategory.Approved))
                    {
                        var UploadDocuments = await UploadBillFiles(empAdvanceTopUp.ReviseEstimateFile.Files, "ReviseEstimateFile");
                        if (UploadDocuments != null && UploadDocuments.Count != 0)
                        {


                            UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                            {
                                ClaimId = empAdvance.ClaimId,
                                ClaimTypeId = ((long)RecordMasterClaimTypes.TopUpAmount),
                                UploadTypeId = ((long)RecordMasterUplodDocType.ReviseEstimateFile),
                                Amount = empAdvanceTopUp.TopRequiredAmount,
                                CreatedBy = empAdvanceTopUp.EmpId,
                                CreatedDate = DateTime.Now
                            };

                            _dbContext.Add(uploadTypeDetail);
                            await _dbContext.SaveChangesAsync();

                            UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = empAdvanceTopUp.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                            await _dbContext.AddRangeAsync(UploadDocuments);
                            await _dbContext.SaveChangesAsync();

                            EmpAdvanceTopUp empAdvanceTop = new EmpAdvanceTopUp()
                            {
                                EmpAdvanceId = empAdvanceTopUp.AdvanceId,
                                ReviseEstimentedAmount = empAdvanceTopUp.ReviseEstimentedAmount,
                                TopRequiredAmount = empAdvanceTopUp.TopRequiredAmount,
                                PayTo = empAdvanceTopUp.PayTo,
                                CreatedBy = empAdvanceTopUp.EmpId,
                                CreatedDate = DateTime.Now
                            };

                            if (empAdvanceTopUp.PayTo == "Hospital" || empAdvanceTopUp.PayTo == "hospital")
                            {
                                empAdvanceTop.BankName = empAdvanceTopUp.BankName;
                                empAdvanceTop.AccountNumber = empAdvanceTopUp.AccountNumber;
                                empAdvanceTop.IfscCode = empAdvanceTopUp.IfscCode;
                                empAdvanceTop.BeneficiaryName = empAdvanceTopUp.BeneficiaryName;
                            }

                            _dbContext.Add(empAdvanceTop);
                            await _dbContext.SaveChangesAsync();

                            EmpClaimStatus empClaimStatus = new EmpClaimStatus()
                            {
                                ClaimId = empAdvance.ClaimId,
                                ClaimTypeId = ((long)RecordMasterClaimTypes.TopUpAmount),
                                StatusId = ((long)RecordMasterClaimStatusCategory.TopUpInitiated),
                                CreatedBy = empAdvanceTopUp.EmpId,
                                EmpAdvanceTopId = empAdvanceTop.Id,
                                CreatedDate = DateTime.Now
                            };
                            _dbContext.Add(empClaimStatus);
                            await _dbContext.SaveChangesAsync();

                            // Create record in EmpClaimProcessDetails table.

                            EmpClaimProcessDetails empClaimProcessDetails = new EmpClaimProcessDetails()
                            {
                                ClaimId = empAdvance.ClaimId,
                                ClaimTypeId = ((long)RecordMasterClaimTypes.TopUpAmount),
                                SenderId = empAdvanceTopUp.EmpId,
                                RecipientId = ((long)RecordMasterIds.HR_OneID),
                                CreatedBy = empAdvanceTopUp.EmpId,
                                CreatedDate = DateTime.Now,
                                IsActive = true,

                            };

                            await _dbContext.AddAsync(empClaimProcessDetails);
                            await _dbContext.SaveChangesAsync();

                            responeModel.Data = null;
                            responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                            responeModel.Error = false;
                            responeModel.Message = CommonMessage.CreateMessage;
                        }
                    }
                    else
                    {
                        responeModel.Data = null;
                        responeModel.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        responeModel.Error = false;
                        responeModel.Message = "Previous top up is not approved yet once it approved then you can get new top up.";

                    }
                }
                else
                {
                    responeModel.Data = null;
                    responeModel.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    responeModel.Error = false;
                    responeModel.Message = "TopUp is not created because this claim is not approved yet.";

                }

            }
            else
            {
                responeModel.Data = null;
                responeModel.StatusCode = System.Net.HttpStatusCode.NotFound;
                responeModel.Error = false;
                responeModel.Message = "Advance id is not valid.";

            }
            return responeModel;
        }

        public async Task<ResponeModel> AdvanceClaim(AdvanceClaimDetailsModel advanceClaimDetails)
        {
            ResponeModel responeModel = new ResponeModel();
            if (advanceClaimDetails != null)
            {
                var empAdvanceDetail = _dbContext.EmpAdvances.Where(e => e.Id == advanceClaimDetails.AdvanceId).FirstOrDefault();
                if (empAdvanceDetail != null)
                {

                    EmpClaimStatus empClaimStatus = new EmpClaimStatus()
                    {
                        ClaimId = empAdvanceDetail.ClaimId,
                        ClaimTypeId = ((long)RecordMasterClaimTypes.AdvanceClaim),
                        StatusId = ((long)RecordMasterClaimStatusCategory.ClaimInitiated),
                        CreatedBy = advanceClaimDetails.EmpId,
                        CreatedDate = DateTime.Now
                    };
                    _dbContext.Add(empClaimStatus);
                    await _dbContext.SaveChangesAsync();

                    EmpClaimBill empClaimBill = new EmpClaimBill()
                    {
                        EmpClaimId = empAdvanceDetail.ClaimId,
                        EmpId = advanceClaimDetails.EmpId,
                        StatusId = ((long)RecordMasterClaimStatusCategory.ClaimInitiated), // Claim Insited(Pending),
                        HospitalCompleteBill = advanceClaimDetails.FinalHospitalBill,
                        MedicineBill = advanceClaimDetails.MedicenBill.Amount,
                        ConsultationBill = advanceClaimDetails.Consultation.Amount,
                        InvestigationBill = advanceClaimDetails.Investigation.Amount,
                        RoomRentBill = advanceClaimDetails.RoomRent.Amount,
                        OthersBill = advanceClaimDetails.OtherBill.Amount,
                        CreatedBy = advanceClaimDetails.EmpId,
                        CreatedDate = DateTime.Now
                    };

                    _dbContext.Add(empClaimBill);
                    await _dbContext.SaveChangesAsync();


                    if (advanceClaimDetails.DischargeSummaryUpload != null)
                    {
                        var UploadDocuments = await UploadBillFiles(advanceClaimDetails.DischargeSummaryUpload, "DischargeSummary");
                        if (UploadDocuments != null && UploadDocuments.Count != 0)
                        {
                            UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                            {
                                ClaimId = empAdvanceDetail.ClaimId,
                                ClaimTypeId = ((long)RecordMasterClaimTypes.AdvanceClaim),
                                UploadTypeId = ((long)RecordMasterUplodDocType.DischargeSummary),
                                Amount = 101,
                                CreatedBy = advanceClaimDetails.EmpId,
                                CreatedDate = DateTime.Now
                            };

                            _dbContext.Add(uploadTypeDetail);
                            await _dbContext.SaveChangesAsync();

                            UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = advanceClaimDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                            await _dbContext.AddRangeAsync(UploadDocuments);
                            await _dbContext.SaveChangesAsync();
                        }

                    }
                    if (advanceClaimDetails.InvestigationReportsUpload != null)
                    {
                        var UploadDocuments = await UploadBillFiles(advanceClaimDetails.InvestigationReportsUpload, "Investigation");
                        if (UploadDocuments != null && UploadDocuments.Count != 0)
                        {
                            UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                            {
                                ClaimId = empAdvanceDetail.ClaimId,
                                ClaimTypeId = ((long)RecordMasterClaimTypes.AdvanceClaim),
                                UploadTypeId = ((long)RecordMasterUplodDocType.Investigation),
                                Amount = 101,
                                CreatedBy = advanceClaimDetails.EmpId,
                                CreatedDate = DateTime.Now
                            };

                            _dbContext.Add(uploadTypeDetail);
                            await _dbContext.SaveChangesAsync();

                            UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = advanceClaimDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                            await _dbContext.AddRangeAsync(UploadDocuments);
                            await _dbContext.SaveChangesAsync();
                        }

                    }
                    if (advanceClaimDetails.FinalHospitalBillUpload != null)
                    {
                        var UploadDocuments = await UploadBillFiles(advanceClaimDetails.FinalHospitalBillUpload, "FinalHospitalBillUpload");
                        if (UploadDocuments != null && UploadDocuments.Count != 0)
                        {
                            UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                            {
                                ClaimId = empAdvanceDetail.ClaimId,
                                ClaimTypeId = ((long)RecordMasterClaimTypes.AdvanceClaim),
                                UploadTypeId = ((long)RecordMasterUplodDocType.FinalHospitalBill),
                                Amount = advanceClaimDetails.FinalHospitalBill,
                                CreatedBy = advanceClaimDetails.EmpId,
                                CreatedDate = DateTime.Now
                            };

                            _dbContext.Add(uploadTypeDetail);
                            await _dbContext.SaveChangesAsync();

                            UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = advanceClaimDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                            await _dbContext.AddRangeAsync(UploadDocuments);
                            await _dbContext.SaveChangesAsync();
                        }
                    }

                    // if bill is not in final bill then add to EmpClaimNotInMailBill table

                    if (advanceClaimDetails.MedicenNotFinalBill != null)
                    {
                        var UploadDocuments = await UploadBillFiles(advanceClaimDetails.MedicenNotFinalBill.Files, "MedicenNotFinalBill");
                        if (UploadDocuments != null && UploadDocuments.Count != 0)
                        {
                            UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                            {
                                ClaimId = empAdvanceDetail.ClaimId,
                                ClaimTypeId = ((long)RecordMasterClaimTypes.AdvanceClaim),
                                UploadTypeId = ((long)RecordMasterUplodDocType.MedicinenotinFinalBill),
                                Amount = Convert.ToDouble(advanceClaimDetails.MedicenNotFinalBill.Amount),
                                CreatedBy = advanceClaimDetails.EmpId,
                                CreatedDate = DateTime.Now
                            };
                            _dbContext.Add(uploadTypeDetail);
                            await _dbContext.SaveChangesAsync();


                            UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = advanceClaimDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                            await _dbContext.AddRangeAsync(UploadDocuments);
                            await _dbContext.SaveChangesAsync();


                            EmpClaimNotInMailBill empClaimNotInMailBill = new EmpClaimNotInMailBill()
                            {
                                Amount = Convert.ToDouble(advanceClaimDetails.MedicenNotFinalBill.Amount),
                                BillType = "Medicen Not In Final Bill",
                                EmpClaimBillId = empClaimBill.Id,
                                IsActive = true,
                                CreatedBy = empClaimBill.EmpId,
                                CreatedDate = DateTime.Now
                            };

                            _dbContext.Add(empClaimNotInMailBill);
                            await _dbContext.SaveChangesAsync();
                        }
                    }
                    if (advanceClaimDetails.ConsultationNotFinalBill != null)
                    {
                        var UploadDocuments = await UploadBillFiles(advanceClaimDetails.ConsultationNotFinalBill.Files, "ConsultationNotFinalBill");
                        if (UploadDocuments != null && UploadDocuments.Count != 0)
                        {
                            UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                            {
                                ClaimId = empAdvanceDetail.ClaimId,
                                ClaimTypeId = ((long)RecordMasterClaimTypes.AdvanceClaim),
                                UploadTypeId = ((long)RecordMasterUplodDocType.ConsultationNotFinalBill),
                                Amount = Convert.ToDouble(advanceClaimDetails.ConsultationNotFinalBill.Amount),
                                CreatedBy = advanceClaimDetails.EmpId,
                                CreatedDate = DateTime.Now
                            };

                            _dbContext.Add(uploadTypeDetail);
                            await _dbContext.SaveChangesAsync();

                            UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = advanceClaimDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                            await _dbContext.AddRangeAsync(UploadDocuments);
                            await _dbContext.SaveChangesAsync();


                            EmpClaimNotInMailBill empClaimNotInMailBill = new EmpClaimNotInMailBill()
                            {
                                Amount = Convert.ToDouble(advanceClaimDetails.ConsultationNotFinalBill.Amount),
                                BillType = "Consultation Not In Final Bill",
                                EmpClaimBillId = empClaimBill.Id,
                                IsActive = true,
                                CreatedBy = empClaimBill.EmpId,
                                CreatedDate = DateTime.Now
                            };

                            _dbContext.Add(empClaimNotInMailBill);
                            await _dbContext.SaveChangesAsync();
                        }
                    }
                    if (advanceClaimDetails.InvestigationNotFinalBill != null)
                    {
                        var UploadDocuments = await UploadBillFiles(advanceClaimDetails.InvestigationNotFinalBill.Files, "InvestigationNotFinalBill");
                        if (UploadDocuments != null && UploadDocuments.Count != 0)
                        {
                            UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                            {
                                ClaimId = empAdvanceDetail.ClaimId,
                                ClaimTypeId = ((long)RecordMasterClaimTypes.AdvanceClaim),
                                UploadTypeId = ((long)RecordMasterUplodDocType.InvestigationNotFinalBill),
                                Amount = Convert.ToDouble(advanceClaimDetails.InvestigationNotFinalBill.Amount),
                                CreatedBy = advanceClaimDetails.EmpId,
                                CreatedDate = DateTime.Now
                            };

                            _dbContext.Add(uploadTypeDetail);
                            await _dbContext.SaveChangesAsync();

                            UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = advanceClaimDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                            await _dbContext.AddRangeAsync(UploadDocuments);
                            await _dbContext.SaveChangesAsync();


                            EmpClaimNotInMailBill empClaimNotInMailBill = new EmpClaimNotInMailBill()
                            {
                                Amount = Convert.ToDouble(advanceClaimDetails.InvestigationNotFinalBill.Amount),
                                BillType = "Investigation Not In FinalBill",
                                EmpClaimBillId = empClaimBill.Id,
                                IsActive = true,
                                CreatedBy = empClaimBill.EmpId,
                                CreatedDate = DateTime.Now
                            };

                            _dbContext.Add(empClaimNotInMailBill);
                            await _dbContext.SaveChangesAsync();
                        }
                    }
                    if (advanceClaimDetails.OtherBillNotFinalBill != null)
                    {
                        var UploadDocuments = await UploadBillFiles(advanceClaimDetails.OtherBillNotFinalBill.Files, "OtherBillNotFinalBill");
                        if (UploadDocuments != null && UploadDocuments.Count != 0)
                        {
                            UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                            {
                                ClaimId = empAdvanceDetail.ClaimId,
                                ClaimTypeId = ((long)RecordMasterClaimTypes.AdvanceClaim),
                                UploadTypeId = ((long)RecordMasterUplodDocType.OtherBillNotFinalBill),
                                Amount = Convert.ToDouble(advanceClaimDetails.OtherBillNotFinalBill.Amount),
                                CreatedBy = advanceClaimDetails.EmpId,
                                CreatedDate = DateTime.Now
                            };

                            _dbContext.Add(uploadTypeDetail);
                            await _dbContext.SaveChangesAsync();

                            UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = advanceClaimDetails.EmpId; s.CreatedDate = DateTime.Now; s.Comment = ""; s.IsActive = true; return s; }).ToList();

                            await _dbContext.AddRangeAsync(UploadDocuments);
                            await _dbContext.SaveChangesAsync();

                            EmpClaimNotInMailBill empClaimNotInMailBill = new EmpClaimNotInMailBill()
                            {
                                Amount = Convert.ToDouble(advanceClaimDetails.OtherBillNotFinalBill.Amount),
                                BillType = "Other Bill Not In FinalBill",
                                EmpClaimBillId = empClaimBill.Id,
                                IsActive = true,
                                CreatedBy = empClaimBill.EmpId,
                                CreatedDate = DateTime.Now
                            };

                            _dbContext.Add(empClaimNotInMailBill);
                            await _dbContext.SaveChangesAsync();
                        }
                    }

                    // Pre Hospitalization Expenses Save if IsPreHospitalizationExpenses is True
                    if (advanceClaimDetails.IsPreHospitalizationExpenses)
                    {
                        if (advanceClaimDetails.PreHospitalizationExpensesMedicine != null)
                        {
                            var UploadDocuments = await UploadBillFiles(advanceClaimDetails.PreHospitalizationExpensesMedicine.Files, "PreHospitalizationExpensesMedicine");
                            if (UploadDocuments != null && UploadDocuments.Count != 0)
                            {
                                UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                                {
                                    ClaimId = empAdvanceDetail.ClaimId,
                                    ClaimTypeId = ((long)RecordMasterClaimTypes.AdvanceClaim),
                                    UploadTypeId = ((long)RecordMasterUplodDocType.PreHospitalizationExpensesMedicine),
                                    Amount = Convert.ToDouble(advanceClaimDetails.PreHospitalizationExpensesMedicine.Amount),
                                    CreatedBy = advanceClaimDetails.EmpId,
                                    CreatedDate = DateTime.Now,
                                    IsActive = true,
                                };

                                _dbContext.Add(uploadTypeDetail);
                                await _dbContext.SaveChangesAsync();

                                UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = advanceClaimDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                                await _dbContext.AddRangeAsync(UploadDocuments);
                                await _dbContext.SaveChangesAsync();
                            }
                        }
                        if (advanceClaimDetails.PreHospitalizationExpensesConsultation != null)
                        {
                            var UploadDocuments = await UploadBillFiles(advanceClaimDetails.PreHospitalizationExpensesConsultation.Files, "PreHospitalizationExpensesConsultation");
                            if (UploadDocuments != null && UploadDocuments.Count != 0)
                            {
                                UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                                {
                                    ClaimId = empAdvanceDetail.ClaimId,
                                    ClaimTypeId = ((long)RecordMasterClaimTypes.AdvanceClaim),
                                    UploadTypeId = ((long)RecordMasterUplodDocType.PreHospitalizationExpensesConsultation),
                                    Amount = Convert.ToDouble(advanceClaimDetails.PreHospitalizationExpensesConsultation.Amount),
                                    CreatedBy = advanceClaimDetails.EmpId,
                                    CreatedDate = DateTime.Now,
                                    IsActive = true,
                                };

                                _dbContext.Add(uploadTypeDetail);
                                await _dbContext.SaveChangesAsync();

                                UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = advanceClaimDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                                await _dbContext.AddRangeAsync(UploadDocuments);
                                await _dbContext.SaveChangesAsync();
                            }
                        }
                        if (advanceClaimDetails.PreHospitalizationExpensesInvestigation != null)
                        {
                            var UploadDocuments = await UploadBillFiles(advanceClaimDetails.PreHospitalizationExpensesInvestigation.Files, "PreHospitalizationExpensesInvestigation");
                            if (UploadDocuments != null && UploadDocuments.Count != 0)
                            {
                                UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                                {
                                    ClaimId = empAdvanceDetail.ClaimId,
                                    ClaimTypeId = ((long)RecordMasterClaimTypes.AdvanceClaim),
                                    UploadTypeId = ((long)RecordMasterUplodDocType.PreHospitalizationExpensesInvestigation),
                                    Amount = Convert.ToDouble(advanceClaimDetails.PreHospitalizationExpensesInvestigation.Amount),
                                    CreatedBy = advanceClaimDetails.EmpId,
                                    CreatedDate = DateTime.Now,
                                    IsActive = true,
                                };

                                _dbContext.Add(uploadTypeDetail);
                                await _dbContext.SaveChangesAsync();

                                UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = advanceClaimDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                                await _dbContext.AddRangeAsync(UploadDocuments);
                                await _dbContext.SaveChangesAsync();
                            }
                        }
                        if (advanceClaimDetails.PreHospitalizationExpensesOther != null)
                        {
                            var UploadDocuments = await UploadBillFiles(advanceClaimDetails.PreHospitalizationExpensesOther.Files, "PreHospitalizationExpensesOther");
                            if (UploadDocuments != null && UploadDocuments.Count != 0)
                            {
                                UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                                {
                                    ClaimId = empAdvanceDetail.ClaimId,
                                    ClaimTypeId = ((long)RecordMasterClaimTypes.AdvanceClaim),
                                    UploadTypeId = ((long)RecordMasterUplodDocType.PreHospitalizationExpensesOther),
                                    Amount = Convert.ToDouble(advanceClaimDetails.PreHospitalizationExpensesOther.Amount),
                                    CreatedBy = advanceClaimDetails.EmpId,
                                    CreatedDate = DateTime.Now,
                                    IsActive = true,
                                };

                                _dbContext.Add(uploadTypeDetail);
                                await _dbContext.SaveChangesAsync();

                                UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = advanceClaimDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                                await _dbContext.AddRangeAsync(UploadDocuments);
                                await _dbContext.SaveChangesAsync();
                            }

                        }

                    }


                    // If IsTaxable= false then save hospitl files file
                    if (!advanceClaimDetails.IsTaxable)
                    {
                        if (advanceClaimDetails.HospitalIncomeTaxFile != null)
                        {
                            var UploadDocuments = await UploadBillFiles(advanceClaimDetails.HospitalIncomeTaxFile.Files, "HospitalIncomeTaxFile");
                            if (UploadDocuments != null && UploadDocuments.Count != 0)
                            {
                                UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                                {
                                    ClaimId = empAdvanceDetail.ClaimId,
                                    ClaimTypeId = ((long)RecordMasterClaimTypes.AdvanceClaim),
                                    UploadTypeId = ((long)RecordMasterUplodDocType.HospitalIncomeTaxFile),
                                    Amount = 0,
                                    CreatedBy = advanceClaimDetails.EmpId,
                                    CreatedDate = DateTime.Now,
                                    IsActive = true,
                                };

                                _dbContext.Add(uploadTypeDetail);
                                await _dbContext.SaveChangesAsync();

                                UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = advanceClaimDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                                await _dbContext.AddRangeAsync(UploadDocuments);
                                await _dbContext.SaveChangesAsync();
                            }
                        }
                        if (advanceClaimDetails.HospitalRegstrationDetailsFile != null)
                        {
                            var UploadDocuments = await UploadBillFiles(advanceClaimDetails.HospitalRegstrationDetailsFile.Files, "HospitalRegstrationDetailsFile");
                            if (UploadDocuments != null && UploadDocuments.Count != 0)
                            {
                                UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                                {
                                    ClaimId = empAdvanceDetail.ClaimId,
                                    ClaimTypeId = ((long)RecordMasterClaimTypes.AdvanceClaim),
                                    UploadTypeId = ((long)RecordMasterUplodDocType.HospitalRegstrationDetailsFile),
                                    Amount = 0,
                                    CreatedBy = advanceClaimDetails.EmpId,
                                    CreatedDate = DateTime.Now,
                                    IsActive = true,
                                };

                                _dbContext.Add(uploadTypeDetail);
                                await _dbContext.SaveChangesAsync();

                                UploadDocuments = UploadDocuments.Where(e => e.AdvanceUploadTypeId == null || e.AdvanceUploadTypeId == 0).Select(s => { s.AdvanceUploadTypeId = uploadTypeDetail.Id; s.CreatedBy = advanceClaimDetails.EmpId; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                                await _dbContext.AddRangeAsync(UploadDocuments);
                                await _dbContext.SaveChangesAsync();
                            }
                        }

                    }

                    // Create record in EmpClaimProcessDetails table.

                    EmpClaimProcessDetails empClaimProcessDetails = new EmpClaimProcessDetails()
                    {
                        ClaimId = empAdvanceDetail.ClaimId,
                        ClaimTypeId = ((long)RecordMasterClaimTypes.AdvanceClaim),
                        SenderId = advanceClaimDetails.EmpId,
                        RecipientId = ((long)RecordMasterIds.HR_OneID),
                        CreatedBy = advanceClaimDetails.EmpId,
                        CreatedDate = DateTime.Now,
                        IsActive = true,

                    };

                    await _dbContext.AddAsync(empClaimProcessDetails);
                    await _dbContext.SaveChangesAsync();


                    var empClaim = _dbContext.EmployeeClaims.Where(f => f.Id == empAdvanceDetail.ClaimId).FirstOrDefault();
                    if (empClaim != null)
                    {
                        // Update record in EmployeClaims table.
                        empClaim.HospitalTotalBill = advanceClaimDetails.FinalHospitalBill;
                        empClaim.ClaimAmount = advanceClaimDetails.ClaimAmount;
                        empClaim.IsTaxable = advanceClaimDetails.IsTaxable;
                        empClaim.IsSpecailDisease = advanceClaimDetails.IsSpecailDisease;
                        _dbContext.Update(empClaim);
                        await _dbContext.SaveChangesAsync();

                    }
                    // Update record in EmpAdvance table.
                    empAdvanceDetail.FinalHospitalBill = advanceClaimDetails.FinalHospitalBill;
                    empAdvanceDetail.DateofDischarge = advanceClaimDetails.DateofDischarge;
                    empAdvanceDetail.IsPreHospitalizationExpenses = advanceClaimDetails.IsPreHospitalizationExpenses;
                    empAdvanceDetail.DateofDischarge = advanceClaimDetails.DateofDischarge;
                    empAdvanceDetail.Declaration = advanceClaimDetails.Declaration;
                    _dbContext.Update(empAdvanceDetail);
                    await _dbContext.SaveChangesAsync();


                    var responseData = new { emplId = empAdvanceDetail.EmplId, patientId = empAdvanceDetail.PatientId, empclaimId = empAdvanceDetail.ClaimId, advanceId = empAdvanceDetail.Id, requestSubmittedById = advanceClaimDetails.EmpId };

                    responeModel.Data = responseData;
                    responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                    responeModel.Error = false;
                    responeModel.Message = CommonMessage.CreateMessage;
                }
                else
                {
                    responeModel.Data = null;
                    responeModel.StatusCode = System.Net.HttpStatusCode.NotFound;
                    responeModel.Error = false;
                    responeModel.Message = "Advance id is not valid.";

                }
            }
            return responeModel;
        }

        #endregion
        #endregion

    }
    public class HospitalAccoundetail
    {
        public string BeneficiaryName { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string UTRNo { get; set; }
    }
}
