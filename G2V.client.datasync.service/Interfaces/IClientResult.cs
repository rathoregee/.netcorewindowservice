using G2V.client.datasync.service.Enums;

namespace G2V.client.datasync.service.Interfaces
{
    public interface IClientResult
    {
        ClientResultStatus Status { get; }
        object PayloadAsObject { get; }
        string[] Errors { get; }
    }

    public interface IClientResult<out T> : IClientResult
    {
        T Payload { get; }
    }
}