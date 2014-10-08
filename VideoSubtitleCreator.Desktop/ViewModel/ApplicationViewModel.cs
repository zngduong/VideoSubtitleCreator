using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoSubtitleCreator.Desktop.ViewModel
{
    public class ApplicationViewModel : ViewModelBase
    {
        #region fields
        private static ApplicationViewModel _this = new ApplicationViewModel();

        #endregion

        #region constructor
        public static ApplicationViewModel This
        {
            get { return _this; }
        }
        #endregion
    }
}
