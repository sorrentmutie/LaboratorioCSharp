using DemoCorsoCSharp.DTO;

namespace DemoCorsoCSharp.WorkerServices;

public interface ICategoriesWorkerService
{
    Task Create(DTOCreaCategoria dTOCreaCategoria);
    Task<bool> CreateWithReturn(DTOCreaCategoria dTOCreaCategoria);
    Task<List<DTOCategoria>?> GetAll();
}
