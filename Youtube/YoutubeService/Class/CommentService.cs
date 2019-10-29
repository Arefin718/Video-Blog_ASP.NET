using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;
using YoutubeRepository.Class;
using YoutubeService.Interface;

namespace YoutubeService.Class
{
    public class CommentService : Service<Comment>, ICommentService
    {
        CommentRepository commentRepo = new CommentRepository();

        public List<Comment> CommentByVideoId(int id)
        {
            return commentRepo.CommentByVideoId(id);
        }

        public Comment InsertComment(Comment comment)
        {
            return commentRepo.InsertComment(comment);
        }
    }
}
