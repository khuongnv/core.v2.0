using System;
using System.Collections.Generic;

namespace Core.Models.Entities
{
    public class LOG_THAO_TAC
    {        
        public long LOG_THAO_TAC_ID { get; set; }        
        public string NGUOI_THAO_TAC { get; set; }
        public DateTime TG_THUC_HIEN { get; set; }
        public string NOI_DUNG_THUC_HIEN { get; set; }
        public string MO_TA { get; set; }
        public long TARGET_ID { get; set; }  
    }
}

