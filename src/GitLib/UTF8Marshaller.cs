// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace GitLib
{
    public static partial class libgit2
    {
        private static partial class UTF8Marshaller
        {
            private static readonly Encoding UTF8EncodingLocal = new UTF8Encoding(false, false);

            public static unsafe string FromNative(IntPtr buffer)
            {
                var pBuffer = (byte*) buffer;
                if (pBuffer == null) return string.Empty;
                int byteCount = 0;
                while (pBuffer[byteCount] != 0)
                {
                    byteCount++;
                }

                if (byteCount == 0) return string.Empty;
                return UTF8EncodingLocal.GetString(pBuffer, byteCount);
            }

            public static unsafe IntPtr ToNative(string text)
            {
                if (text == null) return IntPtr.Zero;

                var length = UTF8EncodingLocal.GetByteCount(text);

                var pBuffer = (byte*) Marshal.AllocHGlobal(length + 1);
                if (pBuffer == null) return IntPtr.Zero;

                if (length > 0)
                {
                    fixed (char* ptr = text)
                    {
                        Encoding.UTF8.GetBytes(ptr, text.Length, pBuffer, length);
                    }
                }

                pBuffer[length] = 0;

                return new IntPtr(pBuffer);
            }

            public static void Free(IntPtr pointer)
            {
                if (pointer == IntPtr.Zero) return;
                Marshal.FreeHGlobal(pointer);
            }
        }
    }
}