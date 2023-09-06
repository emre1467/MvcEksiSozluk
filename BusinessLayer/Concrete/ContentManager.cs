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
    public class ContentManager : IContentService
    {
        private IContentDal contentDal;

        public ContentManager(IContentDal contentDal)
        {
            this.contentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
           contentDal.Add(content);
        }

        public void ContentRemove(Content content)
        {
           
        }

        public void ContentUpdate(Content content)
        {
            contentDal.Update(content);
        }

        public List<Content> GetAll()
        {
            return contentDal.GetAll();
        }

        public Content getById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> getListByHeadingID(int id)
        {
            return contentDal.List(x=>x.HeadingId==id);
        }
    }
}
