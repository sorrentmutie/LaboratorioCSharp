using DemoCorsoCSharp.DTO;

namespace DemoCorsoCSharp.Repositories
{
    public interface ICategoriesRepository
    {
        Task Create(DTOCreaCategoria dTOCreaCategoria);
        Task<bool> CreateWithReturn(DTOCreaCategoria dTOCreaCategoria);
        Task<List<DTOCategoria>?> GetAll();
    }
}