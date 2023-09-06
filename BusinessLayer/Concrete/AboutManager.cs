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
    public class AboutManager : IAboutService
    {
        private IAboutDal aboutDal;

        public AboutManager(IAboutDal _aboutDal)
        {
            aboutDal = _aboutDal;
        }

        public void AboutAdd(About about)
        {
            aboutDal.Add(about);
        }

        public void AboutDelete(About about)
        {
            aboutDal.Delete(about);
        }

        public void AboutUpdate(About about)
        {
            aboutDal.Update(about);
        }

        public List<About> GetAll()
        {
            return aboutDal.GetAll();
        }

        public About getById(int id)
        {
            return aboutDal.Get(x => x.AboutId == id);
        }
    }
}
