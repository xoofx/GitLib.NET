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
        private sealed class UTF8EncodingStrict : UTF8Encoding
        {
            public UTF8EncodingStrict() : base(false, true)
            {
            }
        }

        private sealed class UTF8EncodingRelaxed : UTF8Encoding
        {
            public UTF8EncodingRelaxed() : base(false, false)
            {
            }
        }

        private class UTF8MarshallerBase<T> : ICustomMarshaler where T : Encoding, new()
        {
            private static readonly Encoding EncodingUsed = new T();

            public static unsafe string FromNative(IntPtr pNativeData)
            {
                var pBuffer = (byte*)pNativeData;
                if (pBuffer == null) return string.Empty;
                while(*pBuffer != 0)
                {
                    pBuffer++;
                }

                var byteCount = (int)(pBuffer - (byte*) pNativeData);
                if (byteCount == 0) return string.Empty;
                return EncodingUsed.GetString((byte*)pNativeData, byteCount);
            }

            public static unsafe IntPtr ToNative(string text, bool strict = false)
            {
                if (text == null) return IntPtr.Zero;

                var length = EncodingUsed.GetByteCount(text);

                var pBuffer = (byte*)Marshal.AllocHGlobal(length + 1);
                if (pBuffer == null) return IntPtr.Zero;

                if (length > 0)
                {
                    fixed (char* ptr = text)
                    {
                        EncodingUsed.GetBytes(ptr, text.Length, pBuffer, length);
                    }
                }

                pBuffer[length] = 0;

                return new IntPtr(pBuffer);
            }

            public static void FreeNative(IntPtr pNativeData)
            {
                if (pNativeData == IntPtr.Zero) return;
                Marshal.FreeHGlobal(pNativeData);
            }

            public virtual object MarshalNativeToManaged(IntPtr pNativeData)
            {
                return FromNative(pNativeData);
            }

            public virtual IntPtr MarshalManagedToNative(object managedObj)
            {
                var text = (string) managedObj;
                return ToNative(text);
            }

            public virtual void CleanUpNativeData(IntPtr pNativeData)
            {
                FreeNative(pNativeData);
            }

            public virtual void CleanUpManagedData(object ManagedObj)
            {
            }

            public int GetNativeDataSize()
            {
                return -1;
            }
        }

        private sealed class UTF8MarshallerRelaxed : UTF8MarshallerBase<UTF8EncodingRelaxed>
        {
            private static readonly UTF8MarshallerRelaxed Instance = new UTF8MarshallerRelaxed();

            public static ICustomMarshaler GetInstance(string cookie)
            {
                return Instance;
            }
        }

        private sealed class UTF8MarshallerStrict : UTF8MarshallerBase<UTF8EncodingStrict>
        {
            private static readonly UTF8MarshallerStrict Instance = new UTF8MarshallerStrict();

            public static ICustomMarshaler GetInstance(string cookie)
            {
                return Instance;
            }

            public override IntPtr MarshalManagedToNative(object managedObj)
            {
                var text = (string)managedObj;
                return ToNative(text, true);
            }
        }

        private sealed class UTF8MarshallerRelaxedNoCleanup : UTF8MarshallerBase<UTF8EncodingRelaxed>
        {
            private static readonly UTF8MarshallerRelaxedNoCleanup Instance = new UTF8MarshallerRelaxedNoCleanup();

            public static ICustomMarshaler GetInstance(string cookie)
            {
                return Instance;
            }

            public override IntPtr MarshalManagedToNative(object managedObj)
            {
                throw new InvalidOperationException($"{nameof(UTF8MarshallerRelaxedNoCleanup)} cannot be used to marshal managed string to libgit2 native without cleanup");
            }

            public override void CleanUpNativeData(IntPtr pNativeData)
            {
            }
        }
    }
}