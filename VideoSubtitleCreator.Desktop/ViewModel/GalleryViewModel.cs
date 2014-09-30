using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoSubtitleCreator.Desktop.ViewModel.Base;
using VideoSubtitleCreator.Logic.Model;

namespace VideoSubtitleCreator.Desktop.ViewModel
{
    public class GalleryViewModel : ViewViewModel
    {
        #region fields
        private Gallery _gallery;
        private ObservableCollection<Gallery> _galleryList = new ObservableCollection<Gallery>();

        public const string ViewContentId = "GalleryView";
        #endregion fields

        #region constructor
        public GalleryViewModel()
            : this(null)
        {

        }
        public GalleryViewModel(Gallery gallery)
            : base("Gallery")
        {
            ContentId = ViewContentId;
            _gallery = gallery;
            if (gallery != null && gallery.Videos != null)
            {
                Videos = new ObservableCollection<VideoItemViewModel>();
                if (gallery.Chapters != null)
                {
                    foreach (Chapter chapter in gallery.Chapters)
                    {
                        var listVideo = gallery.Videos.Where(v => v.ChapterParent == chapter.Id).OrderBy(v => v.TrackNumber).ToList();
                        var SubChapter = new VideoItemViewModel(listVideo, chapter);
                        Videos.Add(SubChapter);
                    }
                }
                else
                {
                    Videos.Add(new VideoItemViewModel(gallery.Videos.ToList(), null));
                }
            }
        }
        #endregion constructor

        #region properties
        public int GalleryId { get { return _gallery.Id; } }

        public string Title { get { return _gallery.Title; } }

        public ObservableCollection<VideoItemViewModel> Videos { get; private set; }


        public string Language { get { return _gallery.Language; } }

        public string Author { get { return _gallery.Author; } }

        public string Description { get { return _gallery.Description; } }

        public Uri Image { get { return _gallery.ImageUri; } }

        #endregion properties

        #region commands

        #endregion commands
    }
}
