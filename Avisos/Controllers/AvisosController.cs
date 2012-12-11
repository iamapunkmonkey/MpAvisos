using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Avisos.Models;
using Avisos.Dal;
using Avisos.Models.Abstract;
using Twilio;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Avisos.Areas.API.Controllers
{
    public class AvisosController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();


        // GET api/Avisos
        public IEnumerable<Aviso> GetAvisoes()
        {
            return unitOfWork.AvisoRepository.GetTop15().AsEnumerable();
        }

        // GET api/Avisos/5
        public Aviso GetAviso(int id)
        {
            Aviso aviso = unitOfWork.AvisoRepository.Get(id);
            if (aviso == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return aviso;
        }



        // POST api/Avisos
        public HttpResponseMessage PostAviso(Contact contact)
        {
            if (ModelState.IsValid)
            {

                //Clean the phone numbers
                contact.Phone = clean(contact.Phone);

                var phones = unitOfWork.AvisoRepository.GetAllContacts().Select(c => c.Phone).Distinct();

                if (!phones.Contains(contact.Phone))
                {
                    Contact con = unitOfWork.AvisoRepository.AddContact(new Contact() { Phone = contact.Phone });
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, con);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = con.ContactID }));
                    SendWelcomeSMS(con);
                    return response;
                }
                else
                {
                    //Fail 409
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Conflict, 0);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = 0 }));
                    return response;
                }

            }
            else
            {
                //Fail 400
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/Avisos/5
        public void Put(int id, [FromBody]string value)
        {
            //Clean the phone numbers
            var phone = clean(id.ToString());
            Contact tempcontact = new Contact() { Phone = phone };

            CheckPhone(tempcontact);
                   
            var phones = unitOfWork.AvisoRepository.GetAllContacts().Select(c => c.Phone).Distinct();

            if (!phones.Contains(phone))
            {
                Contact con = unitOfWork.AvisoRepository.AddContact(new Contact() { Phone = phone });
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, con);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = con.ContactID }));
                SendWelcomeSMS(con);
            }
        }

        private void CheckPhone(Contact contact)
        {
            TestsHelper.ValidateObject(contact);
            if (ModelState.IsValid)
            {
                int i = 1;
            }
        }

        public static string clean(string s)
        {
            StringBuilder sb = new StringBuilder(s);

            sb.Replace("-", "");
            sb.Replace("(", "");
            sb.Replace(")", "");
            sb.Replace(".", "");
            sb.Replace(" ", "");

            return sb.ToString();
        }

        private void SendWelcomeSMS(Contact contact)
        {
            var twilio = new TwilioRestClient("AC8f7b487b784a61eb3f7e0441cf64c664", "be52390895ffefb6ad26ad94a40f9d85");
            var msg = twilio.SendSmsMessage("+17732426982", "+1" + contact.Phone, "You will now receive MiParque texts about happenings in the park. Text STOP to this number to stop getting texts.");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }

    class TestsHelper
    {

        internal static void ValidateObject<T>(T obj)
        {
            var type = typeof(T);
            var meta = type.GetCustomAttributes(false).OfType<MetadataTypeAttribute>().FirstOrDefault();
            if (meta != null)
            {
                type = meta.MetadataClassType;
            }
            var propertyInfo = type.GetProperties();
            foreach (var info in propertyInfo)
            {
                var attributes = info.GetCustomAttributes(false).OfType<ValidationAttribute>();
                foreach (var attribute in attributes)
                {
                    var objPropInfo = obj.GetType().GetProperty(info.Name);
                    attribute.Validate(objPropInfo.GetValue(obj, null), info.Name);
                }
            }
        }
    }
}