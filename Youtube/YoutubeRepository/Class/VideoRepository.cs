using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;
using YoutubeRepository.Interface;

namespace YoutubeRepository.Class
{
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        DataContext dataContext = new DataContext();

        Repository<Video> videoRepo = new Repository<Video>();

        public void ChangeVideoApproval(int id)
        {
            Video vdo = dataContext.Videos.SingleOrDefault(u => u.Id == id);

            if (vdo.Approve == 0)
            {
            vdo.Approve = 1;
            }
            else
            {
               vdo.Approve = 0;
            }

            videoRepo.Update(vdo);
        }

        public List<Video> GetAllVideosByClientId(string clientId)
        {
            APIKey apk = dataContext.APIKeys.SingleOrDefault(a => a.ClientId == clientId);

            List<Channel> loChannel = dataContext.Channels.Where(u => u.UserId == apk.UserId).ToList();

            List<Video> loVideo = new List<Video>();

            List<Video> allVideo = dataContext.Videos.Select(v => v).ToList();

            foreach(var item in loChannel)
            {
                foreach(var alv in allVideo)
                {
                    if (alv.ChannelId == item.Id)
                    {
                        loVideo.Add(alv);
                    }
                }

            }

            return loVideo;

        }

        public List<Video> GetAllWithDetails()
        {
            return dataContext.Videos.Include("Channel").AsNoTracking().Where(v=>v.Status==1 && v.Approve==1).ToList();
        }

        public List<Video> GetVideoByCatagory(string cat)
        {
            return dataContext.Videos.Include("Channel").AsNoTracking().Where(v=>v.Type.ToLower()==cat && v.Approve == 1 && v.Status == 1).ToList();
        }

        public List<Video> GetVideoByChannelId(int id)
        {
            return dataContext.Videos.Include("Channel").AsNoTracking().Where(v => v.ChannelId == id && v.Approve == 1).ToList();
        }

        public Video GetVideoWithDetails(int id)
        {

            return dataContext.Videos.Include("Channel").AsNoTracking().SingleOrDefault(v => v.Id == id && v.Approve==1);
        }

        public List<Video> SearchByName(string term)
        {
            return dataContext.Videos.Where(v => v.Title.ToLower().Contains(term) && v.Approve==1 && v.Status==1).ToList();
        }

        public List<Video> TrendingVideos()
        {
            return dataContext.Videos.Include("Channel").AsNoTracking().OrderByDescending(u => u.ViewCount).Where(v => v.Status == 1 && v.Approve == 1).ToList();
        }

        public void ViewCount(int id)
        {
           Video vdo= dataContext.Videos.SingleOrDefault(u => u.Id == id);
           vdo.ViewCount = vdo.ViewCount + 1;
           dataContext.Set<Video>().AddOrUpdate(vdo);
           dataContext.SaveChanges();
        }
    }
}
