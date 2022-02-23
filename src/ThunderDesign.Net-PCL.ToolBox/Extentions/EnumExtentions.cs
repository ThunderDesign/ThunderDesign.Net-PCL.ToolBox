using System;
using System.ComponentModel;
using System.Reflection;

namespace ThunderDesign.Net.ToolBox.Extentions
{
    public static class EnumExtentions
    {
        public static string GetDescription(this Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return en.ToString();
        }

        public static int AsIndex(this Enum value)
        {
            return Array.IndexOf(Enum.GetValues(value.GetType()), value);
        }
    }
}
