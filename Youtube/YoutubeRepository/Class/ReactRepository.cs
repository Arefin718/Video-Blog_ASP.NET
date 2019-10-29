using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;
using YoutubeRepository.Interface;

namespace YoutubeRepository.Class
{
    public class ReactRepository : Repository<React>, IReactRepository
    {
        DataContext context = new DataContext();
        Repository<React> reactRepo = new Repository<React>();

        public int UpdateReact(int videoId, int userId)
        {
            React toBeInserted = new React();
            toBeInserted.VideoId = videoId;
            toBeInserted.UserId = userId;

            React react = context.Reacts.SingleOrDefault(r => r.UserId == userId && r.VideoId == videoId);

            if (react == null)
            {
                reactRepo.Insert(toBeInserted);

            }
            else
            {
                reactRepo.Delete(react.Id);
            }

            return context.Reacts.Where(r => r.VideoId == videoId).Count();

        }

        public bool UserReactStatus(React react)
        {
            React rct = context.Reacts.SingleOrDefault(r => r.UserId == react.UserId && r.VideoId == react.VideoId);

            if (rct == null)
            {
                return false;

            }
            else
            {
                return true;
            }
        }
    }
}
