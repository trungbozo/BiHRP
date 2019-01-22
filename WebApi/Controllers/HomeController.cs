using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Http;
using Model;
using Model.View;

namespace WebApi.Controllers
{
    public class HomeController<T> : ApiController
        where T : class
    {
        //public Bitecco db = new Bitecco();
        public Home<T> dataAccess = new Home<T>();
        public IQueryable<T> GetAll()
        {
            try
            {
                //return db.Set<T>();
                return dataAccess.GetAll().AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IHttpActionResult GetById(int primaryKey)
        {
            try
            {
                //var obj = db.Set<T>().Find(primaryKey);
                var obj = dataAccess.GetById(primaryKey);
                if (obj == null)
                {
                    return NotFound();
                }
                return Ok(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IHttpActionResult Post(T data)
        {
            try
            {
                //db.Set<T>().Add(data);
                //db.SaveChanges();
                if (dataAccess.Post(data))
                    return Ok(data);
                else
                    return NotFound();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IHttpActionResult Put(int primaryKey, T data)
        {
            try
            {
                if (dataAccess.Put(primaryKey, data))
                    return Ok(data);
                else
                    return NotFound();
                //var obj = db.Set<T>().Find(primaryKey);
                //if (obj == null)
                //{
                //    return NotFound();
                //}
                //else if (obj.Equals(data))
                //{
                //    return Ok(obj);
                //}
                //else if (data == null)
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    db.Entry(obj).State = EntityState.Detached;
                //    db.Entry(data).State = EntityState.Modified;
                //    db.SaveChanges();
                //}
                //return Ok(obj);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IHttpActionResult Delete(int primaryKey)
        {
            try
            {
                if (dataAccess.Delete(primaryKey))
                    return Ok();
                else
                    return NotFound();
                //var obj = db.Set<T>().Find(primaryKey);
                //if (obj == null)
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    db.Set<T>().Attach(obj);
                //    db.Set<T>().Remove(obj);
                //    db.SaveChanges();
                //    return Ok(obj);
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
        public bool IsExists(int primaryKey)
        {
            try
            {
                //return db.Set<T>().Find(primaryKey) == null ? false : true;
                return dataAccess.IsExists(primaryKey);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<FormData> GetAllDataForm(int primaryKey)
        {
            try
            {
                var obj = dataAccess.GetById(primaryKey);
                var type = obj.GetType();
                var properties = type.GetProperties();
                List<FormData> data = new List<FormData>();
                foreach (var item in properties)
                {
                    string nameControl = item.Name;
                    var value = item.GetValue(obj);
                    FormData form = new FormData();
                    form.NameControl = nameControl;
                    form.ValueControl = (value == null) ? "" : value.ToString();
                    data.Add(form);
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
