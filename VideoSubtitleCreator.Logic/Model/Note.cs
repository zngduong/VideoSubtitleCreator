using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoSubtitleCreator.Logic.Model
{
    public class Note
    {
        public int Id { get; set; }
        public TimeSpan Time { get; set; }
        public string Content { get; set; }
    }
}
