using DemoCorsoCSharp.Infrastructure;
using DemoCorsoCSharp.Models;
using DemoCorsoCSharp.Repositories;
using DemoCorsoCSharp.WorkerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices( services =>
    {
        services.AddSingleton<DbContext, NorthwindContext>();
       // services.AddDbContext<NorthwindContext>();
       // services.AddSingleton<ICategoriesRepository, CategoriesRepository>();
       services.AddSingleton<IRepository<Category, int>, EFRepository<Category, int>>();
        services.AddSingleton<ICategoriesWorkerService, CategoriesWorkerService>();
    })
    .Build();

await host.StartAsync();


var categoriesWorkerService = host.Services.GetRequiredService<ICategoriesWorkerService>();


//var database = new NorthwindContext();
//ICategoriesRepository repo = new CategoriesRepository(database);
//ICategoriesWorkerService categoriesWorkerService = new CategoriesWorkerService(repo);



var categories = await categoriesWorkerService.GetAll();
if(categories != null)
{
    foreach (var category in categories)
    {
        Console.WriteLine($"{category.Nome} {category.NumeroProdotti}");
        if (category.Prodotti != null)
        {
            foreach (var product in category.Prodotti)
            {
                Console.WriteLine($"{product?.Nome} {product?.Fornitore}");
            }
        }
    }
}

//var prods = new List<DTOCreaProdotto>();
//prods.Add(new DTOCreaProdotto() { Nome = "4prodottoProva", PrezzoUnitario = 25.0M, ScortaMagazzino = 22,
// IdFornitore = 10});

//var newCategory = new DTOCreaCategoria
//{
//    Nome = "Nuova Categoria",
//    Descrizione = "Nuova Descrizione",
//    Prodotti = prods
//};


//await repo.Create(newCategory);
Console.WriteLine("Scrittura completata");


//public interface IDataRepository<T>
//{
//    IEnumerable<T> GetAll();
//    T Get(int id);
//    void Add(T item);
//    void Update(T item);
//    void Delete(T item);
//}
