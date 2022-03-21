using System.Linq;
using System.Reflection;

namespace ThunderDesign.Net.ToolBox.Extentions
{
    public static class GenericExtentions
    {
#if NETSTANDARD2_0 || NETSTANDARD2_1
        public static void Mirror<T>(this T target, T source)
        {
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead && p.CanWrite))// && !ignoreList.Contains(p.Name)))
            {
                target.Copy(source, propertyInfo.Name);
            }
        }
#endif
    }
}
