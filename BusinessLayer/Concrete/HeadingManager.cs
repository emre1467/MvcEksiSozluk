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
    public class HeadingManager : IHeadingService
    {
        private IHeadingDal headingDal;

        public HeadingManager(IHeadingDal _headingDal)
        {
            this.headingDal = _headingDal;
        }

        public List<Heading> GetAll()
        {
            return headingDal.GetAll();
        }

        public Heading getById(int id)
        {
            return headingDal.Get(x=>x.HeadingId== id); 
        }

        public void HeadingAdd(Heading heading)
        {
            headingDal.Add(heading);
        }

        public void HeadingRemove(Heading heading)
        {

            headingDal.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            headingDal.Update(heading);
        }
    }
}
