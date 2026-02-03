﻿using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {

        Task<IDataResult<List<Product>>> GetAllAsync();
        Task<IDataResult<Product>> GetByIdProductAsync(int id);
        Task<IResult> AddAsync(Product product);
        Task<IResult> DeleteAsync(int id);
        Task<IResult> UpdateAsync(Product product);
    }
}
