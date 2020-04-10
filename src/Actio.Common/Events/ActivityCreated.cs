using Actio.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace actio.Common.Events
{
    public class ActivityCreated : IAuthenticateEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string Category { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime CreatedAt { get; }

        protected ActivityCreated() { }
        public ActivityCreated(Guid id, 
                               Guid userId, 
                               string category, 
                               string name, 
                               string description,
                               DateTime createdAt) {
            Id = id;
            UserId = userId;
            Category = category;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
        }
    }
}
