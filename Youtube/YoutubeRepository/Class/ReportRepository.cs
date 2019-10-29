using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;
using YoutubeRepository.Interface;

namespace YoutubeRepository.Class
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        DataContext context = new DataContext();
        public List<Channel> getAllChannelsReport()
        {
            var listOfReport = context.Reports.AsNoTracking().Where(r => r.Type == "channel").Select(x => x.ChannelId).Distinct();

            List<Channel> locr = new List<Channel>();

            foreach (var item in listOfReport)
            {
                Channel chnl = context.Channels.AsNoTracking().Include("User").SingleOrDefault(v => v.Id == item);
                locr.Add(chnl);
            }

            return locr;
        }

        public List<Report> getChannelReportsById(int id)
        {
            return context.Reports.Include("User").Include("Channel").Where(r => r.Type == "channel" && r.ChannelId == id).ToList();
        }

        public List<Video> getAllVideosReport()
        {
           var listOfReport = context.Reports.AsNoTracking().Where(r => r.Type == "video").Select(x => x.VideoId).Distinct();

           List<Video> loVdo = new List<Video>();

           foreach(var item in listOfReport)
            {
                Video vdo = context.Videos.AsNoTracking().Include("Channel").SingleOrDefault(v => v.Id == item);
                loVdo.Add(vdo);
            }

            return loVdo;

        }

        public List<Report> getAllVideosReportsById(int id)
        {
            return context.Reports.Include("User").Where(r => r.Type == "video" && r.VideoId == id).ToList();

        }

        public int TotalReportByType(int id, string type)
        {

            if (type == "video")
            {
                return context.Reports.AsNoTracking().Where(r => r.Type == "video" && r.VideoId==id).Count();
            }
            else
            {
            return context.Reports.AsNoTracking().Where(r => r.Type == "channel" && r.ChannelId==id).Count();

            }
        }
    }
}
