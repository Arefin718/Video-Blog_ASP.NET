using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;
using YoutubeRepository.Class;
using YoutubeService.Interface;

namespace YoutubeService.Class
{
    public class AdminService : Service<Admin>, IAdminService
    {
        AdminRepository repo = new AdminRepository();


        public Admin Login(Admin admin)
        {
            return repo.Login(admin);
        }

        public List<Admin> NameStartWithS()
        {
            return this.repo.NameStartWithS();
        }
    }
}
