using System;

namespace EG2V.client.datasync.service.Results
{
    public interface IHasId : IHasId<Guid>
    {
    }

    public interface IHasId<TId>
    {
        TId Id { get; }
    }
}