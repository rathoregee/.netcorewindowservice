namespace EG2V.client.datasync.service.Results
{
    public class ErrorPayload
    {
        public ErrorPayload(string status, string[] errors)
        {
            Status = status;
            Errors = errors;
        }

        public string Status { get; }

        public string[] Errors { get; }
    }
}