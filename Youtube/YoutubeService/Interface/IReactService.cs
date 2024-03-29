﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;

namespace YoutubeService.Interface
{
    public interface IReactService : IService<React>
    {
        int UpdateReact(int videoId, int userId);
        bool UserReactStatus(React react);
    }
}
