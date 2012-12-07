using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Avisos.Dal;
using Avisos.Models.Abstract;

namespace Avisos.Models.Repos
{
    public class AvisoRepository : IAvisoRepository
    {
        private AvisoContext Context { get; set; }
        public AvisoRepository()
            : this(new AvisoContext())
        {
        }
        public AvisoRepository(AvisoContext db)
        {
            Context = db;
        }
        public Aviso Get(int id)
        {
            return Context.Avisos.SingleOrDefault(r => r.AvisoID == id);
        }

        public IQueryable<Aviso> GetAll()
        {
            return Context.Avisos.OrderByDescending(x => x.Created);
        }

        public IQueryable<Aviso> GetTop15()
        {
            return Context.Avisos.OrderByDescending(x => x.Created).Take(15);
        }

        public Aviso Add(Aviso aviso)
        {
            Context.Avisos.Add(aviso);
            Context.SaveChanges();
            return aviso;
        }
        public Aviso Update(Aviso aviso)
        {
            Context.Entry(aviso).State = EntityState.Modified;
            Context.SaveChanges();
            return aviso;
        }
        public void Delete(int id)
        {
            var aviso = Get(id);
            Context.Avisos.Remove(aviso);
        }
        public IEnumerable<Aviso> GetByType(AvisoType type)
        {
            return Context.Avisos.Where(r => r.Type == type);
        }

        public Contact AddContact(Contact contact)
        {
            Context.Contacts.Add(contact);
            Context.SaveChanges();
            return contact;
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return Context.Contacts;
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }



        public Contact GetContact(int id)
        {
            return Context.Contacts.SingleOrDefault(r => r.ContactID == id);
        }

        public Contact Add(Contact contact)
        {
            Context.Contacts.Add(contact);
            Context.SaveChanges();
            return contact;
        }

        public Contact Update(Contact contact)
        {
            Context.Entry(contact).State = EntityState.Modified;
            Context.SaveChanges();
            return contact;
        }

        public void DeleteContact(int id)
        {
            var contact = GetContact(id);
            Context.Contacts.Remove(contact);
        }
    }
}