using System;
using System.Collections;

namespace ThunderDesign.Net.ToolBox.Extentions
{
    public static class TypeExtentions
    {
        public static string AsShortClassName(this Type self)
        {
            string className = self.Name;
            int index = className.IndexOf("`");
            if (index != -1)
            {
                className = className.Substring(0, index);
            }
            return className;
        }

        public static bool CanDirectlyCompare(this Type self)
        {
            return typeof(IComparable).IsAssignableFrom(self) || self.IsPrimitive || self.IsValueType || self is IEnumerable;
        }
    }
}
