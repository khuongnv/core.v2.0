using System;
using System.Collections.Generic;

namespace Core.Models.Entities
{
    public class DM_NHAN_VIEN
    {        
        public long ID { get; set; }        
        public string MA { get; set; }
        public string TEN { get; set; }
        public long? DON_VI_ID { get; set; }
        public DateTime? NGAY_SINH { get; set; }
        public string SO_THE { get; set; }
        public string USER_NAME { get; set; }
        public long HOAT_DONG { get; set; }        
        public string GHI_CHU { get; set; }   
        public string SO_DI_DONG { get; set; }        
        public long ROLE { get; set; }
    }
}

