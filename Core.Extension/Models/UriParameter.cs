using System;
using System.Collections.Generic;

namespace Core.Extension.Models
{
    public class UriParameter
    {        
        public long DatabaseId { get; set; }        
        public string TenThuTuc { get; set; }
        public List<ThamSoThuTuc> listThamSoIn { get; set; }
        public List<ThamSoThuTuc> listThamSoOut { get; set; }
    }
}

