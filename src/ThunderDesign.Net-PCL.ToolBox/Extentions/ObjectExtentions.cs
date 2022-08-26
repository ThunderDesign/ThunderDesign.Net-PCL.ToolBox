using System;
using System.Reflection;

namespace ThunderDesign.Net.ToolBox.Extentions
{
    public static class ObjectExtentions
    {
#if NETSTANDARD2_0 || NETSTANDARD2_1
        public static bool Copy(this object self, object source, string property)
        {
            if (source == null || self == null || string.IsNullOrEmpty(property))
                return false;
            PropertyInfo sourcePropertyInfo, targetPropertyInfo;
            sourcePropertyInfo = source.GetType().GetProperty(property);
            targetPropertyInfo = self.GetType().GetProperty(property);
            if (!targetPropertyInfo.CanCopyPropertyValue(sourcePropertyInfo))
                return false;
            if (sourcePropertyInfo.PropertyType.CanDirectlyCompare())
            {
                targetPropertyInfo.SetValue(self, sourcePropertyInfo.GetValue(source));
                return true;
            }
            else if (sourcePropertyInfo.PropertyType.IsArray && sourcePropertyInfo.PropertyType.GetElementType().CanDirectlyCompare())
            {
                targetPropertyInfo.SetValue(self, ((Array)sourcePropertyInfo.GetValue(source))?.Clone(), null);
                return true;
            }

            return false;
        }
#endif

        public static bool IsEqual(this object self, object value)
        {
            bool result;
            IComparable selfValueComparer;
            selfValueComparer = self as IComparable;
            if (self == null && value != null || self != null && value == null)
                result = false; // one of the values is null
            else if (selfValueComparer != null && selfValueComparer.CompareTo(value) != 0)
                result = false; // the comparison using IComparable failed
            else if (!object.Equals(self, value))
                result = false; // the comparison using Equals failed
            else
                result = true; // match
            return result;
        }
    }
}
