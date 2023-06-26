using Session6_BoilerPlate.Models;

namespace Session6_BoilerPlate.Repository
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();
    }
}
