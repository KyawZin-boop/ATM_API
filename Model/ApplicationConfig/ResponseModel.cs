using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ApplicationConfig
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public ApiStatus Status { get; set; }
        public object Data { get; set; }
    }

    public enum ApiStatus
    {
        Success = 0,
        Error = 1,
        SystemError = 2
    }
}
