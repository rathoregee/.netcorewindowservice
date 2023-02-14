namespace G2V.client.datasync.service.Enums
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
