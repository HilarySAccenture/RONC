namespace RONC.Domain.DataObject
{
    public class ApiDataResponse
    {
        public string Title { get; set; }
        public Error Error { get; set; }

        public ApiDataResponse(string errorMessage)
        {
            Error = new Error(errorMessage);
        }
    }
}