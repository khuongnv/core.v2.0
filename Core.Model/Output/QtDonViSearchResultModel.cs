using System.Collections.Generic;
using Core.Models.Entities;
namespace Core.Models.Output
{
    public class QtDonViSearchResultModel : DM_DON_VI
    {
        public long? STT { get; set; }
        public string TEN_DON_VI_CHA { get; set; }
    }
}