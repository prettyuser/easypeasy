using Followers.Model.Clients.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Followers.Model.EntityConfigurations
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EfClient>().HasData(
                new EfClient(1, "Boris"),
                new EfClient(2, "Pepa"),
                new EfClient(3, "Anna"),
                new EfClient(4, "Olga"),
                new EfClient(5, "Diana"),
                new EfClient(6, "Maria"),
                new EfClient(7, "Stefano"),
                new EfClient(8, "Roman"),
                new EfClient(9, "Igor"),
                new EfClient(10, "Vladislav"),
                new EfClient(11, "Elena"),
                new EfClient(12, "Jee"),
                new EfClient(13, "Frantisek"),
                new EfClient(14, "Irina")
            );
            
            modelBuilder.Entity<EfSubscriber>().HasData(
                new EfSubscriber(9, 1),
                new EfSubscriber(1, 12),
                new EfSubscriber(8, 3),
                new EfSubscriber(7, 8),
                new EfSubscriber(7, 6),
                new EfSubscriber(1, 7),
                new EfSubscriber(1, 2),
                new EfSubscriber(1, 3),
                new EfSubscriber(1, 4),
                new EfSubscriber(1, 9),
                new EfSubscriber(1, 14),
                new EfSubscriber(2, 3),
                new EfSubscriber(2, 7),
                new EfSubscriber(2, 9),
                new EfSubscriber(2, 1),
                new EfSubscriber(3, 4),
                new EfSubscriber(3, 2),
                new EfSubscriber(3, 1),
                new EfSubscriber(4, 8),
                new EfSubscriber(4, 1),
                new EfSubscriber(5, 1)
            );
        }
    }
}