using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetAll();
        void Add(Admin admin);
        void Delete(Admin admin);
        Admin GetByd(int id);
        Admin GetByUserNameandPassword(string userName, string password);
    }
}
