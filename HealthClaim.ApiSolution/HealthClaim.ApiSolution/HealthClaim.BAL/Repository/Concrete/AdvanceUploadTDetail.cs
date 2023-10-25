using HealthClaim.BAL.Repository.Interface;
using HealthClaim.DAL;
using HealthClaim.DAL.Models;
using HealthClaim.Model.Dtos.Common;
using HealthClaim.Model.Dtos.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.BAL.Repository.Concrete
{
    public class AdvanceUploadTDetail : GenricRepository<UploadDocument>, IAdvanceUploadTypeDetails
    {
        private HealthClaimDbContext _dbContext;
        public AdvanceUploadTDetail(HealthClaimDbContext db) : base(db)
        {
            _dbContext = db;
        }

        public async Task<ResponeModel> Create(AdvanceUploadTypeDetails advanceUploadTypeDetails)
        {
            ResponeModel responeModel = new ResponeModel();
            if (advanceUploadTypeDetails != null)
            {
                //AdvanceUploadTypeDetail advanceUploadTypeDetail = new AdvanceUploadTypeDetail()
                //{
                //    AdvanceId = advanceUploadTypeDetails.AdvanceId,
                //    UploadTypeId = advanceUploadTypeDetails.UploadTypeId,
                //    Amount = advanceUploadTypeDetails.Amount,
                //};
                //_dbContext.Add(advanceUploadTypeDetail);
                //int id = await _dbContext.SaveChangesAsync();
                //responeModel.Data = advanceUploadTypeDetail;
                responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                responeModel.Error = false;
                responeModel.Message = "Advance upload type detail created successfully.";

            }
            return responeModel;
        }

        public async Task<ResponeModel> Delete(int id)
        {
            ResponeModel responeModel = new ResponeModel();
            //if (id != 0)
            //{
            //    var advanceDeleteType = _dbContext.AdvanceUploadTypeDetails.Where(e => e.Id == id).FirstOrDefault();

            //    if (advanceDeleteType != null)
            //    {
            //        advanceDeleteType.IsActive = false;
            //        await _dbContext.SaveChangesAsync();
            //        responeModel.Data = null;
            //        responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            //        responeModel.Error = false;
            //        responeModel.Message = "AdvanceUpload Type Details deleted successfully.";

            //    }
            //}
            return responeModel;
        }

        public async Task<ResponeModel> Get(int? id)
        {
            ResponeModel responeModel = new ResponeModel();
            //var advanceTypegetById = await _dbContext.AdvanceUploadTypeDetails.Where(e => id == 0 ? e.Id == e.Id : e.Id == id && e.IsActive == true).ToListAsync();
            //responeModel.Data = advanceTypegetById;
            //responeModel.DataLength = advanceTypegetById.Count;
            //responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            //responeModel.Error = false;
            //responeModel.Message = advanceTypegetById.Count + " AdvanceUpload Type found ";

            return responeModel;
        }

        public async Task<ResponeModel> Update(AdvanceUploadTypeDetails advanceUploadTypeDetails, int id)
        {
            ResponeModel responeModel = new ResponeModel();
            //if (advanceUploadTypeDetails != null && id != 0)
            //{
            //    var advanceupdateType = _dbContext.AdvanceUploadTypeDetails.Where(e => e.Id == id).FirstOrDefault();

            //    if (advanceupdateType != null)
            //    {
            //        advanceupdateType.AdvanceId = advanceUploadTypeDetails.AdvanceId;
            //        advanceupdateType.UploadTypeId = advanceUploadTypeDetails.UploadTypeId;
            //        advanceupdateType.Amount = advanceUploadTypeDetails.Amount;
            //        await _dbContext.SaveChangesAsync();
            //        responeModel.Data = advanceupdateType;
            //        responeModel.StatusCode = System.Net.HttpStatusCode.Created;
            //        responeModel.Error = false;
            //        responeModel.Message = "Advance type Updated Successfully";
            //    }
            //}
            return responeModel;
        }
    }
}
