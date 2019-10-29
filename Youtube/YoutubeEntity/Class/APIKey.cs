using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeEntity.Class
{
    public class APIKey: Entity
    {
        public int UserId { get; set; }
        public string ClientId { get; set; }
        public string RedirectURL { get; set; }
    }
}
