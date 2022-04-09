using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using XinCataLogAPI.Models;

namespace XinCataLogAPI.Controllers
{
    public class XinComicsController : ApiController
    {
        private XinCataLogEntities db = new XinCataLogEntities();

        // GET: api/XinComics
        public IQueryable<XinComic> GetXinComic()
        {
            return db.XinComic;
        }

        // GET: api/XinComics/5
        [ResponseType(typeof(XinComic))]
        public IHttpActionResult GetXinComic(int id)
        {
            XinComic xinComic = db.XinComic.Find(id);
            if (xinComic == null)
            {
                return NotFound();
            }

            return Ok(xinComic);
        }

        // PUT: api/XinComics/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutXinComic(int id, XinComic xinComic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != xinComic.Id)
            {
                return BadRequest();
            }

            db.Entry(xinComic).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!XinComicExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/XinComics
        [ResponseType(typeof(XinComic))]
        public IHttpActionResult PostXinComic(XinComic xinComic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.XinComic.Add(xinComic);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = xinComic.Id }, xinComic);
        }

        // DELETE: api/XinComics/5
        [ResponseType(typeof(XinComic))]
        public IHttpActionResult DeleteXinComic(int id)
        {
            XinComic xinComic = db.XinComic.Find(id);
            if (xinComic == null)
            {
                return NotFound();
            }

            db.XinComic.Remove(xinComic);
            db.SaveChanges();

            return Ok(xinComic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool XinComicExists(int id)
        {
            return db.XinComic.Count(e => e.Id == id) > 0;
        }
    }
}