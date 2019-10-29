using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;

namespace YoutubeService.Interface
{
    public interface IUserService : IService<User>
    {
        List<User> NameStartWithS();
        User Login(User user);
        User GetUserByClientId(string id);
    }
}
