using Actio.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace actio.Common.Events
{
    public interface IRejectedEvent : IEvent
    {
        string Reason { get; }
        string Code { get; }

    }
}
