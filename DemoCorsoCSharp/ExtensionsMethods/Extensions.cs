using DemoCorsoCSharp.DTO;
using DemoCorsoCSharp.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoCorsoCSharp.ExtensionsMethods;

public static class Extensions
{
    public static IQueryable<DTOCategoria>? ConvertToDTO(this List<Category> categories)
    {
        var data = categories
           // .Include(c => c.Products)
           //.ThenInclude(p => p.Supplier)
           .Select(c => new DTOCategoria
           {
               Id = c.Id,
               Nome = c.CategoryName,
               NumeroProdotti = c.Products.Count
                ,
               Prodotti = c.Products.Select(
                    p => new DTOProdotto
                    {
                        Id = p.ProductId,
                        Nome = p.ProductName,
                        Fornitore = p.Supplier != null ? p.Supplier.CompanyName : ""
                    })
           });
        return data.AsQueryable();
    }

    public static Category ConvertFromDTO(this DTOCreaCategoria categoria)
    {
        var category = new Category
        {
            Id = categoria.Id,
            CategoryName = categoria.Nome,
            Description = categoria.Descrizione
        };
        if(categoria.Prodotti != null)
        {
            category.Products = new List<Product>();
            foreach (var prodotto in categoria.Prodotti)
            {
                category.Products.Add(new Product
                {
                    CategoryId = categoria.Id,
                    SupplierId = prodotto.IdFornitore,
                    ProductName = prodotto.Nome,
                    UnitPrice = prodotto.PrezzoUnitario,
                    UnitsInStock = prodotto.ScortaMagazzino
                });
            }
        }
        return category;
    }
}

