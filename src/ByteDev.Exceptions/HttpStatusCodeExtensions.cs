using System.Net;

namespace ByteDev.Exceptions
{
    internal static class HttpStatusCodeExtensions
    {
        public static string ToReadableString(this HttpStatusCode source)
        {
            return $"{(int)source} {source}";
        }
    }
}