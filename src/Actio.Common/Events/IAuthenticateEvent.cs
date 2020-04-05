using System;

namespace Actio.Common.Events
{
    public interface IAuthenticateEvent : IEvent
    {
         Guid Id {get;}
    }
}