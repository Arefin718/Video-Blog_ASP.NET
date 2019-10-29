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
    public class UserService : Service<User>, IUserService
    {
        UserRepository repo = new UserRepository();

        public User GetUserByClientId(string id)
        {
           return  repo.GetUserByClientId(id);
        }

        public User Login(User user)
        {
            return repo.Login(user);
        }

        public List<User> NameStartWithS()
        {
            return this.repo.NameStartWithS();
        }
    }
}
