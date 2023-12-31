﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetAll();
        void ContactAdd(Contact contact);
        void ContactRemove(Contact contact);
        void ContactUpdate(Contact contact);
        Contact getById(int id);
    }
}
