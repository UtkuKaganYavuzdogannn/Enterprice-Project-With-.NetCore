﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IProductService
    {

        List<Product> GetAll();

        List<Product> GetAllByCategoryId(int id);

        List<Product> GetAllByCategoryId(decimal min, decimal max);



    }
}
