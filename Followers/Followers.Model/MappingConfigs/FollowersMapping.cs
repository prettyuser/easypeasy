using Followers.Model.Clients.Db.Entities;
using Followers.Model.Clients.Dto;
using Mapster;

namespace Followers.Model.MappingConfigs
{
    public static class FollowersMapping
    {
        public static readonly TypeAdapterConfig TypeAdapterConfiguration = GetTypeAdapterConfig();

        private static TypeAdapterConfig GetTypeAdapterConfig()
        {
            var config = new TypeAdapterConfig();
            
            config.NewConfig<EfClient, ClientData>()
                .Map(e => e.Followers, src => src.Subscribers.Count);
            
            return config;
        }
    }
}
