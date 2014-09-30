using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoSubtitleCreator.Logic.Model;

namespace VideoSubtitleCreator.Logic.Repositories
{
    public class LibraryFolder
    {
        #region fields
        private string pathLibrary;
        private string libraryFile = "AppLibrary";
        #endregion fields

        #region constructor
        public LibraryFolder()
        {
            pathLibrary = DirAppData;
        }
        #endregion constructor

        #region Application Properties
        /// <summary>
        /// Get a path to the directory where the application.
        /// </summary>
        public string DirAppData
        {
            get
            {
                string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                                 System.IO.Path.DirectorySeparatorChar + this.Company;

                try
                {
                    if (System.IO.Directory.Exists(dirPath) == false)
                        System.IO.Directory.CreateDirectory(dirPath);
                }
                catch
                {
                }

                return dirPath;
            }
        }

        private string Company
        {
            get
            {
                return "zngduong";
            }
        }
        #endregion Application Properties

        #region read library

        public List<Gallery> GetData()
        {
            string LibraryFileName = string.Empty;
            try
            {
                LibraryFileName = System.IO.Path.Combine(this.DirAppData, this.libraryFile);


                using (StreamReader r = new StreamReader(LibraryFileName))
                {
                    string json = r.ReadToEnd();
                    var result = JsonConvert.DeserializeObject<List<Gallery>>(json);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("File does not exist");
            }


            return null;
        }

        public void SaveData(List<Gallery> content)
        {
            string LibraryFileName = string.Empty;
            try
            {
                LibraryFileName = System.IO.Path.Combine(this.DirAppData, this.libraryFile);
                if (!File.Exists(LibraryFileName))
                {
                    using (FileStream f = File.Create(LibraryFileName)) { }

                }
                using (FileStream fs = File.Open(LibraryFileName, FileMode.OpenOrCreate))
                using (StreamWriter sw = new StreamWriter(fs))
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;

                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(jw, content);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            

        }
        #endregion read library
        

    }
}
