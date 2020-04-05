using Actio.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace actio.Common.Events
{
    public class UserAuthenticated : IEvent
    {
        protected UserAuthenticated() { }
        public UserAuthenticated(string email) {
            Email = email;
        }

        public string Email { get; }
    }
}
