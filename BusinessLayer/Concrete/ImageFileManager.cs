using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        private IImageDal ımageDal;

        public ImageFileManager(IImageDal ımageDal)
        {
            this.ımageDal = ımageDal;
        }

        public List<ImageFile> GetAll()
        {
           return ımageDal.GetAll();
        }
    }
}
