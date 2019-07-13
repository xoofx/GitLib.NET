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
            public new static readonly UTF8EncodingRelaxed Default = new UTF8EncodingRelaxed();  
            
            public UTF8EncodingRelaxed() : base(false, false)
            {
            }
        }

        private class UTF8MarshalerBase<T> : ICustomMarshaler where T : Encoding, new()
        {
            private static readonly Encoding EncodingUsed = new T();

            public static unsafe string FromNative(IntPtr pNativeData)
            {
                var pBuffer = (byte*)pNativeData;
                if (pBuffer == null) return string.Empty;
                return EncodingUsed.GetString((byte*)pNativeData, (new Span<byte>(pBuffer, Int32.MaxValue).IndexOf((byte)0)));
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

        private sealed class UTF8MarshalerRelaxed : UTF8MarshalerBase<UTF8EncodingRelaxed>
        {
            private static readonly UTF8MarshalerRelaxed Instance = new UTF8MarshalerRelaxed();

            public static ICustomMarshaler GetInstance(string cookie)
            {
                return Instance;
            }
        }

        private sealed class UTF8MarshalerStrict : UTF8MarshalerBase<UTF8EncodingStrict>
        {
            private static readonly UTF8MarshalerStrict Instance = new UTF8MarshalerStrict();

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

        private sealed class UTF8MarshalerRelaxedNoCleanup : UTF8MarshalerBase<UTF8EncodingRelaxed>
        {
            private static readonly UTF8MarshalerRelaxedNoCleanup Instance = new UTF8MarshalerRelaxedNoCleanup();

            public static ICustomMarshaler GetInstance(string cookie)
            {
                return Instance;
            }

            public override IntPtr MarshalManagedToNative(object managedObj)
            {
                throw new InvalidOperationException($"{nameof(UTF8MarshalerRelaxedNoCleanup)} cannot be used to marshal managed string to libgit2 native without cleanup");
            }

            public override void CleanUpNativeData(IntPtr pNativeData)
            {
            }
        }

        private abstract class CustomMarshaler<TManaged, TMarshal> : ICustomMarshaler where TMarshal : unmanaged
        {
            public abstract void MarshalNativeToManaged(ref TMarshal marshal, out TManaged managed);

            public abstract void MarshalManagedToNative(ref TManaged managed, out TMarshal marshal);

            public abstract void CleanUpNativeData(ref TMarshal marshal);

            public abstract void CleanUpManagedData(ref TManaged managed);
            
            public object MarshalNativeToManaged(IntPtr pNativeData)
            {
                throw new NotImplementedException();
            }

            public IntPtr MarshalManagedToNative(object ManagedObj)
            {
                throw new NotImplementedException();
            }

            public void CleanUpNativeData(IntPtr pNativeData)
            {
                throw new NotImplementedException();
            }

            public void CleanUpManagedData(object ManagedObj)
            {
                throw new NotImplementedException();
            }

            public int GetNativeDataSize()
            {
                throw new NotImplementedException();
            }
        }

        private class BoolToIntMarshaler : CustomMarshaler<bool, int>
        {
            public static readonly BoolToIntMarshaler Instance = new BoolToIntMarshaler();

            public static ICustomMarshaler GetInstance(string cookie)
            {
                return Instance;
            }
            
            public override void MarshalNativeToManaged(ref int marshal, out bool managed)
            {
                managed = marshal != 0;
            }

            public override void MarshalManagedToNative(ref bool managed, out int marshal)
            {
                marshal = managed ? 1 : 0;
            }

            public override void CleanUpNativeData(ref int marshal)
            {
            }

            public override void CleanUpManagedData(ref bool managed)
            {
            }
        }
    }
}