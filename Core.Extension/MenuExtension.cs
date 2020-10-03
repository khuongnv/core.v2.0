using System;
using System.Collections.Generic;
using Core.Models;
using Core.Models.Entities;

namespace Core.Extension
{
    public class MenuExtension : BaseExtension
    {
        public MenuExtension()
        {
        }
        public ResultModel<List<DM_MENU>> GetAllMenu()
        {
            var result = new ResultModel<List<DM_MENU>>();            
            try
            {
                result = ConvertToResultModel<DM_MENU>(GetAll(0, "DM_MENU"));
            }
            catch (Exception ex)
            {
                HandleDAOExceptions(ex);
            }            
            return result;
        }
    }
}
