namespace EG2V.client.datasync.service.Results
{
    public interface IServiceResult
    {        
        ServiceResultStatus Status { get; }
        object PayloadAsObject { get; }
        string[] Errors { get; }
    }

    public interface IServiceResult<T> : IServiceResult
    {
        T Payload { get; }
    }
}