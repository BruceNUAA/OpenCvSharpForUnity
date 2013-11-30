﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Flann
{
#if LANG_JP
    /// <summary>
    /// 階層型 k-means tree でインデックスが表現されます．
    /// </summary>
#else
    /// <summary>
    /// When passing an object of this type the index constructed will be a hierarchical k-means tree.
    /// </summary>
#endif
    public class KMeansIndexParams : IndexParams
    {
        #region Field
        /// <summary>
        /// sizeof(cv::flann::KMeansIndexParams)
        /// </summary>
        public static readonly new int SizeOf = FlannInvoke.flann_KMeansIndexParams_sizeof();

        private bool _disposed = false;
        #endregion

        #region Properties
        /*
#if LANG_JP
        /// <summary>
        /// 階層型 k-means tree で利用される branching ファクタ
        /// </summary>
#else
        /// <summary>
        /// The branching factor to use for the hierarchical k-means tree
        /// </summary>
#endif
        public int Branching
        {
            get
            {
                unsafe
                {
                    return *FlannInvoke.flann_KMeansIndexParams_branching(_ptr);
                }
            }
            set
            {
                unsafe
                {
                    *FlannInvoke.flann_KMeansIndexParams_branching(_ptr) = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// k-means tree を作成する際の，k-means クラスタリングステージでの反復数の上限．ここで -1 は，k-means クラスタリングが収束するまで続けられることを意味します
        /// </summary>
#else
        /// <summary>
        /// The maximum number of iterations to use in the k-means clustering
        /// stage when building the k-means tree. A value of -1 used here means that the k-means clustering should be iterated until convergence
        /// </summary>
#endif
        public int Iterations
        {
            get
            {
                unsafe
                {
                    return *FlannInvoke.flann_KMeansIndexParams_iterations(_ptr);
                }
            }
            set
            {
                unsafe
                {
                    *FlannInvoke.flann_KMeansIndexParams_iterations(_ptr) = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// k-means クラスタリングの初期中心を選択するアルゴリズム．
        /// </summary>
#else
        /// <summary>
        /// The algorithm to use for selecting the initial centers when performing a k-means clustering step. 
        /// </summary>
#endif
        public FlannCentersInit CentersInit
        {
            get
            {
                unsafe
                {
                    return *FlannInvoke.flann_KMeansIndexParams_centers_init(_ptr);
                }
            }
            set
            {
                unsafe
                {
                    *FlannInvoke.flann_KMeansIndexParams_centers_init(_ptr) = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// このパラメータ（クラスタ境界インデックス）は，階層的 k-means tree の探索方法に影響を与えます． 
        /// cb_index が0の場合，最も近い中心のクラスタが，次に探索される k-means 領域になります．0より大きい値の場合も，領域サイズが考慮されます
        /// </summary>
#else
        /// <summary>
        /// This parameter (cluster boundary index) influences the
        /// way exploration is performed in the hierarchical kmeans tree. When cb_index is zero the next kmeans domain to be explored 
        /// is choosen to be the one with the closest center. A value greater then zero also takes into account the size of the domain.
        /// </summary>
#endif
        public float CbIndex
        {
            get
            {
                unsafe
                {
                    return *FlannInvoke.flann_KMeansIndexParams_cb_index(_ptr);
                }
            }
            set
            {
                unsafe
                {
                    *FlannInvoke.flann_KMeansIndexParams_cb_index(_ptr) = value;
                }
            }
        }
        //*/
        #endregion

        #region Init & Disposal
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="branching">階層型 k-means tree で利用される branching ファクタ</param>
        /// <param name="iterations">k-means tree を作成する際の，k-means クラスタリングステージでの反復数の上限．ここで -1 は，k-means クラスタリングが収束するまで続けられることを意味します</param>
        /// <param name="centers_init">k-means クラスタリングの初期中心を選択するアルゴリズム．</param>
        /// <param name="cb_index">このパラメータ（クラスタ境界インデックス）は，階層的 k-means tree の探索方法に影響を与えます． cb_index が0の場合，最も近い中心のクラスタが，次に探索される k-means 領域になります．0より大きい値の場合も，領域サイズが考慮されます</param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="branching">The branching factor to use for the hierarchical k-means tree</param>
        /// <param name="iterations">The maximum number of iterations to use in the k-means clustering stage when building the k-means tree. A value of -1 used here means that the k-means clustering should be iterated until convergence</param>
        /// <param name="centers_init">The algorithm to use for selecting the initial centers when performing a k-means clustering step. </param>
        /// <param name="cb_index">This parameter (cluster boundary index) influences the way exploration is performed in the hierarchical kmeans tree. When cb_index is zero the next kmeans domain to be explored is choosen to be the one with the closest center. A value greater then zero also takes into account the size of the domain.</param>
#endif
        public KMeansIndexParams(int branching = 32, int iterations = 11, FlannCentersInit centers_init = FlannCentersInit.Random, float cb_index = 0.2f)
        {
            _ptr = FlannInvoke.flann_KMeansIndexParams_construct(branching, iterations, centers_init, cb_index);
            if (_ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create KMeansIndexParams");
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
                        FlannInvoke.flann_KMeansIndexParams_destruct(_ptr);
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
        /*
#if LANG_JP
        /// <summary>
        /// 階層的 k-means tree を構築し，クラスタの分散を最小にするカットを選択することで，与え得られた点群を分類します．
        /// </summary>
        /// <param name="features">クラスタリングされる点</param>
        /// <param name="centers">得られるクラスタの中心．この行列の行数は要求クラスタ数を表します．
        /// しかし，階層的 k-means tree のカットを選択する方法により，求められるクラスタ数は，要求クラスタ数より小さい値 (branching-1)*k+1 の最大値になります．
        /// ここで branching は tree の branching ファクタ（KMeansIndexParams の説明を参照してください）</param>
        /// <returns>求められたクラスタ数</returns>
#else
        /// <summary>
        /// Clusters the given points by constructing a hierarchical k-means tree and choosing a cut in the tree that minimizes the cluster’s variance.
        /// </summary>
        /// <param name="features">The points to be clustered</param>
        /// <param name="centers">The centers of the clusters obtained. The number of rows in this matrix represents the number of clusters desired, 
        /// however, because of the way the cut in the hierarchical tree is choosen, the number of clusters computed will be 
        /// the highest number of the form (branching-1)*k+1 that’s lower than the number of clusters desired, where branching is the tree’s</param>
        /// <returns>the number of clusters computed</returns>
#endif
        public int HierarchicalClustering(Mat features, Mat centers)
        {
            if (features == null)
                throw new ArgumentNullException("features");
            if (centers == null)
                throw new ArgumentNullException("centers");

            return FlannInvoke.flann_hierarchicalClustering(features.CvPtr, centers.CvPtr, _ptr);
        }
        */
        #endregion
    }
}
