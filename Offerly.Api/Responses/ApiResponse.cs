namespace Offerly.Api.Responses
{
    public class ApiResponse
    {
        //TODO SG add correlation ID either here or in the response headers
        //TODO SG do we need status code in the response?
        public List<string>? ErrorMessage { get; set; }

        public ApiResponse(IEnumerable<string>? errorMessages)
        {
            ErrorMessage = errorMessages?.ToList();
        }
    }
}
