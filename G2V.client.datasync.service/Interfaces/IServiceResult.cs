using G2V.client.datasync.service.Enums;

namespace G2V.client.datasync.service.Interfaces
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