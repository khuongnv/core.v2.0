using System;
using System.Collections.Generic;

namespace Core.Models.Entities
{
    public class DM_MENU
    {        
        public long ID { get; set; }        
        public string M { get; set; }
        public string TEN { get; set; }        
        public long? MENU_CHA_ID { get; set; }
        public string BIEU_TUONG { get; set; }
        public string GHI_CHU { get; set; }
        public string URL { get; set; }
        public long SHOW { get; set; }
        public long THU_TU { get; set; }

    }
}

