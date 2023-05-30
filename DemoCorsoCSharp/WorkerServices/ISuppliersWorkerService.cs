using DemoCorsoCSharp.DTO;

namespace DemoCorsoCSharp.WorkerServices;

public interface ISuppliersWorkerService
{
    Task<List<DTOFornitore>?> GetAll();
}
