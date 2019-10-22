using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCase1_Shop.ConfiguringApps
{
    /// <summary>
    /// Global
    /// </summary>
    public class ValidateDataBaseAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ArgumentException)
            {
                //context.ModelState.AddModelError("error", context.Exception.Message);
                context.Result = new BadRequestResult();
                context.ExceptionHandled = true;
            }
        }
    }
}
