using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, AdminPanelContext>, IProductDal
    {
        public List<ProductListDTO> GetProductsWithCategory()
        {
            using (AdminPanelContext dto = new AdminPanelContext())
            {
               var result = from p in dto.Products
                            join c in dto.Categories
                            on p.CategoryId equals c.Id
                            select new ProductListDTO
                            { 
                                Id=p.Id,
                                Name=p.Name,
                                Description=p.Description,
                                Price=p.Price,
                                CategoryName = c.Name
                            };
                return result.ToList();
            }
        }
    }
}
