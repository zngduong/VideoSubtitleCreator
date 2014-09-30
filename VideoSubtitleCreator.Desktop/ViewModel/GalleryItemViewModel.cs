using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoSubtitleCreator.Desktop.ViewModel.Base;
using VideoSubtitleCreator.Logic.Model;
using VideoSubtitleCreator.Logic.Repositories;

namespace VideoSubtitleCreator.Desktop.ViewModel
{
    public class GalleryItemViewModel : ViewViewModel
    {
        #region fields
        private ObservableCollection<GalleryViewModel> _galleryList = new ObservableCollection<GalleryViewModel>();
        private VideoGalleryRepository _videoGalleryRepository;
        private bool _loadingData;

        public const string ViewContentId = "GalleryItemView";
        #endregion fields

        #region constructor
        public GalleryItemViewModel()
            : base("Gallery Item")
        {
            ContentId = ViewContentId;
            ObservableCollection<Gallery> rootGalleries = null;
            try
            {
                LoadingData = true;
                _videoGalleryRepository = new VideoGalleryRepository();
                if (!_videoGalleryRepository.LibraryIsExist)
                {
                    //_videoGalleryRepository.CreateDefaultGallery();
                }
                rootGalleries = _videoGalleryRepository.Galleries;
                foreach (var gallery in rootGalleries)
                {
                    var galleryVM = new GalleryViewModel(gallery);
                    _galleryList.Add(galleryVM);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                LoadingData = false;
            }
        }
        #endregion constructor

        #region properties

        public bool LoadingData
        {
            get { return _loadingData; }
            private set
            {
                _loadingData = value;
                RaisePropertyChanged("LoadingData");
            }
        }
        public ObservableCollection<GalleryViewModel> Galleries
        {
            get { return _galleryList; }
            set
            {
                _galleryList = value;
                RaisePropertyChanged("Galleries");
            }
        }


        #endregion properties

        #region commands

        #endregion commands
    }
}
