using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;

namespace Core.Models
{
    public class ApiResultOfDataSetModel
    {
        [DefaultValue(false)]
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public DataSet Data { get; set; }
    }
}
