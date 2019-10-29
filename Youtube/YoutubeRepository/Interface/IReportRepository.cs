using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;

namespace YoutubeRepository.Interface
{
    public interface IReportRepository
    {
        List<Channel> getAllChannelsReport();
        List<Report> getChannelReportsById(int id);

        List<Video> getAllVideosReport();
        List<Report> getAllVideosReportsById(int id);
        int TotalReportByType(int id, string type);
    }
}
