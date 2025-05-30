
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

//SOLID
//OPEN CLOSED primciple


ProductManager productManager = new ProductManager(new EfProductDal());

foreach (var product in productManager.GetAll())
{
    Console.WriteLine(product.ProductName);
}