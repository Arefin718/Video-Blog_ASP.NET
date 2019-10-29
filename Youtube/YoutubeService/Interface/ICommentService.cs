using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;

namespace YoutubeService.Interface
{
    public interface ICommentService : IService<Comment>
    {
        Comment InsertComment(Comment comment);
        List<Comment> CommentByVideoId(int id);
    }
}
