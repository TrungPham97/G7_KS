using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using System.Configuration;


namespace Model.Dao
{
    public class UserDao
    {
        QLKSDbContext db = null;
        public UserDao()
        {
            db = new QLKSDbContext();
        }

        public int Insert(ADMIN entity)
        {
            db.ADMINs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(ADMIN entity)
        {
            try
            {
                var user = db.ADMINs.Find(entity.ID);
                user.Password = entity.Password;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }
        }

        public IEnumerable<ADMIN> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ADMIN> model = db.ADMINs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString));
            }
            return db.ADMINs.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);

        }



        public ADMIN GetById(string userName)
        {
            return db.ADMINs.SingleOrDefault(x => x.UserName == userName);
        }

        public ADMIN ViewDetail(int id)
        {
            return db.ADMINs.Find(id);
        }

        public int Login(string userName, string passWord)
        {
            var result = db.ADMINs.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Password == passWord)
                    return 1;
                else
                    return -1;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.ADMINs.Find(id);
                db.ADMINs.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool CheckUserName(string userName)
        {
            return db.ADMINs.Count(x => x.UserName == userName) > 0;
        }

    }
}
