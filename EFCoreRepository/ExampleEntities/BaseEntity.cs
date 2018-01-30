using System;

namespace EFCoreRepository.ExampleEntities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
