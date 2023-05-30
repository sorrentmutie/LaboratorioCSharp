using DemoCorsoCSharp.DTO;
using DemoCorsoCSharp.Models;

var database = new NorthwindContext();

var categories = await database.Categories
    .Include(c => c.Products)
    .ThenInclude(p => p.Supplier)
    .Select(c => new DTOCategoria
    {
         Id = c.CategoryId, Nome = c.CategoryName, NumeroProdotti = c.Products.Count
         , Prodotti = c.Products.Select( 
             p => new DTOProdotto { Id = p.ProductId,
                Nome = p.ProductName, Fornitore = p.Supplier.CompanyName})
    })
    .ToListAsync();

//foreach (var category in categories)
//{
//    Console.WriteLine("Category: " + category.CategoryName);
//	foreach (var product in category.Products)
//	{
//        Console.WriteLine($"====== {product.ProductName}");
//        Console.WriteLine($"{product.Supplier.CompanyName}");
//    }
//}

foreach (var category in categories)
{
    Console.WriteLine($"{category.Nome} {category.NumeroProdotti}");
    if(category.Prodotti != null)
    {
        foreach (var product in category.Prodotti)
        {
            Console.WriteLine($"{product.Nome} {product.Fornitore}");
        }
    }
}

var prods = new List<Product>();
prods.Add(new Product { ProductName = "1prodottoProva", SupplierId = 10 });

var newCategory = new Category
{
    CategoryName = "BlaBla",
    Description = "Descrizione prova prova",
    Products = prods
};

database.Categories.Add(newCategory);
await database.SaveChangesAsync();


public interface IDataRepository<T>
{
    IEnumerable<T> GetAll();
    T Get(int id);
    void Add(T item);
    void Update(T item);
    void Delete(T item);
}
