using Model;
using WebApi.Controllers;

namespace Administrator.Controllers.WS
{
    public class WS_SYS_TreeController : HomeController<SYS_Tree>
    {
        //private BiteccoEntities db = new BiteccoEntities();

        //// GET: api/WS_SYS_Tree
        //public IQueryable<SYS_Tree> GetSYS_Tree()
        //{
        //    return db.SYS_Tree;
        //}

        //// GET: api/WS_SYS_Tree/5
        //[ResponseType(typeof(SYS_Tree))]
        //public async Task<IHttpActionResult> GetSYS_Tree(int id)
        //{
        //    SYS_Tree sYS_Tree = await db.SYS_Tree.FindAsync(id);
        //    if (sYS_Tree == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(sYS_Tree);
        //}

        //// PUT: api/WS_SYS_Tree/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutSYS_Tree(int id, SYS_Tree sYS_Tree)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != sYS_Tree.ID_Tree)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(sYS_Tree).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SYS_TreeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/WS_SYS_Tree
        //[ResponseType(typeof(SYS_Tree))]
        //public async Task<IHttpActionResult> PostSYS_Tree(SYS_Tree sYS_Tree)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.SYS_Tree.Add(sYS_Tree);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = sYS_Tree.ID_Tree }, sYS_Tree);
        //}

        //// DELETE: api/WS_SYS_Tree/5
        //[ResponseType(typeof(SYS_Tree))]
        //public async Task<IHttpActionResult> DeleteSYS_Tree(int id)
        //{
        //    SYS_Tree sYS_Tree = await db.SYS_Tree.FindAsync(id);
        //    if (sYS_Tree == null)
        //    {
        //        return NotFound();
        //    }

        //    db.SYS_Tree.Remove(sYS_Tree);
        //    await db.SaveChangesAsync();

        //    return Ok(sYS_Tree);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool SYS_TreeExists(int id)
        //{
        //    return db.SYS_Tree.Count(e => e.ID_Tree == id) > 0;
        //}
        //public override IHttpActionResult Delete(int id)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public override IQueryable<SYS_Tree> GetAll()
        //{
        //    return db.SYS_Tree;
        //}

        //public override IQueryable<SYS_Tree> GetAllById(int id)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public override List<FormData> GetAllDataForm(int id)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public override IQueryable<SYS_Tree> GetAllParent()
        //{
        //    throw new System.NotImplementedException();
        //}

        //public override IHttpActionResult GetById(int id)
        //{
        //    SYS_Tree obj = db.SYS_Tree.FirstOrDefault(x => x.ID_SYS_Tree == id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(obj);
        //}

        //public override bool IsExists(int id)
        //{
        //    return (db.SYS_Tree.Count() > 0) ? true : false;
        //}
        //public override IHttpActionResult Post(SYS_Tree data)
        //{
        //    db.SYS_Tree.Add(data);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = data.ID_SYS_Tree }, data);
        //}

        //public override IHttpActionResult Put(int id, SYS_Tree data)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}