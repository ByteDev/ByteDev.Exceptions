namespace ByteDev.Exceptions
{
    internal static class StringExtensions
    {
        public static string EnsureEndsWith(this string source, string suffix)
        {
            if (string.IsNullOrEmpty(suffix))
                return source;

            if (source == null)
                return suffix;

            if (source.EndsWith(suffix))
                return source;
            
            return source + suffix;
        }
    }
}