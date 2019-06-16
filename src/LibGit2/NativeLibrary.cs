#if NET472 || NETCOREAPP2_0
using System;
using System.Runtime.InteropServices;

namespace LibGit2
{
    public static partial class libgit2
    {
        private static class NativeLibrary
        {
            public static bool TryLoad(string libraryPath, out IntPtr handle)
            {
                handle = IntPtr.Zero;
                if (IsWindows())
                {
                    handle = Windows.LoadLibrary(libraryPath);
                }
                else if (IsMacOS())
                {
                    handle = MacOS.dlopen(libraryPath);
                }
                else if (IsLinux() || Environment.OSVersion.Platform == PlatformID.Unix)
                {
                    handle = Unix.dlopen(libraryPath);
                }

                return handle != IntPtr.Zero;
            }

            public static bool TryGetExport(IntPtr handle, string name, out IntPtr address)
            {
                address = IntPtr.Zero;
                if (IsWindows())
                {
                    address = Windows.GetProcAddress(handle, name);
                }
                else if (IsMacOS())
                {
                    address = MacOS.dlsym(handle, name);
                }
                else if (IsLinux() || Environment.OSVersion.Platform == PlatformID.Unix)
                {
                    address = Unix.dlsym(handle, name);
                }

                return address != IntPtr.Zero;
            }

            public static bool IsWindows() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            public static bool IsMacOS() => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

            public static bool IsLinux() => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

            private sealed class Windows
            {
                [DllImport("kernel32", EntryPoint = "LoadLibraryW", CharSet = CharSet.Unicode)]
                public static extern IntPtr LoadLibrary(string name);

                [DllImport("kernel32", EntryPoint = "FreeLibrary")]
                public static extern int FreeLibrary(IntPtr handle);

                [DllImport("kernel32", EntryPoint = "GetProcAddress")]
                public static extern IntPtr GetProcAddress(IntPtr handle, string procedureName);
            }

            private sealed class Unix
            {
                const int RTLD_NOW = 2;

                [DllImport("libdl.so", EntryPoint = "dlopen")]
                public static extern IntPtr dlopen(String fileName, int flags = RTLD_NOW);

                [DllImport("libdl.so", EntryPoint = "dlsym")]
                public static extern IntPtr dlsym(IntPtr handle, String symbol);

                [DllImport("libdl.so", EntryPoint = "dlclose")]
                public static extern int dlclose(IntPtr handle);
            }

            private sealed class MacOS
            {
                const int RTLD_NOW = 2;

                [DllImport("libdl.dylib", EntryPoint = "dlopen")]
                public static extern IntPtr dlopen(String fileName, int flags = RTLD_NOW);

                [DllImport("libdl.dylib", EntryPoint = "dlsym")]
                public static extern IntPtr dlsym(IntPtr handle, String symbol);

                [DllImport("libdl.dylib", EntryPoint = "dlclose")]
                public static extern int dlclose(IntPtr handle);
            }
        }
    }
}
#endif