using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoSubtitleCreator.Logic.Model
{
    public class Gallery
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IList<string> Tag { get; set; }

        public IList<Chapter> Chapters { get; set; }

        public string Language { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }

        public Uri ImageUri { get; set; }

        public IList<Video> Videos { get; set; }
    }
}
