using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;
using YoutubeRepository.Interface;

namespace YoutubeRepository.Class
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        DataContext dbcontext = new DataContext();

        public User GetUserByClientId(string id)
        {
            APIKey apk = dbcontext.APIKeys.SingleOrDefault(a => a.ClientId == id);
            User usr = dbcontext.Users.SingleOrDefault(u => u.Id == apk.UserId);
            return usr;
        }

        public User Login(User user)
        {
            User userStatus = dbcontext.Users.SingleOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            return userStatus; 
        }

        public List<User> NameStartWithS()
        {
            return  dbcontext.Users.Where(u => u.Name.StartsWith("s")).ToList();
        }
    }
}
