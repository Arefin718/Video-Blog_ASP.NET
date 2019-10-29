using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;
using YoutubeRepository.Class;
using YoutubeRepository.Interface;
using YoutubeService.Interface;

namespace YoutubeService.Class
{

    public class ReportService : Service<Report>, IReportService
    {
        ReportRepository reportRepo = new ReportRepository();

        public List<Channel> getAllChannelsReport()
        {
            return reportRepo.getAllChannelsReport();
        }

        public List<Video> getAllVideosReport()
        {
            return reportRepo.getAllVideosReport();
        }

        public List<Report> getAllVideosReportsById(int id)
        {
            return reportRepo.getAllVideosReportsById(id);
        }

        public List<Report> getChannelReportsById(int id)
        {
            return reportRepo.getChannelReportsById(id);
        }

        public int TotalReportByType(int id, string type)
        {
            return reportRepo.TotalReportByType(id, type);
        }
    }
}
