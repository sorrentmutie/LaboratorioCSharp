using DemoCorsoCSharp.DTO;
using DemoCorsoCSharp.ExtensionsMethods;
using DemoCorsoCSharp.Infrastructure;
using DemoCorsoCSharp.Models;
using DemoCorsoCSharp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DemoCorsoCSharp.WorkerServices;

public class CategoriesWorkerService : ICategoriesWorkerService
{
   // private readonly ICategoriesRepository repository;

    private readonly IRepository<Category, int>? categoryRepository;


    public CategoriesWorkerService(IRepository<Category, int> categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    public async Task Create(DTOCreaCategoria dTOCreaCategoria)
    {
        if(categoryRepository != null)
        {
            await categoryRepository.CreateAsync(dTOCreaCategoria.ConvertFromDTO());
        }
    }

    public async Task<bool> CreateWithReturn(DTOCreaCategoria dTOCreaCategoria)
    {
        throw new NotImplementedException();
    }

    public async Task<List<DTOCategoria>?> GetAll()
    {
        if(categoryRepository != null)
        {
            var data = await categoryRepository.GetAll()
                .Include(x => x.Products)
                .ThenInclude( p => p.Supplier)
                .ToListAsync();
           
            if(data != null)
            {
                return data.ConvertToDTO()!.ToList();
            }
            return null;
        }
        return null;
    }
}
