using Kendo.DynamicLinq;
using Newtonsoft.Json;
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
using WebApiClinic.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Kendo.DynamicLinq;

using Newtonsoft.Json;
using System.Net.Http.Formatting;

namespace WebApiClinic.Controllers
{
    public class ClinicTablesController : ApiController
    {
        private ClinicEntities db = new ClinicEntities();

        // GET: api/ClinicTables
        public DataSourceResult GetClinicTables(HttpRequestMessage requestMessage)
        {
            var request = JsonConvert.DeserializeObject<DataSourceRequest>(
               requestMessage.RequestUri.ParseQueryString().GetKey(0)
           );
            var list = ProductDataSource.LatestProducts;
            return list.AsQueryable().ToDataSourceResult(request.Take, request.Skip, request.Sort, request.Filter);
        }

        // GET: api/ClinicTables/5
        [ResponseType(typeof(ClinicTable))]
        public IHttpActionResult GetClinicTable(int id)
        {
            ClinicTable clinicTable = db.ClinicTables.Find(id);
            if (clinicTable == null)
            {
                return NotFound();
            }

            return Ok(clinicTable);
        }

        // PUT: api/ClinicTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClinicTable(int id, ClinicTable clinicTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clinicTable.Id)
            {
                return BadRequest();
            }

            db.Entry(clinicTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClinicTableExists(id))
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

        // POST: api/ClinicTables
        [ResponseType(typeof(ClinicTable))]
        public IHttpActionResult PostClinicTable(ClinicTable clinicTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClinicTables.Add(clinicTable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = clinicTable.Id }, clinicTable);
        }

        // DELETE: api/ClinicTables/5
        [ResponseType(typeof(ClinicTable))]
        public HttpResponseMessage DeleteClinicTable(int id)
        {
            var item = ProductDataSource.LatestProducts.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            db.Entry(item).State = EntityState.Deleted;
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClinicTableExists(int id)
        {
            return db.ClinicTables.Count(e => e.Id == id) > 0;
        }
    }
}