using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDisposable pattern implementation of c# araştır.
            // using bloğunu çift tabla açabiliriz. Ayrıca bu blok garbage collectorü hızlıca çalıştırıyor.

            using (NorthwindContext context = new NorthwindContext())
            {

                var addedEntity = context.Entry(entity);

                addedEntity.State = EntityState.Added;

                context.SaveChanges();

            }

        }


        // Silme
        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                var deletedEntity = context.Entry(entity);

                deletedEntity.State = EntityState.Deleted;

                context.SaveChanges();

            }
        }


        //Getir
        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())

            {
                // SingleOrDefault: Sadece bir tane varsa onu getirir, yoksa null döner. Eğer birden fazla varsa hata fırlatır.

                return context.Set<Product>().SingleOrDefault(filter); 
            }
            
        }



           // Hepsini getir
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
               return filter == null ? context.Set<Product>().ToList() //true
                                     : context.Set<Product>().Where(filter).ToList(); // false

            }
        }


        //Güncelleme
        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                var uptadedEntity = context.Entry(entity);

                uptadedEntity.State = EntityState.Modified;

                context.SaveChanges();

            }
        }
    }
}
