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
using FlutterWebAPI.Models;

namespace FlutterWebAPI.Controllers
{
    public class UserController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/User
        public IQueryable<tblFlutterUser> GettblFlutterUsers()
        {
            return db.tblFlutterUsers;
        }

        // GET: api/User/5
        [ResponseType(typeof(tblFlutterUser))]
        public IHttpActionResult GettblFlutterUser(int id)
        {
            tblFlutterUser tblFlutterUser = db.tblFlutterUsers.Find(id);
            if (tblFlutterUser == null)
            {
                return NotFound();
            }

            return Ok(tblFlutterUser);
        }

        // PUT: api/User/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblFlutterUser(int id, tblFlutterUser tblFlutterUser)
        {
            

            if (id != tblFlutterUser.id)
            {
                return BadRequest();
            }

            db.Entry(tblFlutterUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblFlutterUserExists(id))
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

        // POST: api/User
        [ResponseType(typeof(tblFlutterUser))]
        public IHttpActionResult PosttblFlutterUser(tblFlutterUser tblFlutterUser)
        {
            

            db.tblFlutterUsers.Add(tblFlutterUser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblFlutterUser.id }, tblFlutterUser);
        }

        // DELETE: api/User/5
        [ResponseType(typeof(tblFlutterUser))]
        public IHttpActionResult DeletetblFlutterUser(int id)
        {
            tblFlutterUser tblFlutterUser = db.tblFlutterUsers.Find(id);
            if (tblFlutterUser == null)
            {
                return NotFound();
            }

            db.tblFlutterUsers.Remove(tblFlutterUser);
            db.SaveChanges();

            return Ok(tblFlutterUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblFlutterUserExists(int id)
        {
            return db.tblFlutterUsers.Count(e => e.id == id) > 0;
        }
    }
}