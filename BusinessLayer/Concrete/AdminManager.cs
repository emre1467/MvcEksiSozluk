using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        private IAdminDal adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            this.adminDal = adminDal;
        }

        public void Add(Admin admin)
        {
           adminDal.Add(admin);
        }

        public void Delete(Admin admin)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetAll()
        {
            return adminDal.GetAll();
        }

        public Admin GetByd(int id)
        {
            throw new NotImplementedException();
        }

        public Admin GetById(int id)
        {
            return adminDal.Get(x => x.AdminId == id);
        }

        public Admin GetByUserNameandPassword(string userName, string password)
        {
            return adminDal.Get(x=>x.AdminUserName==userName && x.AdminPassword==password);
        }
    }
}
