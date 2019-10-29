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
    public class VideoService : Service<Video>, IVideoService
    {
        VideoRepository videoRepo = new VideoRepository();

        public void ChangeVideoApproval(int id)
        {
            videoRepo.ChangeVideoApproval(id);
        }

        public List<Video> GetAllVideosByClientId(string clientId)
        {
            return videoRepo.GetAllVideosByClientId(clientId);
        }

        public List<Video> GetAllWithDetails()
        {
            return videoRepo.GetAllWithDetails();
        }

        public List<Video> GetVideoByCatagory(string cat)
        {
            return videoRepo.GetVideoByCatagory(cat);
        }

        public List<Video> GetVideoByChannelId(int id)
        {
            return videoRepo.GetVideoByChannelId(id);
        }

        public Video GetVideoWithDetails(int id)
        {
            return videoRepo.GetVideoWithDetails(id);
        }

        public List<Video> SearchByName(string id)
        {
            return videoRepo.SearchByName(id);
        }

        public List<Video> TrendingVideos()
        {
            return videoRepo.TrendingVideos();
        }

        public void ViewCount(int id)
        {
            videoRepo.ViewCount(id);
        }
    }
}
