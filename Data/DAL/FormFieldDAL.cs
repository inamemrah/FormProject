using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.DAL
{
    public class FormFieldDAL
    {
        LenaDbContext dbContext = new LenaDbContext();

        public IEnumerable<FormField> Get()
        {
            return dbContext.Set<FormField>().ToList();
        }

        public FormField GetById(int FormId)
        {
            var result = (from formField in dbContext.FormFields
                          where formField.FormId == FormId
                          select formField).FirstOrDefault();

            return result;
        }

        public void Insert(FormField formField)
        {
            dbContext.Set<FormField>().Add(formField);
            dbContext.SaveChanges();
        }

        public void Update(FormField formField)
        {

        }

        public void Delete(FormField formField)
        {
            dbContext.Set<FormField>().Remove(formField);
            dbContext.SaveChanges();
        }
    }
}
