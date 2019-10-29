using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;
using YoutubeRepository.Interface;

namespace YoutubeRepository.Class
{
    public class AdminRepository : Repository<User>, IAdminRepository
    {

        DataContext dbcontext = new DataContext();

        public int Insert(Admin entity)
        {
            throw new NotImplementedException();
        }

        public Admin Login(Admin admin)
        {
            Admin adminStatus = dbcontext.Admins.SingleOrDefault(u => u.Email == admin.Email && u.Password == admin.Password);
            return adminStatus;
        }

        public List<Admin> NameStartWithS()
        {
            return dbcontext.Admins.Where(u => u.Name.StartsWith("s")).ToList();
        }

        public int Update(Admin entity)
        {
            throw new NotImplementedException();
        }

        Admin IRepository<Admin>.Get(int id)
        {
            throw new NotImplementedException();
        }

        List<Admin> IRepository<Admin>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
