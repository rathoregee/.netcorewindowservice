namespace EG2V.client.datasync.service.Results
{
    public interface IClientResult
    {
        ClientResultStatus Status { get; }
        object PayloadAsObject { get; }
        string[] Errors { get; }
    }

    public interface IClientResult<T> : IClientResult
    {
        T Payload { get; }
    }
}