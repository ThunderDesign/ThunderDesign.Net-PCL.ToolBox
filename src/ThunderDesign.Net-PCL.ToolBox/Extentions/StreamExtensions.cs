using System.IO;
using System.Text;

namespace ThunderDesign.Net.ToolBox.Extentions
{
    public static class StreamExtensions
    {
        public static string AsString(this Stream stream)
        {
            return AsString(stream, Encoding.UTF8);
        }

        public static string AsString(this Stream stream, Encoding encoding)
        {
            var reader = new StreamReader(stream ?? new MemoryStream(encoding.GetBytes("")), encoding);
            return reader.ReadToEnd();
        }

        public static byte[] AsBytes(this Stream stream)
        {
            byte[] bytes = null;
            if (stream != null)
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    bytes = memoryStream.ToArray();
                }
            return bytes;
        }
    }
}
