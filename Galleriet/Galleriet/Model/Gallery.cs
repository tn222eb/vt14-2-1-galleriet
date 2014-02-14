using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        }

        // Publik metod som returnerar en referens innehållande bildernas filnamn sorterade i ordning
        public IEnumerable<string> GetImageNames()
        {
            return null;
        }

        // Publik statisk metod som kollar om en bild med angivet namn finns i katalogen för uppladdade bilder
        public static bool ImageExists(string name)
        {
            return false;
        }

        // Publik metod som kontrollerar om den uppladdade filens innehåll är av giltig typ
        public bool IsValidImage(Image image)
        {
            return false;
        }

        // Publik metod som verifierar, kontrollerar, sparar bilden samt skapar och sparar en tumnagelbild
        public string SaveImage(Stream stream, string fileName)
        {
            return null;
        }


    }
}