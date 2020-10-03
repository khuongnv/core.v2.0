using System;
using System.Collections.Generic;

namespace Core.Models.Entities
{
    public class DM_DON_VI
    {        
        public long ID { get; set; }        
        public string MA { get; set; }
        public string TEN { get; set; }        
        public long HOAT_DONG { get; set; }
        public long DON_VI_CHA_ID { get; set; }        
        public string GHI_CHU { get; set; }
    }
}

