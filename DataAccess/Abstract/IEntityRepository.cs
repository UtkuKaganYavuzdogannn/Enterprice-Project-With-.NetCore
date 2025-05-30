using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{

    //Generic Constraint

    //Class yazısı class olabilir anlamında değil referans tip olabilir demek
    //Constrait ile IEntity veya onu implement eden bir sınıf, T türü olabilir şeklinde tanımladık. 
    // new() yazısı ise T türünün nesnesi üretilebilir olması gerektiğini belirtir.
    // Böylece IEntityRepository<T> için T bir IEntity olamaz onu implemete eden bir sınıf olabilir.
    public interface IEntityRepository<T> where T: class, IEntity, new()
    {

        List<T> GetAll(Expression<Func<T, bool>> filter = null);


        T Get(Expression<Func<T, bool>> filter);


        void Add(T entity);

        void Update(T entity);


        void Delete(T entity);
 

    }
}
