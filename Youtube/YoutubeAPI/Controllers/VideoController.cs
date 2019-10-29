using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YoutubeAPI.App_Start;
using YoutubeAPI.Attributes;
using YoutubeAPI.Models;
using YoutubeEntity.Class;
using YoutubeService.Interface;

namespace YoutubeAPI.Controllers
{
    [RoutePrefix("api/Videos")]
    public class VideoController : ApiController
    {
        IVideoService videoService;

        public VideoController()
        {
            this.videoService = Injector.Container.Resolve<IVideoService>();
        }


        [Route("GetAllMyVideos/{id}")]
        [BasicAuthentication]
        public IHttpActionResult Get([FromUri]string id)
        {
            List<Video> vdo = videoService.GetAllVideosByClientId(id);

            List<VideoModel> videoModel = new List<VideoModel>();

           foreach(var v in vdo)
            {
                VideoModel vmodel = new VideoModel();
                vmodel.VideoId = v.Id;
                vmodel.ChannelName = v.Channel.ChannelName;
                vmodel.UploadTime = v.UploadTime;
                vmodel.Title = v.Title;
                vmodel.Poster = "http://localhost:62210" + v.Poster;
                vmodel.ChannelLink = "http://localhost:62210/video/allvideo/" + v.ChannelId;
                string url = "http://localhost:62210" + v.VideoURL;
                vmodel.VideoURL = url.Replace(" ", "%20");
                vmodel.VideoLink = "http://localhost:62210/video/view/" + v.Id;
                videoModel.Add(vmodel);

            }

           return Ok(videoModel);
        }

    }
}
