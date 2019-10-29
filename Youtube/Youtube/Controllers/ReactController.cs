using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Youtube.App_Start;
using YoutubeEntity.Class;
using YoutubeService.Interface;

namespace Youtube.Controllers
{
    public class ReactController : Controller
    {
        IReactService reactService;

        public ReactController()
        {
            this.reactService = Injector.Container.Resolve<IReactService>();
        }


        // GET: React
        public int UpdateReact(React react)
        {
           return reactService.UpdateReact(react.VideoId, react.UserId);
        }
    }
}