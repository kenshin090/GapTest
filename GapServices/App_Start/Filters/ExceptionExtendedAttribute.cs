using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace GapServices.App_Start.Filters
{
    /// <summary>
    /// Filter used to catch a exception
    /// </summary>
    public class ExceptionExtendedAttribute : ExceptionFilterAttribute, IFilter
    {
        /// <summary>
        /// builder for injection
        /// </summary>
        public ExceptionExtendedAttribute()
        {
        }

        /// <summary>
        /// Method for managment of the exception
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
        }
    }
}