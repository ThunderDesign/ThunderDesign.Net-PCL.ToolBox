using System.Reflection;

namespace ThunderDesign.Net.ToolBox.Extentions
{
    public static class PropertyInfoExtentions
    {
        public static bool CanCopyPropertyValue(this PropertyInfo self, PropertyInfo source)
        {
            if (source == null || self == null)
                return false;
            if (source.PropertyType != self.PropertyType || !source.CanRead || !self.CanWrite)
                return false;
            return true;
        }
    }
}
