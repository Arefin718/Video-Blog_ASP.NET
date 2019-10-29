using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;
using YoutubeRepository.Interface;

namespace YoutubeRepository.Class
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        DataContext context = new DataContext();

        public List<Comment> CommentByVideoId(int id)
        {
            return context.Comments.Include("User").Where(c => c.VideoId == id).ToList();
        }

        public Comment InsertComment(Comment comment)
        {
            //comment.UserId = 1;
            //comment.VideoId = 1;
            //comment.CommentContent = "hello";
            //comment.CommentTime = "time45";
            //comment.ParentCommentId = 0;

            this.context.Set<Comment>().Add(comment);
            context.SaveChanges();
            return context.Set<Comment>().Include("User").AsNoTracking().SingleOrDefault(u => u.Id == comment.Id);
        }
    }
}
