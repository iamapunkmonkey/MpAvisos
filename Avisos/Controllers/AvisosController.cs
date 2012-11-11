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

namespace Avisos.Areas.API.Controllers
{
    public class AvisosController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();


        // GET api/Avisos
        public IEnumerable<Aviso> GetAvisoes()
        {
            return unitOfWork.AvisoRepository.GetAll().AsEnumerable();
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

        

        //// POST api/Avisos
        //public HttpResponseMessage PostAviso(Aviso aviso)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Avisos.Add(aviso);
        //        db.SaveChanges();

        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, aviso);
        //        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = aviso.AvisoID }));
        //        return response;
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //}

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}