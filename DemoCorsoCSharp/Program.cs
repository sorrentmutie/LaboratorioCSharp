using DemoCorsoCSharp.DTO;
using DemoCorsoCSharp.Models;
using Microsoft.EntityFrameworkCore;
using DemoCorsoCSharp.ExtensionsMethods;

var database = new NorthwindContext();

var categories = database.Categories.ConvertToDTO();

if(categories != null)
{
    var data = await categories.ToListAsync();
    foreach (var category in data)
    {
        Console.WriteLine($"{category.Nome} {category.NumeroProdotti}");
        if (category.Prodotti != null)
        {
            foreach (var product in category.Prodotti)
            {
                Console.WriteLine($"{product.Nome} {product.Fornitore}");
            }
        }
    }
}

//foreach (var category in categories)
//{
//    Console.WriteLine("Category: " + category.CategoryName);
//	foreach (var product in category.Products)
//	{
//        Console.WriteLine($"====== {product.ProductName}");
//        Console.WriteLine($"{product.Supplier.CompanyName}");
//    }
//}



//var prods = new List<Product>();
//prods.Add(new Product { ProductName = "1prodottoProva", SupplierId = 10 });

//var newCategory = new Category
//{
//    CategoryName = "BlaBla",
//    Description = "Descrizione prova prova",
//    Products = prods
//};

var prods = new List<DTOCreaProdotto>();
prods.Add(new DTOCreaProdotto() { Nome = "2prodottoProva", PrezzoUnitario = 15.0M, ScortaMagazzino = 12,
 IdFornitore = 10});

var newCategory = new DTOCreaCategoria
{
    Nome = "Nuova Categoria",
    Descrizione = "Nuova Descrizione",
    Prodotti = prods
};

database.Categories.Add(newCategory.ConvertFromDTO());
await database.SaveChangesAsync();
Console.WriteLine("Scrittura completata");


//public interface IDataRepository<T>
//{
//    IEnumerable<T> GetAll();
//    T Get(int id);
//    void Add(T item);
//    void Update(T item);
//    void Delete(T item);
//}
