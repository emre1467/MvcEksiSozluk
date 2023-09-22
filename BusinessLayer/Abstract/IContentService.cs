using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetAll();
        List<Content> GetListSearch(string p);
        void ContentAdd(Content content);
        void ContentRemove(Content content);
        void ContentUpdate(Content content);
        Content getById(int id);
        List<Content> getListByHeadingID(int id);
        List<Content> getListByWriter(int id);
    }
}
