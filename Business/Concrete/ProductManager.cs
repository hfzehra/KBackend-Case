﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using Entity.Concrete;
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
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public IResult Add(Product product)
        {

            _productDal.Add(product);
            return new SuccessResult("Ürün başarıyla eklendi.");
        }


        public IResult Delete(int id)
        {
            var product = _productDal.Get(c => c.Id == id);
            if (product == null)
            {
                return new ErrorResult("Ürün bulunamadı.");
            }

            _productDal.Delete(product);
            return new SuccessResult("Ürün başarıyla silindi.");
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

        // Async Methods
        public async Task<IResult> AddAsync(Product product)
        {
            await _productDal.AddAsync(product);
            return new SuccessResult("Ürün başarıyla eklendi.");
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var product = await _productDal.GetAsync(c => c.Id == id);
            if (product == null)
            {
                return new ErrorResult("Ürün bulunamadı.");
            }

            await _productDal.DeleteAsync(product);
            return new SuccessResult("Ürün başarıyla silindi.");
        }

        public async Task<IDataResult<List<Product>>> GetAllAsync()
        {
            var result = await _productDal.GetAllAsync();
            return new SuccessDataResult<List<Product>>(result, "Tüm ürünler listelendi.");
        }

        public async Task<IDataResult<Product>> GetByIdProductAsync(int id)
        {
            var result = await _productDal.GetAsync(p => p.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Product>("Belirtilen ID'ye sahip ürün bulunamadı.");
            }
            return new SuccessDataResult<Product>(result, "Ürün başarıyla getirildi.");
        }

        public async Task<IResult> UpdateAsync(Product product)
        {
            var existingProduct = await _productDal.GetAsync(p => p.Id == product.Id);
            if (existingProduct == null)
            {
                return new ErrorResult("Ürün bulunamadı");
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;

            await _productDal.UpdateAsync(existingProduct);
            return new SuccessResult("Ürün başarıyla güncellendi");
        }
    }
}
