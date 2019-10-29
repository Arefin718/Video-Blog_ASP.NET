using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;
using YoutubeRepository.Interface;

namespace YoutubeRepository.Class
{
    public class APIKeyRepository : Repository<APIKey>, IAPIKeyRepository
    {
        DataContext context = new DataContext();

        Repository<APIKey> apRespository = new Repository<APIKey>();
        public string GenerateClientId(int id)
        {
           

            APIKey apk = context.APIKeys.SingleOrDefault(a=>a.UserId==id);
            if (apk == null)
            {

                string hash;

                using (var md5 = System.Security.Cryptography.MD5.Create())
                {
                    hash = String.Concat(md5.ComputeHash(BitConverter
                      .GetBytes(id))
                      .Select(x => x.ToString("x2")));
                }

                APIKey apkey = new APIKey();
                apkey.UserId = id;
                apkey.ClientId = hash;

                apRespository.Insert(apkey);
                return apkey.ClientId;

            }
            else
            {
                return apk.ClientId;
            }
        }

        public List<APIKey> GetKeysByUserId(int id)
        {
            return context.APIKeys.AsNoTracking().Where(a => a.UserId == id).ToList();
        }

        public string GetRedirectURLByClientId(string id)
        {
            APIKey apk = context.APIKeys.SingleOrDefault(a=>a.ClientId == id);

            return apk.RedirectURL;
        }
    }
}
