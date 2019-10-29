using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;

namespace YoutubeService.Interface
{
    public interface IAdminService : IService<Admin>
    {
        List<Admin> NameStartWithS();

        Admin Login(Admin admin);
    }
}

