using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.Model.Dtos.Common
{
    public class FileUploadModel
    {
        public IFormFile FileDetails { get; set; }
       
    }
}
