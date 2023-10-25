using HealthClaim.BAL.Repository.Interface;
using HealthClaim.DAL.Models;
using HealthClaim.DAL;
using HealthClaim.Model.Dtos.Employeefamily;
using HealthClaim.Model.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthClaim.Model.Dtos.EmpAccountDetail;
using HealthClaim.Utility.Resources;
using Microsoft.EntityFrameworkCore;

namespace HealthClaim.BAL.Repository.Concrete
{
    public class EmpAccountDetailRepository : GenricRepository<EmpAccountDetail>, IEmpAccountDetailRepository
    {
        private HealthClaimDbContext _dbContext;
        #region Constructor
        /// <summary>
        /// This is constructor to set dependency injection
        /// </summary>
        /// <param name="db"></param>
        public EmpAccountDetailRepository(HealthClaimDbContext db) : base(db)
        {
            _dbContext = db;
        }
        #endregion

        #region Create Employee Details
        /// <summary>
        /// This method is used for add new employee
        /// </summary>
        /// <param name="empAccountDetailModel"></param>
        /// <returns></returns>
        public async Task<ResponeModel> Create(EmpAccountDetailModel empAccountDetailModel)
        {
            ResponeModel responeModel = new ResponeModel();
            if (empAccountDetailModel != null)
            {
                EmpAccountDetail empAccountDetail = new EmpAccountDetail()
                {
                    EmpId = empAccountDetailModel.EmpId,
                    BankName = empAccountDetailModel.BankName,
                    AccountNumber = empAccountDetailModel.AccountNumber,
                    IfscCode = empAccountDetailModel.IfscCode,
                    IsActive = empAccountDetailModel.IsActive,
                    IsDefault = empAccountDetailModel.IsDefault,
                    CreatedBy = 3,
                    CreatedDate = DateTime.Now,
                    //UpdatedBy = employeeModel.UpdatedBy,
                    //UpdatedDate=DateTime.Now,
                };
                _dbContext.Add(empAccountDetail);
                int id = await _dbContext.SaveChangesAsync();
                responeModel.Data = empAccountDetail;
                responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                responeModel.Error = false;
                responeModel.Message = CommonMessage.CreateMessage;

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
                var empFamilyDetails = _dbContext.EmpAccountDetails.Where(e => e.Id == id).FirstOrDefault();

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

        #region Get Faimly details
        /// <summary>
        /// This method is used for fetch the employee details and list of faimly
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponeModel> GetEmpDetail(int? id)
        {
            ResponeModel responeModel = new ResponeModel();
            var empFaimly = await _dbContext.EmpAccountDetails.Where(e => id == 0 ? e.Id == e.Id : e.Id == id && e.IsActive == true).ToListAsync();
            responeModel.Data = empFaimly;
            responeModel.DataLength = empFaimly.Count;
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            responeModel.Message = empFaimly.Count + " Employee found.";

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
        public async Task<ResponeModel> Update(UpdateEmpAccountDetailModel empAccountDetailModel, int id)
        {
            ResponeModel responeModel = new ResponeModel();
            if (empAccountDetailModel != null && id != 0)
            {
                var empAccountDetail = _dbContext.EmpAccountDetails.Where(e => e.Id == id).FirstOrDefault();

                if (empAccountDetail != null)
                {
                    empAccountDetail.BankName = empAccountDetailModel.BankName;
                    empAccountDetail.AccountNumber = empAccountDetailModel.AccountNumber;
                    empAccountDetail.IfscCode = empAccountDetailModel.IfscCode;
                    empAccountDetail.IsDefault = empAccountDetailModel.IsDefault;
                    empAccountDetail.UpdatedDate = DateTime.Now;
                    empAccountDetail.UpdatedBy = 1;

                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = empAccountDetail;
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
