using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;

namespace YoutubeService.Interface
{
    public interface IAPIKeyService : IService<APIKey>
    {
        string GenerateClientId(int id);
        List<APIKey> GetKeysByUserId(int id);
        string GetRedirectURLByClientId(string id);
    }
}
