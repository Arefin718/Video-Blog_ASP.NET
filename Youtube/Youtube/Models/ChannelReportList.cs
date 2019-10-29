using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Youtube.Models
{
    public class ChannelReportList
    {
        public string ChannelName { get; set; }
        public int ChannelId { get; set; }
        public string OwnerName { get; set; }
        public int TotalReports { get; set; }
        public int TotalSubscribers{ get; set; }
        public int Status { get; set; }

    }
}