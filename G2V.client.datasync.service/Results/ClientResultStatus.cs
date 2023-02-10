namespace EG2V.client.datasync.service.Results
{
    public enum ClientResultStatus
    {
        Success,
        Created,
        Updated,
        Deleted,
        NotFound,
        ServiceUnavailable,
        ValidationError,
        UnexpectedError,
        Conflict
    }
}