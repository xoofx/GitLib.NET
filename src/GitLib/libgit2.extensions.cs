// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace GitLib
{
    public static partial class libgit2
    {
        private const string GitLibName = "git2-572e4d8";

#if NET472
        static libgit2()
        {
            if (NativeLibrary.IsWindows())
            {
                var dllPath = Path.Combine(GetExecutingAssemblyDirectory(), "lib", "win32", IntPtr.Size == 4 ? "x86" : "x64", GitLibName + ".dll");
                NativeLibrary.TryLoad(dllPath, out var _);
            }
        }
#endif        
        
        private static string GetExecutingAssemblyDirectory()
        {
            var path = Assembly.GetExecutingAssembly().CodeBase;
            if (!File.Exists(path))
            {
                path = Assembly.GetExecutingAssembly().Location;
            }
            else if (path.StartsWith("file:///"))
            {
                path = path.Substring(8).Replace('/', '\\');
            }
            else if (path.StartsWith("file://"))
            {
                path = "\\\\" + path.Substring(7).Replace('/', '\\');
            }
            return Path.GetDirectoryName(path);
        }
        public readonly partial struct git_result
        {
            public bool Success => Value >= 0;

            public bool Failure => Value < 0;

            public git_error_code ErrorCode => (git_error_code) Value;

            public git_result Check()
            {
                if (Failure)
                {
                    var errorMessage = git_error_last().ToString();
                    throw new GitException(ErrorCode, errorMessage);
                }
                return this;
            }
        }

        public partial struct size_t
        {
            public static implicit operator long(size_t from) => from.Value.ToInt64();

            public static implicit operator size_t(long from) => new size_t(new IntPtr(from));

            public static implicit operator int(size_t from) => from.Value.ToInt32();

            public static implicit operator size_t(int from) => new size_t(new IntPtr(from));
        }

        [DebuggerDisplay("Count = {count}")]
        public partial struct git_strarray : IEnumerable<string>
        {
            /// <summary>
            /// gets the number of strings in this array.
            /// </summary>
            public int Length => count;
            
            /// <summary>
            /// Gets the string from the specified array index.
            /// </summary>
            /// <param name="index">An index into the array</param>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            public string this[int index]
            {
                get
                {
                    if (index < 0 || index > count) throw new ArgumentOutOfRangeException();
                    unsafe
                    {
                        return UTF8Marshaller.FromNative(((IntPtr*)strings)[index]);
                    }
                }
            }

            /// <summary>
            /// Creates a managed array of string from this git native array of string.
            /// </summary>
            /// <returns>A managed array of string from this git native array of string.</returns>
            public string[] ToArray()
            {
                var array = new string[count];
                for(int i = 0; i < count; i++)
                {
                    array[i] = this[i];
                }

                return array;
            }

            /// <summary>
            /// Allocate a new instance of git native array of string from the specified array of string.
            /// The returned instance must be free by calling later <see cref="Free"/>
            /// </summary>
            /// <param name="array">A managed array of string</param>
            /// <returns>A git native array of string</returns>
            public static unsafe git_strarray Allocate(string[] array)
            {
                if (array == null || array.Length == 0) return new git_strarray();

                var nativeArray = new git_strarray
                {
                    strings = Marshal.AllocHGlobal(array.Length * IntPtr.Size), 
                    count = array.Length
                };
                for (int i = 0; i < array.Length; i++)
                {
                    ((IntPtr*) nativeArray.strings)[i] = UTF8Marshaller.ToNative(array[i]);
                }

                return nativeArray;
            }

            /// <summary>
            /// Frees this instance. Must have been created by <see cref="Allocate"/>. This method should not be call
            /// on <see cref="git_strarray"/> returned by git methods. 
            /// </summary>
            public unsafe void Free()
            {
                for (int i = 0; i < count; i++)
                {
                    UTF8Marshaller.Free(((IntPtr*) strings)[i]);
                }

                count = 0;
                Marshal.FreeHGlobal(strings);
                strings = IntPtr.Zero;
            }

            public Enumerator GetEnumerator()
            {
                return new Enumerator(this);
            }

            IEnumerator<string> IEnumerable<string>.GetEnumerator()
            {
                return GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public struct Enumerator : IEnumerator<string>
            {
                private git_strarray _array;
                private int index;

                public Enumerator(git_strarray array) : this()
                {
                    _array = array;
                    index = -1;
                }

                public void Dispose()
                {
                }

                public bool MoveNext()
                {
                    if ((index + 1) < _array.count)
                    {
                        index++;
                        return true;
                    }
                    return false;
                }

                public void Reset()
                {
                    index = -1;
                }

                public string Current
                {
                    get
                    {
                        if (index < 0) throw new InvalidOperationException("Must call MoveNext() before Current");
                        
                        if (index >= _array.count) throw new InvalidOperationException("Cannot call Current after last element");
                        
                        return _array[index];
                    }
                }

                object IEnumerator.Current => Current;
            }
        }

        public partial struct git_oid
        {
            public override string ToString()
            {
                unsafe
                {
                    var builder = new StringBuilder();
                    for (int i = 0; i < 20; i++)
                    {
                        var b = id[i];
                        builder.Append(b.ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
        }

        public partial struct git_error
        {
            public override string ToString()
            {
                return UTF8Marshaller.FromNative(message);
            }
        }
    }
}