using GapCommon.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
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
            string rawRequest;
            using (var stream = new StreamReader(actionExecutedContext.Request.Content.ReadAsStreamAsync().Result))
            {
                stream.BaseStream.Position = 0;
                rawRequest = stream.ReadToEnd();
            }

            LogException(actionExecutedContext, rawRequest);
        }

        private static void GenerateExceptionResponse(HttpActionExecutedContext actionExecutedContext)
        {
            HttpResponseException ex = actionExecutedContext.Exception as HttpResponseException;

            if (ex != null)
            {
                GenerateExceptionResultHttp(actionExecutedContext, ex);
            }
            else
            {
                GenerateExceptionResultBll(actionExecutedContext);
            }
        }

        private static void GenerateExceptionResultBll(HttpActionExecutedContext actionExecutedContext)
        {
            MessageException ex = actionExecutedContext.Exception as MessageException;

            if (ex != null)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(
                System.Net.HttpStatusCode.BadRequest,
                new
                {
                    code = System.Net.HttpStatusCode.BadRequest,
                    message = ex.TextMessage
                });
            }
            else
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(
                System.Net.HttpStatusCode.BadRequest,
                new
                {
                    code = System.Net.HttpStatusCode.BadRequest,
                    message = actionExecutedContext.Exception.Message
                });
            }
        }

        private static void GenerateExceptionResultHttp(HttpActionExecutedContext actionExecutedContext, HttpResponseException ex)
        {
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(
            ex.Response.StatusCode,
            new
            {
                code = ex.Response.StatusCode,
                message = ex.Response.RequestMessage
            });
        }

        private static void SaveLogInFile(HttpActionExecutedContext actionExecutedContext, string rawRequest)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = Path.Combine(path, "Logs", DateTime.Now.ToShortDateString());
            if (!System.IO.Directory.Exists(fullPath))
            {
                System.IO.Directory.CreateDirectory(fullPath);
            }

            string fileName = "LogFile.txt";

            using (StreamWriter file = new StreamWriter(Path.Combine(fullPath, fileName), true))
            {
                file.WriteLine("--------------------------------------------------------");
                file.WriteLine("---------------------StartLog---------------------------");

                file.WriteLine("Date : " + DateTime.Now.ToString());
                file.WriteLine("Exception : " + actionExecutedContext.Exception.Source);
                file.WriteLine("InnerException : " + actionExecutedContext.Exception.InnerException);
                file.WriteLine("StackTrace : " + actionExecutedContext.Exception.StackTrace);
                file.WriteLine("Request : " + actionExecutedContext.ActionContext.Request.RequestUri.ToString());
                file.WriteLine("Method : " + actionExecutedContext.ActionContext.Request.Method.Method.ToString());
                file.WriteLine("Body : " + rawRequest);

                file.WriteLine("--------------------------------------------------------");
                file.WriteLine("----------------------EndLog----------------------------");
            }
        }

        private void LogException(HttpActionExecutedContext actionExecutedContext, string rawRequest)
        {
            try
            {
                SaveLogInFile(actionExecutedContext, rawRequest);
            }
            catch (Exception ex)
            {
                SaveLogInFile(actionExecutedContext, rawRequest);
            }
            finally
            {
                GenerateExceptionResponse(actionExecutedContext);
            }
        }
    }
}