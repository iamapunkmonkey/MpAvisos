﻿using Ninject;
using Ninject.Activation;
using Ninject.Parameters;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Avisos.Models.Abstract
{
    public interface IAvisoRepository
    {
        Aviso Get(int id);
        IQueryable<Aviso> GetAll();
        IQueryable<Aviso> GetTop15();
        Aviso Add(Aviso aviso);
        Aviso Update(Aviso aviso);
        void Delete(int id);
        IEnumerable<Aviso> GetByType(AvisoType type);

        Contact GetContact(int id);
        Contact Add(Contact aviso);
        Contact Update(Contact aviso);
        void DeleteContact(int id);
        IEnumerable<Contact> GetAllContacts();
        Contact AddContact (Contact contact);

    }

}