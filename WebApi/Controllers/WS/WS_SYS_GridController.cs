using System.Data;
using System.Linq;
using System.Web.Http;
using WebApi.Controllers;
using Model;
using System.Collections.Generic;

namespace Administrator.Controllers.WS
{
    //[RoutePrefix("bitecco/WS_SYS_Grid")]
    public class WS_SYS_GridController : HomeController<SYS_Grid>
    {
        //private BiteccoEntities db = new BiteccoEntities();
        //[Route("GetByForm/{id}")]
        //// GET: api/WS_SYS_Grid
        //public IQueryable<SYS_Grid> GetSYS_GridByForm(int id)
        //{
        //    return db.SYS_Grid.Where(x => x.ID_Form == id).OrderBy(x => x.OrderBy);
        //}

        //// GET: api/WS_SYS_Grid/5
        //[ResponseType(typeof(SYS_Grid))]
        //public IHttpActionResult GetSYS_Grid(int id)
        //{
        //    SYS_Grid sYS_Grid =  db.SYS_Grid.FirstOrDefault(x => x.ID_Grid == id);
        //    if (sYS_Grid == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(sYS_Grid);
        //}

        //// PUT: api/WS_SYS_Grid/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutSYS_Grid(int id, SYS_Grid sYS_Grid)
        //{
        //    if (id != sYS_Grid.ID_Grid)
        //    {
        //        return BadRequest();
        //    }

        //    var dpt = db.SYS_Grid.Find(sYS_Grid.ID_Grid);
        //    db.Entry(dpt).State = EntityState.Modified;
        //    db.Entry(dpt).CurrentValues.SetValues(sYS_Grid);
        //    db.SaveChanges();
        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/WS_SYS_Grid
        //[ResponseType(typeof(SYS_Grid))]
        //public IHttpActionResult PostSYS_Grid(SYS_Grid sYS_Grid)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.SYS_Grid.Add(sYS_Grid);
        //    //await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = sYS_Grid.ID_Grid }, sYS_Grid);
        //}

        //// DELETE: api/WS_SYS_Grid/5
        //[ResponseType(typeof(SYS_Grid))]
        //public IHttpActionResult DeleteSYS_Grid(int id)
        //{
        //    var dpt = db.SYS_Grid.Find(id);
        //    if (dpt == null)
        //    {
        //        return NotFound();
        //    }

        //    db.SYS_Grid.Remove(dpt);
        //    //await db.SaveChangesAsync();

        //    return Ok(dpt);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool SYS_GridExists(int id)
        //{
        //    return db.SYS_Grid.Count(e => e.ID_Grid == id) > 0;
        //}
        //public override IHttpActionResult Delete(int id)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public override IQueryable<SYS_Grid> GetAll()
        //{
        //    return db.SYS_Grid;
        //}

        [Route("bitecco/WS_SYS_Grid/GetAllByForm/{idForm}")]
        public IQueryable<SYS_Grid> GetAllByForm(int idForm)
        {
            return dataAccess.GetAll().Where(x => x.ID_Form == idForm).OrderBy(x => x.OrderBy).AsQueryable();
            //return db.SYS_Grid.Where(x => x.ID_Form == idForm).OrderBy(x => x.OrderBy);
        }

        //public override List<FormData> GetAllDataForm(int id)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public override IQueryable<SYS_Grid> GetAllParent()
        //{
        //    throw new System.NotImplementedException();
        //}

        //public override IHttpActionResult GetById(int id)
        //{
        //    SYS_Grid obj = db.SYS_Grid.FirstOrDefault(x => x.ID_SYS_Grid == id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(obj);
        //}

        //public override bool IsExists(int id)
        //{
        //    return (db.SYS_Menu.Count() > 0) ? true : false;
        //}

        //public override IHttpActionResult Post(SYS_Grid data)
        //{
        //    db.SYS_Grid.Add(data);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = data.ID_SYS_Grid }, data);
        //}

        //public override IHttpActionResult Put(int id, SYS_Grid data)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}