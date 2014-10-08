using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VideoSubtitleCreator.Desktop.ViewModel
{
    public class LibraryViewModel : PaneViewModel
    {
        public LibraryViewModel()
        {
            this.Title = "Library";
            this.ContentId = "{Library_ContentId}";
        }

        #region CloseCommand
        RelayCommand<object> _closeComand = null;
        public ICommand CloseCommand
        {
            get
            {
                if (_closeComand == null)
                {
                    _closeComand = new RelayCommand<object>((p) => OnClose(), (p) => CanClose());
                }

                return _closeComand;
            }
        }

        private bool CanClose()
        {
            return true;
        }

        private void OnClose()
        {
            //Workspace.This.Close(this);
        }
        
        #endregion
    }
}
