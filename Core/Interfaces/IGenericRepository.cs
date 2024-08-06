using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entites;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository <T> where T : BaseEntity
    {
        
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync(ProducsWithTypesAndBrandsSpecification spec);

        Task<T> GetEntityWithSpec(ISpecification<T> spec);

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<object> ListAllAsync();
    }
}