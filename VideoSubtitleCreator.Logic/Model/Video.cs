using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoSubtitleCreator.Logic.Model
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ChapterParent { get; set; }
        public int TrackNumber { get; set; }
        public int Time { get; set; }
        public DateTime Release { get; set; }
        public List<Subtitle> Subtitles { get; set; }
        public int NoteId { get; set; }
        public Uri Location { get; set; }
    }
}
