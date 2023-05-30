using DemoCorsoCSharp.DTO;
using DemoCorsoCSharp.ExtensionsMethods;
using DemoCorsoCSharp.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoCorsoCSharp.Repositories;

public class CategoriesRepository : ICategoriesRepository
{
    private readonly NorthwindContext? database;

    public CategoriesRepository(NorthwindContext database)
    {
        this.database = database;
    }


    public async Task<List<DTOCategoria>?> GetAll()
    {
        //if (database != null)
        //{
        //    var categories = database.Categories.ConvertToDTO();
        //    if (categories != null)
        //    {
        //        var data = await categories.ToListAsync();
        //        return data;
        //    }
        //}
        //return null;
        throw new NotImplementedException();
    }

    public async Task Create(DTOCreaCategoria dTOCreaCategoria)
    {
        if (database != null)
        {
            var dbObject = dTOCreaCategoria.ConvertFromDTO();
            database.Categories.Add(dbObject);
            await database.SaveChangesAsync();
        }
    }

    public async Task<bool> CreateWithReturn(DTOCreaCategoria dTOCreaCategoria)
    {

        if (dTOCreaCategoria.Nome!.Length > 15)
        {
            return false;
        }
        else
        {
            if (database != null)
            {
                var dbObject = dTOCreaCategoria.ConvertFromDTO();
                database.Categories.Add(dbObject);
                await database.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
