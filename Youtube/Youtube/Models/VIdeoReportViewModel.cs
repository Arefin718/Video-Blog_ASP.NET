using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Youtube.Models
{
    public class VIdeoReportViewModel
    {
        public int VideoId { get; set; }
        public int Approve { get; set; }
        public string Ttile { get; set; }
        public int TotalView { get; set; }
        public int TotalReports { get; set; }
        public string ChannelName { get; set; }
    }
}