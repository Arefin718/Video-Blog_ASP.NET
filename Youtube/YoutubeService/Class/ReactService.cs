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
    public class ReactService : Service<React>, IReactService
    {
        ReactRepository reactRepo = new ReactRepository();
        public int UpdateReact(int videoId, int userId)
        {
            return reactRepo.UpdateReact(videoId,userId);
        }

        public bool UserReactStatus(React react)
        {
            return reactRepo.UserReactStatus(react);
        }
    }
}
