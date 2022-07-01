using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace MinnespelApp
{
    public class ListOfImages
    {
        public int Arow { get; set; }
        public int Acol { get; set; }
        public Image Aimage { get; set; }

    }
    public static class GetImages
    {
        public static List<ListOfImages> imagetolist; 

        public static void Init()
        {
            imagetolist = new List<ListOfImages>();
        }
        public static void AddNewIems(int row,int col,Image image)
        {
            imagetolist.Add(new ListOfImages() {  Arow=row,Acol=col, Aimage=image });

        }
        public static Image GetImageFromList(int row, int col)
        {
           var img= imagetolist.Where(a => a.Acol == col && a.Arow == row).Select(s => s.Aimage).FirstOrDefault();
            return img;
        }
    }
}
