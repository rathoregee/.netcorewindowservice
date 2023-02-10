using G2V.client.datasync.service.Enums;
using G2V.client.datasync.service.Interfaces;
using G2V.client.datasync.service.Models;

namespace G2V.client.datasync.service.Classes
{

    public static class ServiceResult
    {
        private class ServiceResultInternal<T> : IServiceResult<T>
        {            
            public ServiceResultStatus Status { get; }
            public string[] Errors { get; }

            private readonly T _payload;

            public T Payload => _payload;

            public object PayloadAsObject => _payload;

            private ServiceResultInternal(ServiceResultStatus status)
            {
                Status = status;
            }

            private ServiceResultInternal(ServiceResultStatus status, T payload)
                : this(status)
            {
                _payload = payload;
            }

            private ServiceResultInternal(ServiceResultStatus status, string[] errors)
                : this(status)
            {
                Errors = errors;
            }

            public static IServiceResult<T> Success(T payload)
            {
                return new ServiceResultInternal<T>(ServiceResultStatus.Success, payload);
            }

            public static IServiceResult<T> Created(T payload)
            {
                return new ServiceResultInternal<T>(ServiceResultStatus.Created, payload);
            }

            public static IServiceResult<T> Updated(T payload)
            {
                return new ServiceResultInternal<T>(ServiceResultStatus.Updated, payload);
            }
            
            public static IServiceResult<T> Deleted(T payload)
            {
                return new ServiceResultInternal<T>(ServiceResultStatus.Deleted, payload);
            }

            public static IServiceResult<T> ValidationErrorInternal(params string[] errors)
            {
                return new ServiceResultInternal<T>(ServiceResultStatus.ValidationError, errors);
            }

            public static IServiceResult<T> NotFoundInternal(params string[] errors)
            {
                return new ServiceResultInternal<T>(ServiceResultStatus.NotFound, errors);
            }

            public static IServiceResult<T> ForbiddenInternal(params string[] errors)
            {
                return new ServiceResultInternal<T>(ServiceResultStatus.Forbidden, errors);
            }

            public static IServiceResult<T> ServiceUnavailableInternal(params string[] errors)
            {
                return new ServiceResultInternal<T>(ServiceResultStatus.ServiceUnavailable, errors);
            }

            public static IServiceResult ServiceNotImplementedInternal(params string[] errors)
            {
                return new ServiceResultInternal<T>(ServiceResultStatus.ServiceNotImplemented, errors);
            }

            public static IServiceResult<T> ConflictInternal(params string[] errors)
            {
                return new ServiceResultInternal<T>(ServiceResultStatus.Conflict, errors);
            }
        }

        public static IServiceResult Success()
        {
            return Success(new NullPayload());
        }

        public static IServiceResult<T> Success<T>()
        {
            return ServiceResultInternal<T>.Success(default);
        }

        public static IServiceResult<T> Success<T>(T payload)
        {
            return ServiceResultInternal<T>.Success(payload);
        }

        public static IServiceResult Created()
        {
            return Created(new NullPayload());
        }

        public static IServiceResult<T> Created<T>()
        {
            return ServiceResultInternal<T>.Created(default);
        }

        public static IServiceResult<T> Created<T>(T payload)
        {
            return ServiceResultInternal<T>.Created(payload);
        }

        public static IServiceResult Updated()
        {
            return Updated(new NullPayload());
        }

        public static IServiceResult<T> Updated<T>()
        {
            return ServiceResultInternal<T>.Updated(default);
        }

        public static IServiceResult<T> Updated<T>(T payload)
        {
            return ServiceResultInternal<T>.Updated(payload);
        }

        public static IServiceResult Deleted()
        {
            return Deleted(new NullPayload());
        }

        public static IServiceResult<T> Deleted<T>()
        {
            return ServiceResultInternal<T>.Deleted(default);
        }

        public static IServiceResult<T> Deleted<T>(T payload)
        {
            return ServiceResultInternal<T>.Deleted(payload);
        }

        public static IServiceResult ValidationError(params string[] errors)
        {
            return ServiceResultInternal<NullPayload>.ValidationErrorInternal(errors);
        }

        public static IServiceResult<T> ValidationError<T>(params string[] errors)
        {
            return ServiceResultInternal<T>.ValidationErrorInternal(errors);
        }

        public static IServiceResult NotFound(params string[] errors)
        {
            return ServiceResultInternal<NullPayload>.NotFoundInternal(errors);
        }

        public static IServiceResult<T> NotFound<T>(params string[] errors)
        {
            return ServiceResultInternal<T>.NotFoundInternal(errors);
        }
        public static IServiceResult Forbidden(params string[] errors)
        {
            return ServiceResultInternal<NullPayload>.ForbiddenInternal(errors);
        }

        public static IServiceResult<T> Forbidden<T>(params string[] errors)
        {
            return ServiceResultInternal<T>.ForbiddenInternal(errors);
        }

        public static IServiceResult ServiceUnavailable(params string[] errors)
        {
            return ServiceResultInternal<NullPayload>.ServiceUnavailableInternal(errors);
        }

        public static IServiceResult<T> ServiceUnavailable<T>(params string[] errors)
        {
            return ServiceResultInternal<T>.ServiceUnavailableInternal(errors);
        }
        public static IServiceResult ServiceNotImplemented(params string[] errors)
        {
            return ServiceResultInternal<NullPayload>.ServiceNotImplementedInternal(errors);
        }
        public static IServiceResult<T> Conflict<T>(params string[] errors)
        {
            return ServiceResultInternal<T>.ConflictInternal(errors);
        }
        public static IServiceResult Conflict(params string[] errors)
        {
            return ServiceResultInternal<NullPayload>.ConflictInternal(errors);
        }
    }
}