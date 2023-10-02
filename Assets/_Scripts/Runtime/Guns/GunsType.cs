using System;

namespace Game.Runtime.Guns
{
    public enum GunsType
    {
        Debug = int.MinValue,
        MagicWand = 0,
        Bible = 1,
        Axes = 2,
    }

    public static class GunsTypeUtils
    {
        public static int Count => Enum.GetValues(typeof(GunsType)).Length - 1;
    }
}