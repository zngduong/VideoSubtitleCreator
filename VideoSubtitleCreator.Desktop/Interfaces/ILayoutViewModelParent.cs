using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.AvalonDock.Layout.Serialization;

namespace VideoSubtitleCreator.Desktop.Interfaces
{
    public interface ILayoutViewModelParent
    {
        bool IsBusy { get; set; }

        string DirAppData { get; }

        void ReloadContentOnStartUp(LayoutSerializationCallbackEventArgs args);
    }
}
