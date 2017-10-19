using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Riba.Models
{
    public class JsonResponseViewModel
    {
        public bool IsSuccess { get; set; }
        public object Data { get; set; }
        public IList<string> Errors { get; set; }

        public JsonResponseViewModel(bool isSuccess, Object data = null, IList<string> errors = null)
        {
            IsSuccess = isSuccess;
            Data = data;
            Errors = errors;
        }
    }
}