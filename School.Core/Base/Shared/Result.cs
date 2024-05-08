using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace School.Application.Base.Shared
{
    public class Result<T>
    {
        public bool Succeeded { get; set; }
        public StatusResult StatusResult { get; set; }
        public int? StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public List<ValidationFailure>? ValidationsErrors { get; set; }

        public Result()
        {

        }
        public Result(bool succeeded, StatusResult statusResult)
        {
            Succeeded = succeeded;
            StatusResult = statusResult;
        }

        public static Result<T> Success(T Data, string Message = "Falid")
        {
            return new Result<T>()
            {
                Succeeded = true,
                StatusResult = StatusResult.Success,
                StatusCode = (int)StatusCodes.Status200OK,
                Data = Data,
                Message = Message

            };
        }
        public static Result<T> Falid(T Data, string Message = "Falid")
        {
            return new Result<T>()
            {
                Succeeded = false,
                StatusResult = StatusResult.Falid,
                StatusCode = (int)StatusCodes.Status417ExpectationFailed,
                Data = Data,
                Message = Message

            };
        }
        public static Result<T> Info(T Data, StatusResult statusResult = StatusResult.Exist, string Message = "Exist", int StatusCode = (int)StatusCodes.Status200OK)
        {
            return new Result<T>()
            {
                Succeeded = false,
                StatusResult = statusResult,
                StatusCode = StatusCode,
                Data = Data,
                Message = Message

            };
        }

    }
}
