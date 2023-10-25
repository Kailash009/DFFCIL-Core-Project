using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.Model.Dtos.Response
{
    public class ResponeModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public int DataLength { get; set; }
        public bool Error { get; set; }
        public object ErrorDetail { get; set; }
    }
}
