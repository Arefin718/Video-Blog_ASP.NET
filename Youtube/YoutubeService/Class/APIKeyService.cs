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
    public class APIKeyService : Service<APIKey>, IAPIKeyService
    {
        APIKeyRepository apRepo = new APIKeyRepository();
        public string GenerateClientId(int id)
        {
            return apRepo.GenerateClientId(id);
        }

        public List<APIKey> GetKeysByUserId(int id)
        {
            return apRepo.GetKeysByUserId(id);
        }

        public string GetRedirectURLByClientId(string id)
        {
            return apRepo.GetRedirectURLByClientId(id);
        }
    }
}
