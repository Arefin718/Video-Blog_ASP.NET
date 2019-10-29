using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;

namespace YoutubeRepository.Interface
{

    public interface IAdminRepository : IRepository<Admin>
    {
        List<Admin> NameStartWithS();
        Admin Login(Admin admin);
    }
}
