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
    public class AutotunedIndexParams : IndexParams
    {
        #region Field
        /// <summary>
        /// sizeof(cv::flann::AutotunedIndexParams)
        /// </summary>
        public static readonly new int SizeOf = FlannInvoke.flann_AutotunedIndexParams_sizeof();

        private bool _disposed = false;
        #endregion

        #region Properties
        /*
#if LANG_JP
        /// <summary>
        /// どれだけ厳密な最近傍を返すかという，最近傍探索の近似の割合を指定する 0から1の間の値．
        /// このパラメータが大きくなると，より正確な結果が得られますが，探索時間が長くなります．最適な値は，アプリケーションに依存します
        /// </summary>
#else
        /// <summary>
        /// Is a number between 0 and 1 specifying the percentage of the approximate nearest-neighbor searches that return the exact nearest-neighbor. 
        /// Using a higher value for this parameter gives more accurate results, but the search takes longer. 
        /// The optimum value usually depends on the application.
        /// </summary>
#endif
        public float TargetPrecision
        {
            get
            {
                unsafe
                {
                    return *FlannInvoke.flann_AutotunedIndexParams_target_precision(_ptr);
                }
            }
            set
            {
                unsafe
                {
                    *FlannInvoke.flann_AutotunedIndexParams_target_precision(_ptr) = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 最近傍探索時間に対するインデックスの構築時間の重要度を指定します．
        /// その後のインデックス探索時間が高速になるならば，インデックスの構築時間が長くても良いというアプリケーションが存在する一方で，
        /// インデックスの探索時間が多少長くなっても，できるだけ高速にインデックスを構築する必要があるアプリケーションもあります
        /// </summary>
#else
        /// <summary>
        /// Specifies the importance of the index build time raported to the nearest-neighbor search time. 
        /// In some applications it’s acceptable for the index build step to take a long time if the subsequent searches in the index can be performed very fast. 
        /// In other applications it’s required that the index be build as fast as possible even if that leads to slightly longer search times.
        /// </summary>
#endif
        public float BuildWeight
        {
            get
            {
                unsafe
                {
                    return *FlannInvoke.flann_AutotunedIndexParams_build_weight(_ptr);
                }
            }
            set
            {
                unsafe
                {
                    *FlannInvoke.flann_AutotunedIndexParams_build_weight(_ptr) = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// これは，（インデックスの構築時間と探索時間）とインデックスの占有メモリとの，トレードオフを指定するのに利用されます．
        /// 1より小さい値は消費時間を重要視し，1より大きい値はメモリ使用量を重要視します
        /// </summary>
#else
        /// <summary>
        /// Is used to specify the tradeoff between time (index build time and search time) and memory used by the index. 
        /// A value less than 1 gives more importance to the time spent and a value greater than 1 gives more importance to the memory usage.
        /// </summary>
#endif
        public float MemoryWeight
        {
            get
            {
                unsafe
                {
                    return *FlannInvoke.flann_AutotunedIndexParams_memory_weight(_ptr);
                }
            }
            set
            {
                unsafe
                {
                    *FlannInvoke.flann_AutotunedIndexParams_memory_weight(_ptr) = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// パラメータの自動設定アルゴリズムにおけるデータ集合の比率を示す，0から1の間の値．
        /// 全データ集合を用いてアルゴリズムを実行すると，最も正確な結果が得られますが，巨大なデータ集合に対しては長い計算時間がかかります．
        /// このような場合，データをある比率分だけ使うことでアルゴリズムを高速化し，なおかつ，最適なパラメータの良い近似となる結果を得ることができます
        /// </summary>
#else
        /// <summary>
        /// Is a number between 0 and 1 indicating what fraction of the dataset to use in the automatic parameter configuration algorithm. 
        /// Running the algorithm on the full dataset gives the most accurate results, but for very large datasets can take longer than desired. In such case using just a fraction of the data helps speeding up this algorithm while still giving good approximations of the optimum parameters.
        /// </summary>
#endif
        public float SampleFraction
        {
            get
            {
                unsafe
                {
                    return *FlannInvoke.flann_AutotunedIndexParams_sample_fraction(_ptr);
                }
            }
            set
            {
                unsafe
                {
                    *FlannInvoke.flann_AutotunedIndexParams_sample_fraction(_ptr) = value;
                }
            }
        }
        */
        #endregion

        #region Init & Disposal
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target_precision">どれだけ厳密な最近傍を返すかという，最近傍探索の近似の割合を指定する 0から1の間の値．このパラメータが大きくなると，より正確な結果が得られますが，探索時間が長くなります．最適な値は，アプリケーションに依存します</param>
        /// <param name="build_weight">最近傍探索時間に対するインデックスの構築時間の重要度を指定します．
        /// その後のインデックス探索時間が高速になるならば，インデックスの構築時間が長くても良いというアプリケーションが存在する一方で，インデックスの探索時間が多少長くなっても，できるだけ高速にインデックスを構築する必要があるアプリケーションもあります</param>
        /// <param name="memory_weight">これは，（インデックスの構築時間と探索時間）とインデックスの占有メモリとの，トレードオフを指定するのに利用されます．
        /// 1より小さい値は消費時間を重要視し，1より大きい値はメモリ使用量を重要視します</param>
        /// <param name="sample_fraction">パラメータの自動設定アルゴリズムにおけるデータ集合の比率を示す，0から1の間の値．
        /// 全データ集合を用いてアルゴリズムを実行すると，最も正確な結果が得られますが，巨大なデータ集合に対しては長い計算時間がかかります．
        /// このような場合，データをある比率分だけ使うことでアルゴリズムを高速化し，なおかつ，最適なパラメータの良い近似となる結果を得ることができます</param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target_precision">Is a number between 0 and 1 specifying the percentage of the approximate nearest-neighbor searches that return the exact nearest-neighbor. 
        /// Using a higher value for this parameter gives more accurate results, but the search takes longer. The optimum value usually depends on the application.</param>
        /// <param name="build_weight">Specifies the importance of the index build time raported to the nearest-neighbor search time. 
        /// In some applications it’s acceptable for the index build step to take a long time if the subsequent searches in the index can be performed very fast. 
        /// In other applications it’s required that the index be build as fast as possible even if that leads to slightly longer search times.</param>
        /// <param name="memory_weight">Is used to specify the tradeoff between time (index build time and search time) and memory used by the index. 
        /// A value less than 1 gives more importance to the time spent and a value greater than 1 gives more importance to the memory usage.</param>
        /// <param name="sample_fraction">Is a number between 0 and 1 indicating what fraction of the dataset to use in the automatic parameter configuration algorithm. 
        /// Running the algorithm on the full dataset gives the most accurate results, but for very large datasets can take longer than desired. 
        /// In such case using just a fraction of the data helps speeding up this algorithm while still giving good approximations of the optimum parameters.</param>
#endif
        public AutotunedIndexParams(float target_precision = 0.9f, float build_weight = 0.01f, float memory_weight = 0, float sample_fraction = 0.1f)
        {
            _ptr = FlannInvoke.flann_AutotunedIndexParams_construct(target_precision, build_weight, memory_weight, sample_fraction);
            if (_ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create AutotunedIndexParams");
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
                        FlannInvoke.flann_AutotunedIndexParams_destruct(_ptr);
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
    }
}
