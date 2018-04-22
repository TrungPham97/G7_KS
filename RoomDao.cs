using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class RoomDao
    {
        QLKSDbContext db = null;
        public RoomDao()
        {
            db = new QLKSDbContext();
        }

        public int Insert(string tenPhong,string MaloaiPhong,string Tinhtrang)
        {
            object[] sqlParams =
            {
                new SqlParameter("@TenPhong", tenPhong),
            new SqlParameter("@MaLoaiPhong",MaloaiPhong),
            new SqlParameter("@TinhTrang", Tinhtrang)
            };
            int res = db.Database.ExecuteSqlCommand("usp_InsertRoom @TinhTrang,@MaLoaiPhong,@TenPhong", sqlParams);
            return res;
        }

        public bool Update(Room entity)
        {
            try
            {
                var room = db.Rooms.Find(entity.MaPhong);
                room.TinhTrang = entity.TinhTrang;
                room.MaLoaiPhong = entity.MaLoaiPhong;
                room.TenPhong = entity.TenPhong;
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public IEnumerable<Room> ListAllPaging(string searchString,int page=1,int pageSize=50)
        {
            IQueryable<Room> model = db.Rooms;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenPhong.Contains(searchString));
            }
            return db.Rooms.OrderByDescending(x => x.MaPhong).ToPagedList(page, pageSize);
        }

        public Room GetById(string maPhong)
        {
            return db.Rooms.SingleOrDefault(x => x.MaPhong == maPhong);
        }

        public Room ViewDetail(string maPhong)
        {
            return db.Rooms.SingleOrDefault(x=>x.TenPhong == maPhong);
        }

        public bool Delete(int maPhong)
        {
            try
            {
                var rom = db.Rooms.Find(maPhong);
                db.Rooms.Remove(rom);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
