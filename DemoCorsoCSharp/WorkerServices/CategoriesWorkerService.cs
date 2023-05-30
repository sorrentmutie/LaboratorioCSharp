using DemoCorsoCSharp.DTO;
using DemoCorsoCSharp.Repositories;

namespace DemoCorsoCSharp.WorkerServices;

public class CategoriesWorkerService : ICategoriesWorkerService
{
    private readonly ICategoriesRepository repository;

    public CategoriesWorkerService(ICategoriesRepository repository)
    {
        this.repository = repository;
    }

    public async Task Create(DTOCreaCategoria dTOCreaCategoria)
    {
        await repository.Create(dTOCreaCategoria);
    }

    public async Task<bool> CreateWithReturn(DTOCreaCategoria dTOCreaCategoria)
    {
        return await repository.CreateWithReturn(dTOCreaCategoria);
    }

    public async Task<List<DTOCategoria>?> GetAll()
    {
        return await  repository.GetAll();
    }
}
