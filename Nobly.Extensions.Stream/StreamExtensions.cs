using System;
using System.IO;

namespace Nobly.Extensions.Stream
{
    public static class StreamExtensions
    {

        public static byte[] ToBytes(this System.IO.Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
