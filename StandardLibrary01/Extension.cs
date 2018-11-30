using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace StandardLibrary01
{
    public static class Extension
    {
        public static string GetEnumName(this Enum value)
        {
            return value.GetType()
                .GetMember(value.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .GetName();
        }
    }
}
