using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using MySql.Data;
using MySql.Data.MySqlClient;
using fractal_generator.Database;

namespace fractal_generator.Model
{
    public class Fractal
    {
        private int id;
        private String name;
        private String description;
        private String thumbUrl;
        private String code;
        private BitmapImage imageData;

        public Fractal(List<String> reader)
        {
            id = Int32.Parse(reader[0]);
            name = " " + reader[1]; //needed due to an space in front end 
            description = reader[2];
            thumbUrl = reader[3];
            code = reader[4];
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public String Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public String Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public BitmapImage ImageData
        {
            get { return this.LoadImage(); }
        }

        public String Code
        {
            get { return this.code; }
            set { this.code = value; }
        }



        public Fractal()
        {

        }



        public String getThumbUrl()
        {
            String parentPath = GetParent(Directory.GetCurrentDirectory(), "fractal_generator");
            string[] paths = { parentPath, "Model", "Images", thumbUrl };
            String imagePath = Path.Combine(paths);
            return imagePath;

        }

        public String GetImageUrl(String imageUrl)
        {
            String parentPath = GetParent(Directory.GetCurrentDirectory(), "fractal_generator");
            string[] paths = { parentPath, "Model", "Images", imageUrl };
            String imagePath = Path.Combine(paths);
            return imagePath;

        }

        public string GetParent(string path, string parentName) //needed for thumburl
        {
            var dir = new DirectoryInfo(path);

            if (dir.Parent == null)
            {
                return null;
            }

            if (dir.Parent.Name == parentName)
            {
                return dir.Parent.FullName;
            }

            return this.GetParent(dir.Parent.FullName, parentName);
        }

        private BitmapImage LoadImage()
        {
            return new BitmapImage(new Uri(getThumbUrl()));
        }

        private BitmapImage LoadImage(Uri u)
        {
            return new BitmapImage(u);
        }

        public static List<Fractal> GetFractalList()
        {

            //TODO: see the difference between string and String
            List<List<String>> listString = DB.ExecuteFractalListSql();
            List<Fractal> fractalList = new List<Fractal>();
            foreach (var reader in listString)
            {
                Fractal f = new Fractal(reader);
                fractalList.Add(f);
            }

            return fractalList;

        }

        public static List<BitmapImage> GetImagesUriList(Fractal f)
        {
            List<BitmapImage> bitmapList = new List<BitmapImage>();


            var imageUrlList = DB.ExecuteImageUrlSql(f);

            foreach (var reader in imageUrlList)
            {
                BitmapImage bm = f.LoadImage(new Uri(f.GetImageUrl(reader)));
                bitmapList.Add(bm);
            }

            return bitmapList;
        }

        //public static Uri 
    }
}
