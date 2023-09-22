using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetAll();
        void WriterAdd(Writer writer);
        void WriterRemove(Writer writer);
        void WriterUpdate(Writer writer);
        Writer GetById(int id);
        Writer GetByUserNameandPassword(string userName, string password);

    }
}
