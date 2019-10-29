using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Injection;
using Injection.Interfaces;
using YoutubeService.Interface;
using YoutubeService.Class;

namespace Youtube.App_Start
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
            Container.Register<IChannelService, ChannelService>().Singleton();
            Container.Register<IVideoService, VideoService>().Singleton();
            Container.Register<ISubscriptionService, SubscriptionService>().Singleton();
            Container.Register<ICommentService, CommentService>().Singleton();
            Container.Register<INotificationService, NotificationService>().Singleton();
            Container.Register<IReportService, ReportService>().Singleton();
            Container.Register<IPlaylistService, PlaylistService>().Singleton();
            Container.Register<IPlaylistVideoService, PlaylistVideoService>().Singleton();
            Container.Register<IForgetPasswordService, ForgetPasswordService>().Singleton();
            Container.Register<IAPIKeyService, APIKeyService>().Singleton();
            Container.Register<IAdminService, AdminService>().Singleton();
            Container.Register<IReactService, ReactService>().Singleton();
            //other services will be registered here
        }
    }
}