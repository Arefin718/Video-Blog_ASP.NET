using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;

namespace YoutubeRepository.Interface
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Comment InsertComment(Comment comment);
        List<Comment> CommentByVideoId(int id);
    }
}
