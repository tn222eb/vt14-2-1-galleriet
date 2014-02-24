using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Galleriet.Model
{
    public class Gallery
    {
        // Privat statiskt fält som kollar om en fil har tillåten filändelse med hjälp av ett reguljärt uttryck
        private readonly static Regex ApprovedExtensions;

        // Privat statiskt fält som innehåller den fysiska sökvägen till katalogen där uppladdade filer sparas
        private static string PhysicalUploadImagePath;

        // Privat statiskt fält som håller koll att filnamnet innehåller godkända tecken med hjälp av ett reguljärt uttryck
        private static readonly Regex SantizePath;

        // Konstruktor
        static Gallery()
        {
            ApprovedExtensions = new Regex("^.*.(gif|jpg|png)$", RegexOptions.IgnoreCase);

            PhysicalUploadImagePath = Path.Combine(
                AppDomain.CurrentDomain.GetData("APPBASE").ToString(), "Pictures");

            var invalidChars = new string(Path.GetInvalidFileNameChars());
            SantizePath = new Regex(string.Format("[{0}]", Regex.Escape(invalidChars)));
        }

        // Publik metod som returnerar en referens innehållande bildernas filnamn sorterade i ordning
        public IEnumerable<ThumbPic> GetImageNames()
        {
            var di = new DirectoryInfo(Path.Combine(PhysicalUploadImagePath, "Thumbnails"));
            return from fi in di.GetFiles()
                   select new ThumbPic
                   {
                       PicFileUrl = String.Format("/?name={0}", fi.Name),
                       ThumbPicUrl = String.Format("Pictures/Thumbnails/{0}", fi.Name)
                   };
        }

        // Publik statisk metod som kollar om en bild med angivet namn finns i katalogen för uppladdade bilder
        public static bool ImageExists(string name)
        {
            return File.Exists(Path.Combine(PhysicalUploadImagePath, name));

        }

        // Publik metod som kontrollerar om den uppladdade filens innehåll är av giltig typ
        public bool IsValidImage(Image image)
        {
            return image.RawFormat.Guid == ImageFormat.Gif.Guid ||
                   image.RawFormat.Guid == ImageFormat.Jpeg.Guid ||
                   image.RawFormat.Guid == ImageFormat.Png.Guid;

        }

        // Publik metod som verifierar, kontrollerar, sparar bilden samt skapar och sparar en tumnagelbild
        public string SaveImage(Stream stream, string fileName)
        {
            fileName = SantizePath.Replace(fileName, String.Empty);

          
                if (ApprovedExtensions.IsMatch(fileName))
                {
                    var image = System.Drawing.Image.FromStream(stream);
                    var thumbnail = image.GetThumbnailImage(60, 45, null, System.IntPtr.Zero);

                    if (ImageExists(fileName))
                    {
                        var imageName = Path.GetFileNameWithoutExtension(fileName);
                        var imageExtension = Path.GetExtension(fileName);
                        int i = 1;

                        while (ImageExists(fileName))
                        {
                            fileName = String.Format("{0}{1}{2}", imageName, i++, imageExtension);
                        }
                    }

                    if (IsValidImage(image))
                    {
                        image.Save(Path.Combine(PhysicalUploadImagePath, fileName));
                        thumbnail.Save(PhysicalUploadImagePath + "/Thumbnails/" + fileName);
                    }

                    else
                    {
                        throw new ApplicationException("Bilden är inte av typen png, gif eller jpg.");
                    }
                }
                else
                {
                    throw new ApplicationException("Filen har inte giltig filändelse");
                }
            

            return fileName;

        }


    }
}