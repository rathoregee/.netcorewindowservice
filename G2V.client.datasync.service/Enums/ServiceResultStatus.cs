namespace G2V.client.datasync.service.Enums
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