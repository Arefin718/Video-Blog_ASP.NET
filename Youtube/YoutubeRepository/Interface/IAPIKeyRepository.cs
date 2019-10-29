using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;

namespace YoutubeRepository.Interface
{
    public interface IAPIKeyRepository : IRepository<APIKey>
    {
        string GenerateClientId(int id);
        List<APIKey> GetKeysByUserId(int id);
        string GetRedirectURLByClientId(string id);
    }
}
