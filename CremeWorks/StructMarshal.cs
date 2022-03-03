using System;
using System.Runtime.InteropServices;

namespace CremeWorks
{
    public static class StructMarshal<T> where T : struct
    {
        public static byte[] getBytes(T str)
        {
            var size = Marshal.SizeOf(str);
            var arr = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(str, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }

        public static T fromBytes(byte[] arr)
        {
            var str = new T();

            var size = Marshal.SizeOf(str);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(arr, 0, ptr, size);

            str = (T)Marshal.PtrToStructure(ptr, str.GetType());
            Marshal.FreeHGlobal(ptr);

            return str;
        }
    }
}
