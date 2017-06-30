using System.IO;
using System.Windows.Media.Imaging;

namespace MMXEngine.Windows.Editor.Helpers
{
    public class BitmapImageHelpers
    {
        public static BitmapImage LoadFromBytes(byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            {
                stream.Seek(0, SeekOrigin.Begin);
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = stream;
                image.EndInit();
                return image;
            }
        }

        public static BitmapImage LoadFromStream(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            var image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.UriSource = null;
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }
    }
}
