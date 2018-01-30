using EFCoreRepository.DataContext;
using EFCoreRepository.ExampleEntities;
using EFCoreRepository.Repository;
using Microsoft.Extensions.Logging;

namespace EFCoreRepository.ExampleService
{
    public class EntityService : Repository<Entity>, IEntityService
    {
        public EntityService(ApplicationDbContext context, ILogger<Entity> logger) : base(context, logger) { }
    }
}
