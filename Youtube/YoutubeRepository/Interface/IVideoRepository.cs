using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;

namespace YoutubeRepository.Interface
{
    public interface IVideoRepository : IRepository<Video>
    {
        List<Video> GetVideoByChannelId(int id);
        List<Video> GetAllWithDetails();

        List<Video> GetVideoByCatagory(string cat);
        void ViewCount(int id);

        Video GetVideoWithDetails(int id);

        List<Video> SearchByName(string id);

        List<Video> GetAllVideosByClientId(string clientId);
        void ChangeVideoApproval(int id);
        List<Video> TrendingVideos();
    }
}
