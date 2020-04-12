using System;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;

namespace actio.services.Activities.Domain.Models
{
    public static class RegisterClassMap
    {
        public static void RegisterClass(this IServiceCollection services)
        {
            BsonClassMap.RegisterClassMap<Activity>(
                x => {
                   
                    x.MapMember(y => y.Id);
                    x.MapMember(y => y.Category);
                    x.MapMember(y => y.UserId);
                    x.MapMember(y => y.Name);
                    x.MapMember(y => y.Description);
                    x.MapMember(y => y.CreatedAt);
                    x.SetIgnoreExtraElements(true);
                    x.MapCreator(a => new Activity(a.Id, new Category(a.Category), a.UserId, a.Name, a.Description, a.CreatedAt));
                });
           // BsonClassMap.RegisterClassMap<Category>();
        }

    }
}
