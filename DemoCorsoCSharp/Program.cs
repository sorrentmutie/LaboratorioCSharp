// See https://aka.ms/new-console-template for more information
//using Bogus;
//using DemoCorsoCSharp;

//Console.WriteLine("Hello, World!");

//var customer = GetCustomer();
//Console.WriteLine(customer.EmailAddress);

//var cart = AddRandomProducts();

////var cart2 = new List<IProductModel>();

//foreach (var product in cart)
//{
//    Console.WriteLine($"{product.Title} {product.HasOrderBeenCompleted}");
//    product.ShipItem(customer);
//}

//CustomerModel GetCustomer()
//{
//    var faker = new Faker<CustomerModel>()
//        .StrictMode(true)
//        .RuleFor(c => c.Id,  f => f.Random.Number(1,1000))
//        .RuleFor(c => c.FirstName, f => f.Random.String(10, 'a', 'z'))
//        .RuleFor(c => c.LastName, f => f.Random.String(10, 'a', 'z'))
//        .RuleFor(c => c.City, f => f.Random.String(15, 'a', 'z'))
//        .RuleFor(c => c.EmailAddress, f => f.Internet.Email())
//        .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber())
//        ;

//    return faker.Generate();
//}


//List<PhysicalProductModel> AddRandomPhysicalProducts()
//{
//    var faker = new Faker<PhysicalProductModel>()
//       .StrictMode(true)
//       .RuleFor(c => c.Title, f => f.Random.String(10, 'a', 'z'))
//       .RuleFor(c => c.HasOrderBeenCompleted, f => false);

//    var lista = new List<PhysicalProductModel>();
//    for (int i = 1; i < 50; i++)
//    {
//        lista.Add(faker.Generate());
//    }
//    return lista;
//}


//List<IProductModel> AddRandomProducts() {
//    var faker = new Faker<PhysicalProductModel>()
//       .StrictMode(true)
//       .RuleFor(c => c.Title, f => f.Random.String(10, 'a', 'z'))
//       .RuleFor(c => c.HasOrderBeenCompleted, f => false);

//    var fakerDigital = new Faker<DigitalProductModel>()
//       .StrictMode(true)
//       .RuleFor(c => c.Title, f => f.Random.String(10, 'a', 'z'))
//       .RuleFor(c => c.HasOrderBeenCompleted, f => false)
//       .RuleFor(c => c.TotalDownloadLeft, f => 5);


//    var lista = new List<IProductModel>();
//    for (int i = 1; i < 25; i++)
//    {
//        lista.Add(faker.Generate());
//        lista.Add(fakerDigital.Generate());
//    }
//    return lista;
//}

//using DemoCorsoCSharp;

//ICollidable collidable = new Solid();
//IUpdatable updatable = new Movable();
//IVisible visible = new Visible();
//var mago = new Mago(collidable, updatable, visible);
//mago.Paint();
//mago.Collide();
//mago.Update();


//using DemoCorsoCSharp.SOLID;

//OpenInvoice firstInvoice = new ProposedInvoice();
//OpenInvoice secondInvoice = new FinalInvoice();
//OpenInvoice thirdInvoice= new SpecialInvoice();

//using DemoCorsoCSharp.SOLID;

////Apple apple = new Orange();
////Console.WriteLine(apple.GetColor());

//Fruit fruit = new Orange();
//Console.WriteLine(fruit.GetColor());
//fruit = new Apple();
//Console.WriteLine(fruit.GetColor());

//using DemoCorsoCSharp.SOLID;

//var manager = new EmployeeManager();
//manager.AddEmployee(new Employee { Name = "Luisa Bianchi", Gender = Gender.Female, Position = Position.Administrator });
//manager.AddEmployee(new Employee { Name = "Mario Bianchi", Gender = Gender.Male, Position = Position.Administrator });


//var statistics = new EmployeeStatistics(manager);
//Console.WriteLine(statistics.CountFemaleManager());

using DemoCorsoCSharp.DTO;
using DemoCorsoCSharp.Models;
using Microsoft.EntityFrameworkCore;

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



