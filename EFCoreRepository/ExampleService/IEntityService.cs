using EFCoreRepository.ExampleEntities;
using EFCoreRepository.Repository;

namespace EFCoreRepository.ExampleService
{
    public interface IEntityService : IRepository<Entity>
    {

    }
}
