using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetAll();
        List<Heading> GetByWriterList(int id);
        void HeadingAdd(Heading heading);
        Heading getById(int  id);
        void HeadingRemove(Heading heading);
        void HeadingUpdate(Heading heading);

    }
}
