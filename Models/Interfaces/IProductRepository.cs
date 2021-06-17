using System.Linq;
using SportsStore.Models.Data;

namespace SportsStore.Models.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}