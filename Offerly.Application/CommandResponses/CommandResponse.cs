using System.Net;

namespace Offerly.Application.CommandResponses
{
    public class CommandResponse<T> : CommandResponse
    {
        public T? Payload { get; set; }

        public CommandResponse(int statusCode, string errorMessage, T? payload) : base(statusCode, errorMessage)
        {
            Payload = payload;
        }

        public static Task<CommandResponse<T>> SuccessfulResponse(T payload)
        {
            return Task.FromResult(new CommandResponse<T>((int)HttpStatusCode.OK, string.Empty, payload));
        }

        public static new Task<CommandResponse<T>> NotFoundResponse(string errorMessage)
        {
            return Task.FromResult(new CommandResponse<T>((int)HttpStatusCode.NotFound, errorMessage, default));
        }
    }

    public class CommandResponse
    {
        public int StatusCode { get; set; }

        public List<string> ErrorMessage { get; set; }

        public CommandResponse(int statusCode, string errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessage = new List<string>() { errorMessage }; ;
        }

        public CommandResponse(int statusCode, IEnumerable<string> errorMessages)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessages.ToList();
        }

        public static Task<CommandResponse> SuccessfulResponse()
        {
            return Task.FromResult(new CommandResponse((int)HttpStatusCode.OK, string.Empty));
        }

        public static Task<CommandResponse> NotFoundResponse(string errorMessage)
        {
            return Task.FromResult(new CommandResponse((int)HttpStatusCode.NotFound, errorMessage));
        }

        public static Task<CommandResponse> ValidationErrorResponse(IEnumerable<string> errorMessage)
        {
            return Task.FromResult(new CommandResponse((int)HttpStatusCode.BadRequest, errorMessage));
        }
    }
}