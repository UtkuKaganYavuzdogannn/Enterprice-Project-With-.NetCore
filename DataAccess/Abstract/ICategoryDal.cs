using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {

        //IEntityRep. yazdığımız ve veri işlemlerini orada belirttiğimiz için aynı
        //zamanda da T tipini Category olarak belirtip implemente ettiğimiz için bir şey yazmama gerek kalmadı.










    }
}
