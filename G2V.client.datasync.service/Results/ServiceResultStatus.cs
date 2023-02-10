namespace EG2V.client.datasync.service.Results
{
    public enum ServiceResultStatus
    {
        Success,
        Created,
        Updated,
        Deleted,
        NotFound,
        ValidationError,
        ServiceUnavailable,
        ServiceNotImplemented,
        Conflict,
        Forbidden
    }
}