using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Core.Models
{
    public class ApiResultModel<T>
    {
        [DefaultValue(false)]
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
