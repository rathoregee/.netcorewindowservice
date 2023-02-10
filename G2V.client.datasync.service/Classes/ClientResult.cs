using G2V.client.datasync.service.Enums;
using G2V.client.datasync.service.Interfaces;
using G2V.client.datasync.service.Models;

namespace G2V.client.datasync.service.Classes
{
    public static class ClientResult
    {
        private class ClientResultInternal<T> : IClientResult<T>
        {
            public ClientResultStatus Status { get; }
            public string[] Errors { get; }

            private readonly T _payload;

            public T Payload => _payload;

            public object PayloadAsObject => _payload;

            private ClientResultInternal(ClientResultStatus status)
            {
                Status = status;
            }

            private ClientResultInternal(ClientResultStatus status, T payload)
                : this(status)
            {
                _payload = payload;
            }

            private ClientResultInternal(ClientResultStatus status, string[] errors)
                : this(status)
            {
                Errors = errors;
            }

            public static IClientResult<T> Success(T payload)
            {
                return new ClientResultInternal<T>(ClientResultStatus.Success, payload);
            }

            public static IClientResult<T> Created(T payload)
            {
                return new ClientResultInternal<T>(ClientResultStatus.Created, payload);
            }

            public static IClientResult<T> Updated(T payload)
            {
                return new ClientResultInternal<T>(ClientResultStatus.Updated, payload);
            }

            public static IClientResult<T> Deleted(T payload)
            {
                return new ClientResultInternal<T>(ClientResultStatus.Deleted, payload);
            }

            public static IClientResult<T> NotFoundInternal(params string[] errors)
            {
                return new ClientResultInternal<T>(ClientResultStatus.NotFound, errors);
            }

            public static IClientResult<T> ValidationError(params string[] errors)
            {
                return new ClientResultInternal<T>(ClientResultStatus.ValidationError, errors);
            }

            public static IClientResult<T> ServiceUnavailableInternal(params string[] errors)
            {
                return new ClientResultInternal<T>(ClientResultStatus.ServiceUnavailable, errors);
            }
            public static IClientResult<T> Conflict(params string[] errors)
            {
                return new ClientResultInternal<T>(ClientResultStatus.Conflict, errors);
            }
        }

        public static IClientResult Success()
        {
            return Success(new NullPayload());
        }

        public static IClientResult<T> Success<T>()
        {
            return ClientResultInternal<T>.Success(default);
        }

        public static IClientResult<T> Success<T>(T payload)
        {
            return ClientResultInternal<T>.Success(payload);
        }

        public static IClientResult Created()
        {
            return Created(new NullPayload());
        }

        public static IClientResult<T> Created<T>()
        {
            return ClientResultInternal<T>.Created(default);
        }

        public static IClientResult<T> Created<T>(T payload)
        {
            return ClientResultInternal<T>.Created(payload);
        }

        public static IClientResult Updated()
        {
            return Updated(new NullPayload());
        }

        public static IClientResult<T> Updated<T>()
        {
            return ClientResultInternal<T>.Updated(default);
        }

        public static IClientResult<T> Updated<T>(T payload)
        {
            return ClientResultInternal<T>.Updated(payload);
        }

        public static IClientResult Deleted()
        {
            return Deleted(new NullPayload());
        }

        public static IClientResult<T> Deleted<T>()
        {
            return ClientResultInternal<T>.Deleted(default);
        }

        public static IClientResult<T> Deleted<T>(T payload)
        {
            return ClientResultInternal<T>.Deleted(payload);
        }

        public static IClientResult NotFound(params string[] errors)
        {
            return ClientResultInternal<NullPayload>.NotFoundInternal(errors);
        }

        public static IClientResult<T> NotFound<T>(params string[] errors)
        {
            return ClientResultInternal<T>.NotFoundInternal(errors);
        }

        public static IClientResult ServiceUnavailable(params string[] errors)
        {
            return ClientResultInternal<NullPayload>.ServiceUnavailableInternal(errors);
        }

        public static IClientResult<T> ServiceUnavailable<T>(params string[] errors)
        {
            return ClientResultInternal<T>.ServiceUnavailableInternal(errors);
        }

        public static IClientResult ValidationError(params string[] errors)
        {
            return ClientResultInternal<NullPayload>.ValidationError(errors);
        }

        public static IClientResult<T> ValidationError<T>(params string[] errors)
        {
            return ClientResultInternal<T>.ValidationError(errors);
        }

        public static IClientResult Conflict(params string[] errors)
        {
            return ClientResultInternal<NullPayload>.Conflict(errors);
        }
    }
}