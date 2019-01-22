using Model;

namespace WebApi.Controllers.WS
{
    public class WS_SYS_FormController : HomeController<SYS_Form>
    {
        //public override IQueryable<SYS_Form> GetAll()
        //{
        //    try
        //    {
        //        return db.SYS_Form;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public override IQueryable<SYS_Form> GetAllById(int id)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public override IQueryable<SYS_Form> GetAllParent()
        //{
        //    throw new System.NotImplementedException();
        //}

        //public override IHttpActionResult GetById(int id)
        //{
        //    try
        //    {
        //        SYS_Form obj = db.SYS_Form.FirstOrDefault(x => x.ID_SYS_Form == id);
        //        if (obj == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(obj);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public override bool IsExists(int id)
        //{
        //    try
        //    {
        //        return (db.SYS_Form.Count() > 0) ? true : false;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public override IHttpActionResult Post(SYS_Form data)
        //{
        //    try
        //    {
        //        db.SYS_Form.Add(data);
        //        db.SaveChanges();
        //        return Ok(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public override IHttpActionResult Put(int id, SYS_Form data)
        //{
        //    try
        //    {
        //        SYS_Form obj = db.SYS_Form.FirstOrDefault(x => x.ID_SYS_Form == id);
        //        if (obj == null)
        //        {
        //            return NotFound();
        //        }
        //        else if (obj.Equals(data))
        //        {
        //            return Ok(obj);
        //        }
        //        else if (data == null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            db.SYS_Form.Attach(data);
        //            db.Entry(data).State = EntityState.Modified;
        //            db.SaveChanges();
        //        }
        //        return Ok(obj);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public override IHttpActionResult Delete(int id)
        //{

        //    try
        //    {
        //        SYS_Form obj = db.SYS_Form.FirstOrDefault(x => x.ID_SYS_Form == id);
        //        if (obj == null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            db.SYS_Form.Attach(obj);
        //            db.SYS_Form.Remove(obj);
        //            db.SaveChanges();
        //            return Ok(obj);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public override List<FormData> GetAllDataForm(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
