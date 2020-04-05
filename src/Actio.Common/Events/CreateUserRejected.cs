using System;
using System.Collections.Generic;
using System.Text;

namespace actio.Common.Events
{
    public class CreateUserRejected : IRejectedEvent
    {

        protected CreateUserRejected() { }
        public CreateUserRejected(string email, string reason, string code) {
            Email = email;
            Reason = reason;
            Code = code;
        }

        public string Email { get; }
        public string Reason { get; }
        public string Code { get; }
    }
}
