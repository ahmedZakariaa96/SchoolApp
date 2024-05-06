using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System.Text;

namespace School.Application.Base.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;
        private readonly IHostingEnvironment _IHostingEnvironment;
        public UnhandledExceptionBehaviour(ILogger<TRequest> logger, IHostingEnvironment iHostingEnvironment)
        {
            _logger = logger;
            _IHostingEnvironment = iHostingEnvironment;
        }


        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                //return Result.Failure(new List<string>(), StatusResult.RelatedData);
                LogException(ex, request);
                var requestName = typeof(TRequest).Name;
                _logger.LogError(ex, "Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);
                //------------------------------------------------------------
                //var response = new Exception(ex.Message);
                throw;
            }
        }
        public void LogException(Exception ex, TRequest request)
        {


            if (!(ex is ThreadAbortException))
            {
                string logFilePath = _IHostingEnvironment.ContentRootPath + "\\Log\\";
                string filename = String.Format("ExceptionLog___{0:dd-MM-yyyy}.txt", DateTime.Now);
                string filePath = Path.Combine(logFilePath, filename);
                if (!Directory.Exists(logFilePath))
                    Directory.CreateDirectory(logFilePath);
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    Guid ExceptionID = Guid.NewGuid();
                    writer.WriteLine("ExceptionID : " + ExceptionID.ToString());
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine("Request : " + request.GetType().Name + "" + request);
                    writer.WriteLine(GetExceptionInfo(ex));
                    writer.WriteLine(GetExceptionFailureInfo(ex));
                    writer.WriteLine("######################################################################################################################################");
                    writer.WriteLine(Environment.NewLine);

                }

            }

        }
        public static string GetExceptionInfo(Exception ex)
        {

            StringBuilder Entry = new StringBuilder();
            Entry.AppendLine("----------------------------------------------------------------------------");
            Entry.AppendLine("Exception");
            Entry.AppendLine(string.Concat("Exception Message: ", ex.Message));
            Entry.AppendLine(string.Concat("Source: ", ex.Source));
            //Entry.AppendLine("Stack Trace: ");
            //Entry.AppendLine(ex.StackTrace);


            Exception? innerException = ex.InnerException;
            if (innerException != null)
            {
                Entry.AppendLine("Inner Exception : ");
                Entry.Append(GetExceptionInfo(innerException));
            }
            var entryString = Entry.ToString();
            return entryString;

        }
        public static string GetExceptionFailureInfo(Exception ex)
        {
            StringBuilder Entry = new StringBuilder();
            var exValidationException = ex as FluentValidation.ValidationException;
            if (exValidationException != null)
            {

                Entry.AppendLine("----------------------------------------------------------------------------");
                Entry.AppendLine("errors");
                foreach (var error in exValidationException.Errors)
                {
                    Entry.AppendLine(error.ErrorCode + " , " + error.PropertyName + ": " + error.ErrorMessage);

                }




            }
            var entryString = Entry.ToString();
            return entryString;

        }

    }








}
