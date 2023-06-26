using Session6_BoilerPlate.AppDbContext;
using Session6_BoilerPlate.Models;

namespace Session6_BoilerPlate.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDb _productDb;

        public ProductRepository( ProductDb productDb)
        {
            _productDb = productDb;
        }

        public List<Product> GetProducts()
        {
            return _productDb.HealthProducts.ToList();
        }



    }
}
