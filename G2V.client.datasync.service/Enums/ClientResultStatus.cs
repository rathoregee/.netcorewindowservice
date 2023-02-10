using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
