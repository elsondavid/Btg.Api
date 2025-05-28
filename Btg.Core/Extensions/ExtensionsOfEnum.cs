using System.ComponentModel;

namespace Btg.Core.Extensions;

public static class ExtensionsOfEnum
{
    public static T? ToEnum<T>(this string value)
    {
        var t = typeof(T);

        if (!t.IsEnum)
            throw new InvalidEnumArgumentException(" T must be Enum.");

        if (string.IsNullOrEmpty(value))
            return default(T);

        if (int.TryParse(value, out _))
            return (T)Enum.Parse(typeof(T), value);

        if (char.TryParse(value, out var charValue))
            return (T)Enum.ToObject(typeof(T), charValue);

        return (T)Enum.Parse(typeof(T), value, true);
    }
}