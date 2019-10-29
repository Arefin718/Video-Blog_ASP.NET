using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Youtube.App_Start;
using Youtube.Models;
using YoutubeEntity.Class;
using YoutubeService.Interface;

namespace Youtube.Controllers
{
    public class ReportController : Controller
    {
        IReportService reportService;
        IVideoService videoService;
        ISubscriptionService subscriptionService;
        IChannelService channelService;

        public ReportController()
        {
            this.reportService = Injector.Container.Resolve<IReportService>();
            this.videoService = Injector.Container.Resolve<IVideoService>();
            this.subscriptionService = Injector.Container.Resolve<ISubscriptionService>();
            this.channelService = Injector.Container.Resolve<IChannelService>();
        }

        // GET: Report
        public void Insert(Report report)
        {
            // return report.details.ToString();
            // report.time = DateTime.Now.ToString();

            reportService.Insert(report);
        }

        public ActionResult GetAllVideosReport()
        {
            List<VIdeoReportViewModel> vRVM = new List<VIdeoReportViewModel>();

            foreach(var item in reportService.getAllVideosReport())
            {
                VIdeoReportViewModel v = new VIdeoReportViewModel();
                v.Ttile = item.Title;
                v.ChannelName = item.Channel.ChannelName;
                v.VideoId = item.Id;
                v.Approve = item.Approve;
                v.TotalReports= reportService.TotalReportByType(item.Id, "video");
                v.TotalView = item.ViewCount;


                vRVM.Add(v);

            }

            return View(vRVM);
        }

        Video v = new Video();

        public ActionResult Video(int id)
        {

            List<VideoDetailsReport> vdr = new List<VideoDetailsReport>();

            foreach(var item in reportService.getAllVideosReportsById(id))
            {
                VideoDetailsReport v = new VideoDetailsReport();
                v.ReportedBy = item.User.Name;
                v.Time = item.Time;
                v.Content = item.Content;
                v.Details = item.Details;


                vdr.Add(v);
            }

            return View(vdr);
        }

       public void ChangeVideoApproval(int id)
        {
            videoService.ChangeVideoApproval(id);
        }


        public ActionResult GetAllChannelsReport()
        {
            List<ChannelReportList> vRVM = new List<ChannelReportList>();

            foreach (var item in reportService.getAllChannelsReport())
            {
                ChannelReportList v = new ChannelReportList();
                v.Status = item.Status;
                v.OwnerName = item.User.Name;
                v.ChannelId = item.Id;
                v.ChannelName = item.ChannelName;
                v.TotalSubscribers = subscriptionService.TotalSubscriberByChannelId(item.Id);
                v.TotalReports = reportService.TotalReportByType(item.Id,"channel");
                vRVM.Add(v);

            }

            return View(vRVM);
        }

        public void ChangeChannelStatus(int id)
        {
            channelService.ChangeChannelStatus(id);
        }
    }
}
