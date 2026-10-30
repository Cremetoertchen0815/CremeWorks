using System;
using System.Runtime.InteropServices;

namespace CremeWorks.App
{
    public static class StructMarshal
    {
        public static byte[] GetBytes<T>(T value) where T : struct
        {
            var size = Marshal.SizeOf<T>();
            var bytes = new byte[size];
            var ptr = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(value, ptr, false);
                Marshal.Copy(ptr, bytes, 0, size);
                return bytes;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        public static T FromBytes<T>(byte[] bytes) where T : struct
        {
            ArgumentNullException.ThrowIfNull(bytes);

            int size = Marshal.SizeOf<T>();

            if (bytes.Length != size)
                throw new ArgumentException($"Expected {size} bytes, received {bytes.Length}.");

            var ptr = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.Copy(bytes, 0, ptr, size);
                return Marshal.PtrToStructure<T>(ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
    }
}