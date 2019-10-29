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
    public class CommentController : Controller
    {
        ICommentService commentService;

        public CommentController()
        {
            this.commentService = Injector.Container.Resolve<ICommentService>();
        }

        //public JsonResult Insert(Comment comment)
        //{
        //   Comment cmnt= commentService.InsertComment(comment);

        //    return Json(

        //          new
        //          {
        //              comment =

        //             new
        //             {
        //                 Id = cmnt.Id,
        //                 CommentContent = cmnt.CommentContent,
        //                 UserId = comment.User.Id,
        //                 VideoId = cmnt.VideoId,
        //                 CommentTime = cmnt.CommentTime,
        //                 Name = cmnt.User.Name,
        //                 Image = cmnt.User.Image,
        //                 ParentCommentId = 1
        //             }
        //          },


        //         JsonRequestBehavior.AllowGet

        //        );
        //}

        public JsonResult Insert(Comment comment)
        {
            comment.UserId = Convert.ToInt32(Session["UserId"]);
            Comment cmnt = commentService.InsertComment(comment);

            return Json(

                  new
                  {
                      comment =

                     new
                     {
                         Id = cmnt.Id,
                         CommentContent = cmnt.CommentContent,
                         UserId = comment.User.Id,
                         VideoId = cmnt.VideoId,
                         CommentTime = cmnt.CommentTime,
                         Name = cmnt.User.Name,
                         Image = cmnt.User.Image,
                         ParentCommentId = cmnt.ParentCommentId
                     }
                  },


                 JsonRequestBehavior.AllowGet

                );
        }

    }
}