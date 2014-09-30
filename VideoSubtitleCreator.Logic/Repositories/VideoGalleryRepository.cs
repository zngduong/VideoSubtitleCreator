using MediaInfoDotNet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoSubtitleCreator.Logic.Model;

namespace VideoSubtitleCreator.Logic.Repositories
{
    public class VideoGalleryRepository
    {
        #region fields
        private List<Gallery> _galleries;
        private ObservableCollection<Gallery> _listGallery;
        private LibraryFolder _library;
        private bool _libraryIsExist = false;
        #endregion fields

        #region constructor
        public VideoGalleryRepository()
        {
            _library = new LibraryFolder();
            _galleries = new List<Gallery>();
            _listGallery = new ObservableCollection<Gallery>();
            GetGalleries();
        }
        #endregion constructor

        #region properties
        public bool LibraryIsExist { get { return _libraryIsExist; } private set { _libraryIsExist = value; } }

        public ObservableCollection<Gallery> Galleries
        {
            get
            {
                if (_listGallery == null)
                {
                    _listGallery = new ObservableCollection<Gallery>();
                }
                return _listGallery;
            }
        }

        #endregion properties

        #region Gallery Manager
        private void GetGalleries()
        {
            try
            {
                _galleries = _library.GetData();
            }
            catch (FileNotFoundException)
            {
                _libraryIsExist = false;
            }
            _libraryIsExist = true;
            if (_galleries != null)
            {
                foreach (var gallery in _galleries)
                {
                    _listGallery.Add(gallery);
                }
            }
        }

        /// <summary>
        /// Thêm gallery vào library
        /// </summary>
        /// <param name="gallery"></param>
        public void AddGallery(Gallery gallery)
        {
            Check.Require(gallery.Title);

            //refactor manager image save to folder User or to Library, and crop image to default
            //if (gallery.ImageUri != null)
            //{

            //}
            gallery.Id = _galleries.Count > 0 ? _galleries.Max(x => x.Id) + 1 : 1;
            _galleries.Add(gallery);
            _library.SaveData(_galleries);
        }

        public void UpdateGallery(Gallery gallery)
        {
            Check.Require(gallery.Title);
            _galleries = (_galleries.Select(g =>
            {
                if (g.Id == gallery.Id) return g = gallery;
                else return g;
            })).ToList();
            _library.SaveData(_galleries);
        }

        public void DeleteGallery(int galleryId)
        {
            var gallery = _galleries.FirstOrDefault(c => c.Id == galleryId);
            _galleries.Remove(gallery);
            //_galleries.ForEach((g) => { if (g.Id > galleryId) g.Id = g.Id - 1; });
            _library.SaveData(_galleries);
        }

        public void CreateDefaultGallery()
        {
            Gallery g = new Gallery
            {
                Id = 0,
                Title = "My Gallery",
                Author = "User",
                Description = "My Gallery"
            };
            this.AddGallery(g);
        }
        #endregion Gallery

        #region Video

        public Video GetInfoVideo(string pathFile)
        {

            MediaFile file = new MediaFile(pathFile);

            Video video = new Video
            {
                Title = file.title,
                Release = file.encodedDate,
                Time = file.duration,
                Location = new Uri(file.filePath)
            };
            return video;
        }

        /// <summary>
        /// Thêm list Video vào gallery
        /// </summary>
        /// <param name="video"></param>
        /// <param name="gallery"></param>
        public void AddVideos(List<Video> videos, int galleryId)
        {
            _galleries = (_galleries.Select(g =>
                {
                    if (g.Id == galleryId)
                    {
                        foreach (Video v in videos)
                        {
                            v.Id = g.Videos.Count > 0 ? g.Videos.Max(x => x.Id) + 1 : 1;
                            g.Videos.Add(v);
                        }
                        return g;
                    }
                    else return g;
                })).ToList();
            _library.SaveData(_galleries);
        }

        //public void Remove(List<int> videosId, int galleryId)
        //{
        //    _galleries = (_galleries.Select(g =>
        //        {
        //            if (g.Id == galleryId)
        //            {
        //                g.Videos.RemoveAll(v => videosId.Contains(v.Id));
        //                return g;
        //            }
        //            else return g;
        //        })).ToList();
        //    _library.SaveData(_galleries);
        //}


        #endregion Video
        static class Check
        {
            public static void Require(string value)
            {
                if (value == null)
                    throw new ArgumentNullException();
                else if (value.Trim().Length == 0)
                    throw new ArgumentNullException();
            }

        }
    }
}
