using DemoCorsoCSharp.DTO;
using DemoCorsoCSharp.Repositories;
using DemoCorsoCSharp.WorkerServices;
using Moq;

namespace DemoCorsoCSharp.Tests;


[TestClass]
public class UnitTest1
{
    [TestMethod]
    public async Task TestSulNomeCategoria()
    {
        //var mock = new Mock<ICategoriesRepository>();
        //ICategoriesWorkerService workerService = new CategoriesWorkerService(mock.Object);


        //var prods = new List<DTOCreaProdotto>();
        //prods.Add(new DTOCreaProdotto()
        //{
        //    Nome = "4prodottoProva",
        //    PrezzoUnitario = 25.0M,
        //    ScortaMagazzino = 22,
        //    IdFornitore = 10
        //});

        //var newCategory = new DTOCreaCategoria
        //{
        //    Nome = "Nuova Categoria con nome lunghissimo",
        //    Descrizione = "Nuova Descrizione",
        //    Prodotti = prods
        //};
        //mock.Setup(  x =>  x.CreateWithReturn(newCategory)).Returns(Task.FromResult(false));


        //var returnValue = await workerService.CreateWithReturn(newCategory);
        //Assert.IsFalse(returnValue);
        Assert.Inconclusive();
    }
}