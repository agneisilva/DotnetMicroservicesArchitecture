using System;
using actio.Common.Exceptions;

namespace actio.API.Domain.Models
{
    public class Activity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
