using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.DAL
{
    public class FormDAL
    {
        LenaDbContext dbContext = new LenaDbContext();

        public IEnumerable<Form> Get()
        {
            return dbContext.Set<Form>().ToList();
        }

        public Form GetById(int id)
        {
            return dbContext.Set<Form>().Find(id);
        }

        public void Insert(Form form)
        {
            dbContext.Set<Form>().Add(form);
            dbContext.SaveChanges();
        }

        public void Update(Form form)
        {

        }

        public void Delete(Form form)
        {
            dbContext.Set<Form>().Remove(form);
            dbContext.SaveChanges();
        }
    }
}
