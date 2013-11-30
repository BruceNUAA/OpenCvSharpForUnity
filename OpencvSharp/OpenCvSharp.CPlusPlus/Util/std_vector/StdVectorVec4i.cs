﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec4iElem
    {
        /// <summary>
        /// 
        /// </summary>
        public int V1;
        /// <summary>
        /// 
        /// </summary>
        public int V2;
        /// <summary>
        /// 
        /// </summary>
        public int V3;
        /// <summary>
        /// 
        /// </summary>
        public int V4;
    }

    /// <summary>
    /// 
    /// </summary>
    public class StdVectorVec4i : DisposableCvObject, IStdVector
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool _disposed = false;

        #region Init and Dispose
        /// <summary>
        /// 
        /// </summary>
        public StdVectorVec4i()
        {
            this._ptr = CppInvoke.vector_cvVec4i_new1();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public StdVectorVec4i(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException("size");
            this._ptr = CppInvoke.vector_cvVec4i_new2(new IntPtr(size));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public StdVectorVec4i(Vec4iElem[] data)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            this._ptr = CppInvoke.vector_cvVec4i_new3(data, new IntPtr(data.Length));
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                try
                {
                    if (IsEnabledDispose)
                    {
                        CppInvoke.vector_cvVec2f_delete(_ptr);
                    }
                    this._disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size
        {
            get { return CppInvoke.vector_cvVec4i_getSize(_ptr).ToInt32(); }
        }
        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr
        {
            get { return CppInvoke.vector_cvVec4i_getPointer(_ptr); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public Vec4iElem[] ToArray()
        {
            return ToArray<Vec4iElem>();
        }
        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <typeparam name="T">structure that has four int members (ex. CvLineSegmentPoint, CvRect)</typeparam>
        /// <returns></returns>
        public T[] ToArray<T>() where T : struct
        {
            Type t = typeof(T);
            int typeSize = Marshal.SizeOf(typeof(T));
            if (typeSize != sizeof(int) * 4)
            {
                throw new OpenCvSharpException();
            }

            int arySize = Size;
            if (arySize == 0)
            {
                return new T[0];
            }
            else
            {
                T[] dst = new T[arySize];
                using (ArrayAddress1<T> dstPtr = new ArrayAddress1<T>(dst))
                {
                    Util.CopyMemory(dstPtr, ElemPtr, typeSize * dst.Length);
                }
                return dst;
            }
        }
        #endregion
    }
}
