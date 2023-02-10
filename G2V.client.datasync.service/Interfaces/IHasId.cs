using System;

namespace G2V.client.datasync.service.Interfaces
{
    public interface IHasId : IHasId<Guid>
    {
    }
    public interface IHasId<TId>
    {
        TId Id { get; }
    }
}