using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ByteDev.Exceptions.UnitTests.Serialization
{
    internal static class Serializer
    {
        public static TException SerializeAndDeserialize<TException>(TException exception)
        {
            var formatter = new BinaryFormatter();
            
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, exception);

                stream.Seek(0, 0);

                return (TException)formatter.Deserialize(stream);
            }
        }
    }
}