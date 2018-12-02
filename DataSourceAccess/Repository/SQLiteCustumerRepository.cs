using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataSourceAccess
{
    public class SQLiteCustumerRepository : IRepository<Custumer>
    {
        private ExchangeOfficeContext db;
        private bool disposed = false;

        public SQLiteCustumerRepository()
        {
            db = new ExchangeOfficeContext();
        }
        public IEnumerable<Custumer> GetList()
        {
            return db.Custumers;
        }

        public Custumer Get(int id)
        {
            return db.Custumers.Find(id);
        }

        public void Create(Custumer item)
        {
            db.Custumers.Add(item);
        }

        public void Update(Custumer item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var custumer = db.Custumers.Find(id);
            if (custumer != null)
            {
                db.Custumers.Remove(custumer);
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
        
        public virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}