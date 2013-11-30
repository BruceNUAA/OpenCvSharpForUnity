﻿using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace OpenCvSharp.CPlusPlus.Flann
{
#if LANG_JP
    /// <summary>
    /// FLANN 最近傍インデックスクラス
    /// </summary>
#else
    /// <summary>
    /// The FLANN nearest neighbor index class. 
    /// </summary>
#endif
    public class Index : DisposableCvObject
    {
        #region Field
        /// <summary>
        /// sizeof(cv::flann::Index)
        /// </summary>
        public static readonly int SizeOf = FlannInvoke.flann_Index_sizeof();

        private bool _disposed = false;
        #endregion

        #region Init & Disposal
#if LANG_JP
        /// <summary>
        /// 与えられたデータセットの最近傍探索インデックスを作成します．
        /// </summary>
        /// <param name="features">インデックス作成対象となる特徴（点）が格納された， CV_32F 型の行列．この行列のサイズは matrix is num _ features x feature _ dimensionality となります</param>
        /// <param name="params">params – インデックスパラメータを含む構造体．作成されるインデックスの種類は，このパラメータの種類に依存します</param>
#else
        /// <summary>
        /// Constructs a nearest neighbor search index for a given dataset.
        /// </summary>
        /// <param name="features">features – Matrix of type CV _ 32F containing the features(points) to index. The size of the matrix is num _ features x feature _ dimensionality.</param>
        /// <param name="params">Structure containing the index parameters. The type of index that will be constructed depends on the type of this parameter. </param>
#endif
        public Index(Mat features, IndexParams @params)
        {
            if (features == null)
                throw new ArgumentNullException("features");
            if (@params == null)
                throw new ArgumentNullException("params");

            _ptr = FlannInvoke.flann_Index_construct(features.CvPtr, @params.CvPtr);
            if (_ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create Index");
        }

#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
        /// <param name="disposing">
        /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
        /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
        ///</param>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        FlannInvoke.flann_Index_destruct(_ptr);
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

        #region Methods
        #region KnnSearch
#if LANG_JP
        /// <summary>
        /// 複数のクエリ点に対するk-近傍探索を行います．
        /// </summary>
        /// <param name="queries">クエリ点</param>
        /// <param name="indices">求められた最近傍のインデックス</param>
        /// <param name="dists">求められた最近傍までの距離</param>
        /// <param name="knn">この個数分の最近傍を求めます</param>
        /// <param name="params">探索パラメータ</param>
#else
        /// <summary>
        /// Performs a K-nearest neighbor search for multiple query points.
        /// </summary>
        /// <param name="queries">The query points, one per row</param>
        /// <param name="indices">Indices of the nearest neighbors found</param>
        /// <param name="dists">Distances to the nearest neighbors found</param>
        /// <param name="knn">Number of nearest neighbors to search for</param>
        /// <param name="params">Search parameters</param>
#endif
        public void KnnSearch(float[] queries, out int[] indices, out float[] dists, int knn, SearchParams @params)
        {
            if (queries == null)
                throw new ArgumentNullException("queries");
            if (@params == null)
                throw new ArgumentNullException("params");
            if (queries.Length == 0)
                throw new ArgumentException();
            if (knn < 1)
                throw new ArgumentOutOfRangeException("knn");

            indices = new int[knn];
            dists = new float[knn];

            FlannInvoke.flann_Index_knnSearch1(_ptr, queries, queries.Length, indices, dists, knn, @params.CvPtr);
        }
#if LANG_JP
        /// <summary>
        /// 複数のクエリ点に対するk-近傍探索を行います．
        /// </summary>
        /// <param name="queries">クエリ点．1行が1つの点を表します</param>
        /// <param name="indices">求められた最近傍のインデックス</param>
        /// <param name="dists">求められた最近傍までの距離</param>
        /// <param name="knn">この個数分の最近傍を求めます</param>
        /// <param name="params">探索パラメータ</param>
#else
        /// <summary>
        /// Performs a K-nearest neighbor search for multiple query points.
        /// </summary>
        /// <param name="queries">The query points, one per row</param>
        /// <param name="indices">Indices of the nearest neighbors found</param>
        /// <param name="dists">Distances to the nearest neighbors found</param>
        /// <param name="knn">Number of nearest neighbors to search for</param>
        /// <param name="params">Search parameters</param>
#endif
        public void KnnSearch(Mat queries, Mat indices, Mat dists, int knn, SearchParams @params)
        {
            if (queries == null)
                throw new ArgumentNullException("queries");
            if (indices == null)
                throw new ArgumentNullException("indices");
            if (dists == null)
                throw new ArgumentNullException("dists");
            if (@params == null)
                throw new ArgumentNullException("params");

            FlannInvoke.flann_Index_knnSearch2(_ptr, queries.CvPtr, indices.CvPtr, dists.CvPtr, knn, @params.CvPtr);
        }
#if LANG_JP
        /// <summary>
        /// 複数のクエリ点に対するk-近傍探索を行います．
        /// </summary>
        /// <param name="queries">クエリ点．1行が1つの点を表します</param>
        /// <param name="indices">求められた最近傍のインデックス</param>
        /// <param name="dists">求められた最近傍までの距離</param>
        /// <param name="knn">この個数分の最近傍を求めます</param>
        /// <param name="params">探索パラメータ</param>
#else
        /// <summary>
        /// Performs a K-nearest neighbor search for multiple query points.
        /// </summary>
        /// <param name="queries">The query points, one per row</param>
        /// <param name="indices">Indices of the nearest neighbors found</param>
        /// <param name="dists">Distances to the nearest neighbors found</param>
        /// <param name="knn">Number of nearest neighbors to search for</param>
        /// <param name="params">Search parameters</param>
#endif
        public void KnnSearch(Mat queries, out int[] indices, out float[] dists, int knn, SearchParams @params)
        {
            if (queries == null)
                throw new ArgumentNullException("queries");
            if (@params == null)
                throw new ArgumentNullException("params");
            if (knn < 1)
                throw new ArgumentOutOfRangeException("knn");

            indices = new int[knn];
            dists = new float[knn];

            FlannInvoke.flann_Index_knnSearch3(_ptr, queries.CvPtr, indices, dists, knn, @params.CvPtr);
        }
        #endregion
        #region RadiusSearch
#if LANG_JP
        /// <summary>
        /// 与えられたクエリ点に対するradius 最近傍探索を行います．
        /// </summary>
        /// <param name="queries">クエリ点．1行が1つの点を表します [入力]</param>
        /// <param name="indices">求められた最近傍のインデックス [出力]</param>
        /// <param name="dists">求められた最近傍までの距離 [出力]</param>
        /// <param name="radius">探索範囲</param>
        /// <param name="maxResults"></param>
        /// <param name="params">探索パラメータ</param>
#else
        /// <summary>
        /// Performs a radius nearest neighbor search for a given query point.
        /// </summary>
        /// <param name="queries">The query point</param>
        /// <param name="indices">Indices of the nearest neighbors found</param>
        /// <param name="dists">Distances to the nearest neighbors found</param>
        /// <param name="radius">Number of nearest neighbors to search for</param>
        /// <param name="maxResults"></param>
        /// <param name="params">Search parameters</param>
#endif
        public void RadiusSearch(float[] queries, int[] indices, float[] dists, float radius, int maxResults, SearchParams @params)
        {
            if (queries == null)
                throw new ArgumentNullException("queries");
            if (indices == null)
                throw new ArgumentNullException("indices");
            if (dists == null)
                throw new ArgumentNullException("dists");
            if (@params == null)
                throw new ArgumentNullException("params");

            FlannInvoke.flann_Index_radiusSearch1(_ptr, queries, queries.Length, indices, indices.Length, dists, dists.Length, radius, maxResults, @params.CvPtr);
        }
#if LANG_JP
        /// <summary>
        /// 与えられたクエリ点に対するradius 最近傍探索を行います．
        /// </summary>
        /// <param name="queries">クエリ点．1行が1つの点を表します [入力]</param>
        /// <param name="indices">求められた最近傍のインデックス [出力]</param>
        /// <param name="dists">求められた最近傍までの距離 [出力]</param>
        /// <param name="radius">探索範囲</param>
        /// <param name="maxResults"></param>
        /// <param name="params">探索パラメータ</param>
#else
        /// <summary>
        /// Performs a radius nearest neighbor search for a given query point.
        /// </summary>
        /// <param name="queries">The query point</param>
        /// <param name="indices">Indices of the nearest neighbors found</param>
        /// <param name="dists">Distances to the nearest neighbors found</param>
        /// <param name="radius">Number of nearest neighbors to search for</param>
        /// <param name="maxResults"></param>
        /// <param name="params">Search parameters</param>
#endif
        public void RadiusSearch(Mat queries, Mat indices, Mat dists, float radius, int maxResults, SearchParams @params)
        {
            if (queries == null)
                throw new ArgumentNullException("queries");
            if (indices == null)
                throw new ArgumentNullException("indices");
            if (dists == null)
                throw new ArgumentNullException("dists");
            if (@params == null)
                throw new ArgumentNullException("params");

            FlannInvoke.flann_Index_radiusSearch2(_ptr, queries.CvPtr, indices.CvPtr, dists.CvPtr, radius, maxResults, @params.CvPtr);
        }
#if LANG_JP
        /// <summary>
        /// 与えられたクエリ点に対するradius 最近傍探索を行います．
        /// </summary>
        /// <param name="queries">クエリ点．1行が1つの点を表します [入力]</param>
        /// <param name="indices">求められた最近傍のインデックス [出力]</param>
        /// <param name="dists">求められた最近傍までの距離 [出力]</param>
        /// <param name="radius">探索範囲</param>
        /// <param name="maxResults"></param>
        /// <param name="params">探索パラメータ</param>
#else
        /// <summary>
        /// Performs a radius nearest neighbor search for a given query point.
        /// </summary>
        /// <param name="queries">The query point</param>
        /// <param name="indices">Indices of the nearest neighbors found</param>
        /// <param name="dists">Distances to the nearest neighbors found</param>
        /// <param name="radius">Number of nearest neighbors to search for</param>
        /// <param name="maxResults"></param>
        /// <param name="params">Search parameters</param>
#endif
        public void RadiusSearch(Mat queries, int[] indices, float[] dists, float radius, int maxResults, SearchParams @params)
        {
            if (queries == null)
                throw new ArgumentNullException("queries");
            if (indices == null)
                throw new ArgumentNullException("indices");
            if (dists == null)
                throw new ArgumentNullException("dists");
            if (@params == null)
                throw new ArgumentNullException("params");

            FlannInvoke.flann_Index_radiusSearch3(_ptr, queries.CvPtr, indices, indices.Length, dists, dists.Length, radius, maxResults, @params.CvPtr);
        }
        #endregion
        #region Save
#if LANG_JP
        /// <summary>
        /// インデックスをファイルに保存します．
        /// </summary>
        /// <param name="filename">インデックスを保存するファイル名</param>
#else
        /// <summary>
        /// Saves the index to a file.
        /// </summary>
        /// <param name="filename">The file to save the index to</param>
#endif
        public void Save(string filename)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException("filename");
            FlannInvoke.flann_Index_save(_ptr, filename);
        }
        #endregion
        /*
        #region VecLen
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#endif
        public int VecLen()
        {
            return FlannInvoke.flann_Index_veclen(_ptr);
        }
        #endregion
        #region Size
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#endif
        public int Size()
        {
            return FlannInvoke.flann_Index_size(_ptr);
        }
        #endregion
        //*/
        #endregion
    }
}
