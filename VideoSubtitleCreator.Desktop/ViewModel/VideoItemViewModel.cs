using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoSubtitleCreator.Logic.Model;

namespace VideoSubtitleCreator.Desktop.ViewModel
{
    public class VideoItemViewModel : ViewModelBase
    {
        #region fields
        private ObservableCollection<VideoViewModel> _videos;
        private Chapter _chapter;
        #endregion fields

        #region constructor
        public VideoItemViewModel(List<Video> videos)
            : this(videos, null)
        {
            _videos = new ObservableCollection<VideoViewModel>(videos.Select(v => new VideoViewModel(v)).ToList());

        }
        public VideoItemViewModel(List<Video> videos, Chapter chapter)
        {
            _videos = new ObservableCollection<VideoViewModel>(videos.Select(v => new VideoViewModel(v)).ToList());
            if (chapter == null)
            {
                _chapter = new Chapter { Id = 0, Title = "Play List" };
            }
            else
            {
                _chapter = chapter;
            }
        }


        #endregion constructor

        #region properties
        public ObservableCollection<VideoViewModel> ListVideo
        {
            get
            {
                return _videos;
            }
            set
            {
                _videos = value;
                RaisePropertyChanged("ListVideo");
            }
        }

        public Chapter Chapter
        {
            get
            {
                return _chapter;
            }
            set
            {
                _chapter = value;
                RaisePropertyChanged("Chapter");
            }
        }

        //public string TitleChapter
        //{
        //    get
        //    {
        //        return _chapter.Title;
        //    }
        //    set
        //    {
        //        _chapter.Title = value;
        //        RaisePropertyChanged("TitleChapter");
        //    }
        //}
        #endregion properties

        #region commands

        #endregion commands


        //public ObservableCollection<VideoViewModel> GetFilterdForChapter(int chapterId)
        //{
        //    _videoByChapter = new ObservableCollection<VideoViewModel>(_videos.Where(v => v.ChapterId == chapterId).OrderBy(v => v.TrackNumber).ToList());
        //    return _videoByChapter;
        //}
    }
}
