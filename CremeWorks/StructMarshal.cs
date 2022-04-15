using System.Runtime.InteropServices;

namespace CremeWorks
{
    public static class StructMarshal<T> where T : struct
    {
        public static byte[] getBytes(T str)
        {
            int size = Marshal.SizeOf(str);
            byte[] arr = new byte[size];

            var ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(str, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }

        public static T fromBytes(byte[] arr)
        {
            var str = new T();

            int size = Marshal.SizeOf(str);
            var ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(arr, 0, ptr, size);

            str = (T)Marshal.PtrToStructure(ptr, str.GetType());
            Marshal.FreeHGlobal(ptr);

            return str;
        }
    }
}
