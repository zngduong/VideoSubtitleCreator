using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace VideoSubtitleCreator.Desktop.ViewModel
{
    class PaneViewModel : ViewModelBase
    {
        public PaneViewModel()
        { }

        #region Title

        private string _title = null;
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    this.RaisePropertyChanged(() => this.Title);
                }
            }
        }

        #endregion

        public ImageSource IconSource
        {
            get;
            protected set;
        }

        #region ContentId

        private string _contentId = null;
        public string ContentId
        {
            get { return _contentId; }
            set
            {
                if (_contentId != value)
                {
                    _contentId = value;
                    this.RaisePropertyChanged(() => this.ContentId);
                }
            }
        }

        #endregion

        #region IsSelected

        private bool _isSelected = false;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    this.RaisePropertyChanged(() => this.IsSelected);
                }
            }
        }

        #endregion

        #region IsActive

        private bool _isActive = false;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    this.RaisePropertyChanged(() => this.IsActive);
                }
            }
        }

        #endregion


    }
}
