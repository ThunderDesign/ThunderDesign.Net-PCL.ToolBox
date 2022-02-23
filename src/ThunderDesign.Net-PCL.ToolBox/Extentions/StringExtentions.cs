using System.IO;
using System.Text;

namespace ThunderDesign.Net.ToolBox.Extentions
{
    public static class StringExtentions
    {
        public static Stream AsStream(this string s)
        {
            return s.AsStream(Encoding.UTF8);
        }

        public static Stream AsStream(this string s, Encoding encoding)
        {
            return new MemoryStream(encoding.GetBytes(s ?? ""));
        }
    }
}
