using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common;
using Core.Models;
using Core.Models.Entities;
namespace Core.Business
{
    public class BaseBusiness
    {
        /// <summary>
        /// Handles the exceptions.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public void HandleBOExceptions(Exception ex)
        {
            ExceptionHandlers.Handle(ex, ExceptionTypes.BUSINESS_EXCEPTION);
        }        
    }
}
