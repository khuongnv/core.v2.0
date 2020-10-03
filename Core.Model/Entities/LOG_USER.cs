using System;
using System.Collections.Generic;

namespace Core.Models.Entities
{
    public class LOG_USER
    {        
        public long LOG_USER_ID { get; set; }        
        public string TEN_DANG_NHAP { get; set; }
        public DateTime TG_THUC_HIEN { get; set; }
        public string SESSION_ID { get; set; }
        public long LOG_IN_OUT { get; set; }
        public string IP_MAY_CHU { get; set; }
        public string IP_MAY_TRAM { get; set; }
        public string TRINH_DUYET { get; set; }
        public long THANH_CONG { get; set; }        
    }
}

