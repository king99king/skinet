using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entites;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The <see cref="StoreContext"/> instance to use for data access.</param>
        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves an entity of type <typeparamref name="T"/> from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the entity of type <typeparamref name="T"/>.</returns>
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

     
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

           public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
           return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }


        /// <summary>
        /// Applies the given specification to the queryable set of entities.
        /// </summary>
        /// <param name="spec">The specification to apply.</param>
        /// <returns>The queryable set of entities after applying the specification.</returns>

        private IQueryable<T> ApplySpecification(ISpecification<T> spec){

            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }

        public Task<IReadOnlyList<T>> ListAllAsync(ProducsWithTypesAndBrandsSpecification spec)
        {
            throw new NotImplementedException();
        }

        Task<object> IGenericRepository<T>.ListAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}