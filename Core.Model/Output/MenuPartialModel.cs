using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Models.Entities;

namespace Core.Models.Output
{
    public class MenuPartialModel
    {
        public List<DM_MENU> ListAllMenu { get; set; }
        public DM_MENU MenuSelected { get; set; }
    }
}