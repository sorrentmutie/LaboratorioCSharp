using DemoCorsoCSharp.DTO;
using DemoCorsoCSharp.Infrastructure;
using DemoCorsoCSharp.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoCorsoCSharp.WorkerServices;

public class SupplierWorkerService : ISuppliersWorkerService
{
    private readonly IRepository<Supplier, int> repository;
    private readonly IProblematicSuppliers problematicSuppliers;

    public SupplierWorkerService(IRepository<Supplier, int> repository,
        IProblematicSuppliers problematicSuppliers) 
    {
        this.repository = repository;
        this.problematicSuppliers = problematicSuppliers;
    }

    public async Task<List<DTOFornitore>?> GetAll()
    {
        var suppliers = repository.GetAll();
        var allSuppliers = await suppliers.ToListAsync();

        var filteredSuppliers = new List<DTOFornitore>();

        if(allSuppliers.Any())
        {
            foreach (var supplier in allSuppliers)
            {
                if(!problematicSuppliers.IsProblematic(supplier.CompanyName))
                {
                    filteredSuppliers.Add(new DTOFornitore { Id = supplier.Id, Name = supplier.CompanyName });
                }
            }
        }

        return filteredSuppliers;

    }
}
