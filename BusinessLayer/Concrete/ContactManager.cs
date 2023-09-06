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
    public class ContactManager : IContactService
    {
        private IContactDal contactDal;

        public ContactManager(IContactDal _contactDal)
        {
            contactDal = _contactDal;
        }

        public void ContactAdd(Contact contact)
        {
            contactDal.Add(contact);
        }

        public void ContactRemove(Contact contact)
        {
            contactDal.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            contactDal.Update(contact);
        }

        public List<Contact> GetAll()
        {
            return contactDal.GetAll();
        }

        public Contact getById(int id)
        {
            return contactDal.Get(x => x.ContactId == id);
        }
    }
}
