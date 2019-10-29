using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YoutubeAPI.Models
{
    public class VideoModel
    {
        public int VideoId { get; set; }
        public string ChannelName { get; set; }
        public string ChannelLink { get; set; }
        public string VideoURL { get; set; }
        public string VideoLink { get; set; }
        public string UploadTime { get; set; }
        public string Title { get; set; }
        public string Poster { get; set; }
    }
}