using Model.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace Model
{
    public class Home<T> 
        where T : class
    {
        public Bitecco db = new Bitecco();
        public IEnumerable<T> GetAll()
        {
            try
            {
                return db.Set<T>().AsEnumerable().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public T GetById(int primaryKey)
        {
            try
            {
                var obj = db.Set<T>().Find(primaryKey);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Post(T data)
        {
            try
            {
                db.Set<T>().Add(data);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Put(int primaryKey, T data)
        {
            try
            {
                var obj = db.Set<T>().Find(primaryKey);
                if (obj == null)
                {
                    return false;
                }
                else if (obj.Equals(data))
                {
                    return false;
                }
                else if (data == null)
                {
                    return false;
                }
                else
                {
                    db.Entry(obj).State = EntityState.Detached;
                    db.Entry(data).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(int primaryKey)
        {
            try
            {
                var obj = db.Set<T>().Find(primaryKey);
                if (obj == null)
                {
                    return false;
                }
                else
                {
                    db.Set<T>().Attach(obj);
                    db.Set<T>().Remove(obj);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool IsExists(int primaryKey)
        {
            try
            {
                return db.Set<T>().Find(primaryKey) == null ? false : true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
