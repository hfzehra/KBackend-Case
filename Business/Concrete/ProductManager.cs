using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryDal _categoryDal;
        public ProductManager(IProductDal productDal, ICategoryDal categoryDal)
        {
            _productDal = productDal;
            _categoryDal = categoryDal;
        }
        public IResult Add(Product product)
        {
            // Kategori varlığını kontrol et
            var categoryExists = _categoryDal.Get(c => c.Id == product.CategoryId);
            if (categoryExists == null)
            {
                return new ErrorResult("Geçerli bir kategori bulunamadı. Ürün eklenemedi.");
            }

            _productDal.Add(product);
            return new SuccessResult("Ürün başarıyla eklendi.");
        }


        public IResult Delete(int id)
        {
            var product = _productDal.Get(c => c.Id == id);
            if (product == null)
            {
                return new ErrorResult("Kategori bulunamadı.");
            }

            _productDal.Delete(product);
            return new SuccessResult("Kategori başarıyla silindi.");
        }

        public IDataResult<List<Product>> GetAll()
        {
            var result = _productDal.GetAll();
            return new SuccessDataResult<List<Product>>(result, "Tüm ürünler listelendi.");

        }

        public IDataResult<Product> GetByIdProduct(int id)
        {
            var result = _productDal.Get(p => p.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Product>("Belirtilen ID'ye sahip ürün bulunamadı.");
            }
            return new SuccessDataResult<Product>(result, "Ürün başarıyla getirildi.");

        }

        public IResult Update(Product product)
        {
            var existingProduct = _productDal.Get(p => p.Id == product.Id);
            if (existingProduct == null)
            {
                return new ErrorResult("Ürün bulunamadı");
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;

            _productDal.Update(existingProduct);
            return new SuccessResult("Ürün başarıyla güncellendi");
        }

        public List<ProductListDTO> GetProductsWithCategory()
        {
            return _productDal.GetProductsWithCategory();
        }

    }
}
