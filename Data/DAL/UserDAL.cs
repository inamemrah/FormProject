using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.DAL
{
    public class UserDAL
    {
        LenaDbContext dbContext = new LenaDbContext();

        public IEnumerable<User> Get()
        {
            return dbContext.Set<User>().ToList();
        }

        public User GetById(int id)
        {
            return dbContext.Set<User>().Find(id);
        }

        public void Insert(User user)
        {
            dbContext.Set<User>().Add(user);
            dbContext.SaveChanges();
        }

        public void Update(User user)
        {
            
        }

        public void Delete(User user)
        {
            dbContext.Set<User>().Remove(user);
            dbContext.SaveChanges();
        }

        public User LoginControl(string userName, string password)
        {
            var result = (from user in dbContext.Users
                          where user.Username == userName && user.Password == password
                          select user).FirstOrDefault();
            return result;
        }
    }
}
