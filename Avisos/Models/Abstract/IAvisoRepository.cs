using Ninject;
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
        Aviso Add(Aviso aviso);
        Aviso Update(Aviso aviso);
        void Delete(int id);
        IEnumerable<Aviso> GetByType(AvisoType type);

        IEnumerable<Contact> GetAllContacts();
        Contact AddContact (Contact contact);

    }

}