using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entites;

namespace Core.Specifications
{
    public class ProducsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProducsWithTypesAndBrandsSpecification()
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }

        public ProducsWithTypesAndBrandsSpecification(int id ) : base(x => x.Id == id)
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }
    }
}