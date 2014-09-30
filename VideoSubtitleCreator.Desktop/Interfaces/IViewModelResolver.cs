using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoSubtitleCreator.Desktop.Interfaces
{
    public interface IViewModelResolver
    {
        ViewModelBase ContentViewModelFromID(string content_id);
    }
}
