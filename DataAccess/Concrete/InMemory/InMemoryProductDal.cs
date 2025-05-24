using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {

        List<Product> _products;



        //Bir veritabanını simüle ettim List ile. Bunu constructorda oluşturdum.
        public InMemoryProductDal()


        {
            _products = new List<Product> {


                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=2,CategoryId=1,ProductName="Fincan",UnitPrice=500,UnitsInStock=3},
                new Product{ProductId=3,CategoryId=2,ProductName="Tava",UnitPrice=1500,UnitsInStock=2},
                new Product{ProductId=4,CategoryId=2,ProductName="Tencere",UnitPrice=150,UnitsInStock=65},
                new Product{ProductId=5,CategoryId=2,ProductName="Masa",UnitPrice=85,UnitsInStock=1}


            };
        }




        public List<Product> GetAll()
        {
            return _products;
        }


        public void Add(Product product)
        {
            _products.Add(product);
        }


        // LINQ ile silmeliyiz . Silme işlemi biraz daha sorunlu çünkü yukarıdaki temsili datalar bir referans adresi ile tutuluyor.
        // Nesne referansını bulup silmemiz lazım.
        public void Delete(Product product)
        {


            Product productToDelete;  //Silmek istenen nesne için bir referans tutuyoruz.


            //SingleOrDefault ile tek bir nesne döndürdük. _products listesi içinde product.ProductId ile eşleşen bir nesne arıyoruz.
            // Bir nevi foreach ile dolaşmış olduk.
            productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);

        }





        public void Update(Product product)
        {

            Product productToUpdate;


            //Gönderilen ürünün ıd'sine sahip nesnenin referansını bul.

            productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName = product.ProductName;

            productToUpdate.CategoryId = product.CategoryId;

            productToUpdate.UnitPrice = product.UnitPrice;

            productToUpdate.UnitsInStock = product.UnitsInStock;

        }





        //Where Sql'deki ile aynı çalışıyor şarta uyanları tekrar liste yapıp döndürüyor.
        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p=>p.CategoryId == categoryId).ToList();
        }


    }
}
