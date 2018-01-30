using EFCoreRepository.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreRepository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ILogger<T> _logger;
        private ApplicationDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(ApplicationDbContext context,
            ILogger<T> logger)
        {
            this.context = context;
            entities = context.Set<T>();
            _logger = logger;
        }

        public T Get(object id)
        {
            return entities.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return entities;
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            SaveChanges();
            _logger.LogDebug(999, "Generic Repository {Action} Entity", "Insert");
        }

        public async Task InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            await SaveChangesAsync();
            _logger.LogDebug(999, "Generic Repository {Action} Entity", "InsertAsync");
        }

        public void InsertAll(ICollection<T> range)
        {
            if (range == null || range.Count < 1)
            {
                throw new ArgumentNullException("range");
            }
            entities.AddRange(range);
            SaveChanges();
            _logger.LogDebug(999, "Generic Repository {Action} Entity", "InsertAll");
        }

        public async Task InsertAllAsync(ICollection<T> range)
        {
            if (range == null || range.Count < 1)
            {
                throw new ArgumentNullException("range");
            }
            entities.AddRange(range);
            await SaveChangesAsync();
            _logger.LogDebug(999, "Generic Repository {Action} Entity", "InsertAllAsync");
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Entry(entity).State = EntityState.Modified;
            SaveChanges();
            _logger.LogDebug(999, "Generic Repository {Action} Entity", "Update");
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
            _logger.LogDebug(999, "Generic Repository {Action} Entity", "UpdateAsync");
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _logger.LogDebug(999, "Generic Repository {Action} Entity", "Delete");
            SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _logger.LogDebug(999, "Generic Repository {Action} Entity", "DeleteAsync");
            await SaveChangesAsync();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
