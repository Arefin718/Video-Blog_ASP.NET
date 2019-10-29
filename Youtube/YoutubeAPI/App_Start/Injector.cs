using Injection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Injection;
using YoutubeService.Class;
using YoutubeService.Interface;

namespace YoutubeAPI.App_Start
{
    public class Injector
    {
        public static IInjectionContainer Container { get; set; }

        static Injector()
        {
            Container = new Container();
        }

        public static void Configure()
        {
            Container.Register<IUserService, UserService>().Singleton();
            Container.Register<IVideoService, VideoService>().Singleton();

            //other services will be registered here
        }
    }
}