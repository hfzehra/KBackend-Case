using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            var deletedUser = _userDal.Get(b => b.Id == user.Id);
            _userDal.Delete(deletedUser);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetByIdUser(int id)
        {
            var result = _userDal.Get(p => p.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<User>("Belirtilen ID'ye sahip ürün bulunamadı.");
            }
            return new SuccessDataResult<User>(result, "Ürün başarıyla getirildi.");

        }

        public IResult Update(User user)
        {
            var existingProduct = _userDal.Get(p => p.Id == user.Id);
            if (existingProduct == null)
            {
                return new ErrorResult("Güncellenecek ürün bulunamadı.");
            }
            _userDal.Update(user);
            return new SuccessResult("Ürün başarıyla güncellendi.");

        }
    }
}
