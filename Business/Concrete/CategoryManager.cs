using Business.Abstract;
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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var category = _categoryDal.Get(c => c.Id == id); 
            if (category == null)
            {
                return new ErrorResult("Kategori bulunamadı.");
            }

            _categoryDal.Delete(category);
            return new SuccessResult("Kategori başarıyla silindi.");
        }


        public IDataResult<List<Category>> GetAll()
        {
            var result = _categoryDal.GetAll();
            return new SuccessDataResult<List<Category>>(result, "Tüm ürünler listelendi.");

        }

        public IDataResult<Category> GetByIdCategory(int id)
        {
            var result = _categoryDal.Get(p => p.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Category>("Belirtilen ID'ye sahip ürün bulunamadı.");
            }
            return new SuccessDataResult<Category>(result, "Ürün başarıyla getirildi.");

        }

        public IResult Update(Category category)
        {
            var existingCategory = _categoryDal.Get(c => c.Id == category.Id); 
            if (existingCategory == null)
            {
                return new ErrorResult("Kategori bulunamadı.");
            }

            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;

            _categoryDal.Update(existingCategory);
            return new SuccessResult("Kategori başarıyla güncellendi.");
        }
    }
}
