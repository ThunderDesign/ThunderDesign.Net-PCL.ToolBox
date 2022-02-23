using System.IO;

namespace ThunderDesign.Net.ToolBox.Extentions
{
    public static class BytesExtentions
    {
        public static Stream AsStream(this byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
    }
}
