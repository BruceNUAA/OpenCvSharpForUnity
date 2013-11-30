﻿/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp.MachineLearning
{
#if LANG_JP
    /// <summary>
    /// 決定木の学習パラメータ
    /// </summary>
#else
	/// <summary>
    /// Decision tree training parameters
    /// </summary>
#endif
    public class CvDTreeParams : DisposableCvObject
    {
        protected float[] _priors;
        protected GCHandle _handle;
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool _disposed = false;

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
#else
        /// <summary>
		/// Default constructor
		/// </summary>
#endif
        public CvDTreeParams()
        {
            _ptr = MLInvoke.CvDTreeParams_construct_default();
            _priors = null;
        }
#if LANG_JP
        /// <summary>
        /// 学習データを与えて初期化
        /// </summary>
		/// <param name="max_depth">このパラメータは木が取りうる最大の深さを決定する．学習アルゴリズムは，ノードの深さが max_depth  よりも小さいならば，それを分岐させようとする．他の終了条件が満たされた場合や（セクション始めにある学習手続きの概要を参照）， あるいは/さらに，木が刈り込まれた場合など，実際の深さはもっと浅いかもしれない．</param>
		/// <param name="min_sample_count">あるノードに対するサンプル数がこのパラメータ値よりも少ない場合，そのノードは分岐しない． </param>
		/// <param name="regression_accuracy">別の終了条件 - 回帰木の場合のみ． 推定されたノード値が，そのノードの学習サンプルの応答に対して，このパラメータ値よりも低い精度を持つ場合，ノードはそれ以上分岐しなくなる．</param>
		/// <param name="use_surrogates">trueの場合，代理分岐が構築される． 代理分岐は観測値データの欠損を処理する場合や，変数の重要度の推定に必要である．</param>
		/// <param name="max_categories">学習手続きが分岐を作るときの離散変数が max_categoriesよりも多くの値を取ろうとするならば， （アルゴリズムが指数関数的であるので）正確な部分集合推定を行う場合に非常に時間がかかる可能性がある． 代わりに，（MLを含む）多くの決定木エンジンが，全サンプルを max_categories 個のクラスタに分類することによって （つまりいくつかのカテゴリは一つにマージされる），この場合の次善最適分岐を見つけようとする．このテクニックは，N(>2)-クラス分類問題においてのみ適用されることに注意する． 回帰および 2-クラス分類の場合は，このような手段をとらなくても効率的に最適分岐を見つけることができるので，このパラメータは使用されない．</param>
		/// <param name="cv_folds">このパラメータが >1 の場合，木は cv_folds 分割交差検証法により刈り込まれる． </param>
		/// <param name="use_1se_rule">true の場合，木は刈り込み手続きによって切り捨てられる． これにより，コンパクトで学習データノイズに対してより耐性を持つような木になるが，決定木の正確さはやや劣る． </param>
		/// <param name="truncate_pruned_tree">true の場合，（Tn≤CvDTree::pruned_tree_idxである） カットオフノードが，木から物理的に削除される． そうでない場合は，それらは削除はされず，CvDTree::pruned_tree_idx を減らす（例えば -1 を設定する） ことによって，オリジナルの刈り込みされていない（あるいは積極的には刈り込まれていない）木からの結果を得ることができる．</param>
		/// <param name="priors">クラスラベル値によって保存されたクラス事前確率の配列． このパラメータは，ある特定のクラスに対する決定木の優先傾向を調整するために用いられる． 例えば，もしユーザがなんらかの珍しい例外的発生を検出したいと考えた場合，学習データは，おそらく例外的なケースよりもずっと多くの正常なケースを含んでいるので， 全ケースが正常であるとみなすだけで，非常に優れた分類性能が実現されるだろう． このように例外ケースを無視して分類性能を上げることを避けるために，事前確率を指定することができる． 例外的なケースの確率を人工的に増加させる（0.5 まで，あるいはそれ以上に）ことで，分類に失敗した例外の重みがより大きくなり，木は適切に調節される． </param>
#else
		/// <summary>
		/// Training constructor
		/// </summary>
		/// <param name="max_depth">This parameter specifies the maximum possible depth of the tree. That is the training algorithms attempts to split a node while its depth is less than max_depth. The actual depth may be smaller if the other termination criteria are met (see the outline of the training procedure in the beginning of the section), and/or if the tree is pruned. </param>
		/// <param name="min_sample_count">A node is not split if the number of samples directed to the node is less than the parameter value. </param>
		/// <param name="regression_accuracy">Another stop criteria - only for regression trees. As soon as the estimated node value differs from the node training samples responses by less than the parameter value, the node is not split further. </param>
		/// <param name="use_surrogates">If true, surrogate splits are built. Surrogate splits are needed to handle missing measurements and for variable importance estimation. </param>
		/// <param name="max_categories">If a discrete variable, on which the training procedure tries to make a split, takes more than max_categories values, the precise best subset estimation may take a very long time (as the algorithm is exponential). Instead, many decision trees engines (including ML) try to find sub-optimal split in this case by clustering all the samples into max_categories clusters (i.e. some categories are merged together). Note that this technique is used only in N(>2)-class classification problems. In case of regression and 2-class classification the optimal split can be found efficiently without employing clustering, thus the parameter is not used in these cases. </param>
		/// <param name="cv_folds">If this parameter is >1, the tree is pruned using cv_folds-fold cross validation. </param>
		/// <param name="use_1se_rule">If true, the tree is truncated a bit more by the pruning procedure. That leads to compact, and more resistant to the training data noise, but a bit less accurate decision tree. </param>
		/// <param name="truncate_pruned_tree">If true, the cut off nodes (with Tn≤CvDTree::pruned_tree_idx) are physically removed from the tree. Otherwise they are kept, and by decreasing CvDTree::pruned_tree_idx (e.g. setting it to -1) it is still possible to get the results from the original un-pruned (or pruned less aggressively) tree. </param>
		/// <param name="priors">The array of a priori class probabilities, sorted by the class label value. The parameter can be used to tune the decision tree preferences toward a certain class. For example, if users want to detect some rare anomaly occurrence, the training base will likely contain much more normal cases than anomalies, so a very good classification performance will be achieved just by considering every case as normal. To avoid this, the priors can be specified, where the anomaly probability is artificially increased (up to 0.5 or even greater), so the weight of the misclassified anomalies becomes much bigger, and the tree is adjusted properly. </param>
#endif
        public CvDTreeParams(int max_depth, int min_sample_count, float regression_accuracy, bool use_surrogates,
                   int max_categories, int cv_folds, bool use_1se_rule, bool truncate_pruned_tree, float[] priors)
        {					
            IntPtr priors_ptr = IntPtr.Zero;
            if (priors != null)
            {
                _handle = GCHandle.Alloc(priors, GCHandleType.Pinned);
                priors_ptr = _handle.AddrOfPinnedObject();
            }

            _ptr = MLInvoke.CvDTreeParams_construct(max_depth, min_sample_count, regression_accuracy, use_surrogates, max_categories, 
                cv_folds, use_1se_rule, truncate_pruned_tree, priors_ptr);

            _priors = priors;
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
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {
                        if (_handle.IsAllocated)
                        {
                            _handle.Free();
                        }
                    }
                    if (IsEnabledDispose)
                    {
                        MLInvoke.CvDTreeParams_destruct(_ptr);
                    }
                    this._disposed = true;
                }
                finally
                {
                    // 親の解放処理
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Properties

#if LANG_JP
        /// <summary>
        /// 学習手続きが分岐を作るときの離散変数が MaxCategoriesよりも多くの値を取ろうとするならば，
		/// （アルゴリズムが指数関数的であるので）正確な部分集合推定を行う場合に非常に時間がかかる可能性がある． 
		/// 代わりに，（MLを含む）多くの決定木エンジンが，全サンプルを MaxCategories 個のクラスタに分類することによって
		/// （つまりいくつかのカテゴリは一つにマージされる），この場合の次善最適分岐を見つけようとする．
		/// このテクニックは，N(>2)-クラス分類問題においてのみ適用されることに注意する． 
		/// 回帰および 2-クラス分類の場合は，このような手段をとらなくても効率的に最適分岐を見つけることができるので，このパラメータは使用されない． 
        /// </summary>
#else
        /// <summary>
        /// If a discrete variable, on which the training procedure tries to make a split, takes more than MaxCategories values, 
		/// the precise best subset estimation may take a very long time (as the algorithm is exponential). 
		/// Instead, many decision trees engines (including ML) try to find sub-optimal split in this case by clustering 
		/// all the samples into MaxCategories clusters (i.e. some categories are merged together).
		/// Note that this technique is used only in N(>2)-class classification problems. In case of regression and 2-class classification
		/// the optimal split can be found efficiently without employing clustering, thus the parameter is not used in these cases. 
        /// </summary>
#endif
        public int MaxCategories
        {
            get { return MLInvoke.CvDTreeParams_max_categories_get(_ptr); }
            set { MLInvoke.CvDTreeParams_max_categories_set(_ptr, value); }
        }
#if LANG_JP
        /// <summary>
        /// このパラメータは木が取りうる最大の深さを決定する．学習アルゴリズムは，ノードの深さが max_depth  よりも小さいならば，
		/// それを分岐させようとする．他の終了条件が満たされた場合や（セクション始めにある学習手続きの概要を参照），
		/// あるいは/さらに，木が刈り込まれた場合など，実際の深さはもっと浅いかもしれない． 
        /// </summary>
#else
		/// <summary>
        /// This parameter specifies the maximum possible depth of the tree. That is the training algorithms attempts to split a node 
		/// while its depth is less than max_depth. The actual depth may be smaller if the other termination criteria are met
		/// (see the outline of the training procedure in the beginning of the section), and/or if the tree is pruned. 
        /// </summary>
#endif
        public int MaxDepth
        {
            get { return MLInvoke.CvDTreeParams_max_depth_get(_ptr); }
            set { MLInvoke.CvDTreeParams_max_depth_set(_ptr, value); }
        }
#if LANG_JP
        /// <summary>
        /// あるノードに対するサンプル数がこのパラメータ値よりも少ない場合，そのノードは分岐しない．
        /// </summary>
#else
		/// <summary>
        /// A node is not split if the number of samples directed to the node is less than the parameter value. 
        /// </summary>
#endif
        public int MinSampleCount
        {
            get { return MLInvoke.CvDTreeParams_min_sample_count_get(_ptr); }
            set { MLInvoke.CvDTreeParams_min_sample_count_set(_ptr, value); }
        }
#if LANG_JP
        /// <summary>
        /// このパラメータが >1 の場合，木は cv_folds 分割交差検証法により刈り込まれる． 
        /// </summary>
#else
		/// <summary>
        /// If this parameter is >1, the tree is pruned using cv_folds-fold cross validation. 
        /// </summary>
#endif
        public int CvFolds
        {
            get { return MLInvoke.CvDTreeParams_cv_folds_get(_ptr); }
            set { MLInvoke.CvDTreeParams_cv_folds_set(_ptr, value); }
        }

#if LANG_JP
        /// <summary>
        /// trueの場合，代理分岐が構築される． 代理分岐は観測値データの欠損を処理する場合や，変数の重要度の推定に必要である．
        /// </summary>
#else
		/// <summary>
        /// If true, surrogate splits are built. Surrogate splits are needed to handle missing measurements and for variable importance estimation. 
        /// </summary>
#endif
        public bool UseSurrogates
        {
            get { return MLInvoke.CvDTreeParams_use_surrogates_get(_ptr); }
            set { MLInvoke.CvDTreeParams_use_surrogates_set(_ptr, value); }
        }
#if LANG_JP
        /// <summary>
        /// true の場合，木は刈り込み手続きによって切り捨てられる．
		/// これにより，コンパクトで学習データノイズに対してより耐性を持つような木になるが，決定木の正確さはやや劣る． 
        /// </summary>
#else
		/// <summary>
        /// If true, the tree is truncated a bit more by the pruning procedure. 
		/// That leads to compact, and more resistant to the training data noise, but a bit less accurate decision tree. 
        /// </summary>
#endif
        public bool Use1seRule
        {
            get { return MLInvoke.CvDTreeParams_use_1se_rule_get(_ptr); }
            set { MLInvoke.CvDTreeParams_use_1se_rule_set(_ptr, value); }
        }
#if LANG_JP
        /// <summary>
        /// true の場合，（Tn≤CvDTree::PrunedTreeIdxである） カットオフノードが，木から物理的に削除される． 
		/// そうでない場合は，それらは削除はされず，CvDTree::pruned_tree_idx を減らす（例えば -1 を設定する） ことによって，
		/// オリジナルの刈り込みされていない（あるいは積極的には刈り込まれていない）木からの結果を得ることができる． 
        /// </summary>
#else
		/// <summary>
        /// If true, the cut off nodes (with Tn≤CvDTree::pruned_tree_idx) are physically removed from the tree. 
		/// Otherwise they are kept, and by decreasing CvDTree::PrunedTreeIdx (e.g. setting it to -1) 
		/// it is still possible to get the results from the original un-pruned (or pruned less aggressively) tree. 
        /// </summary>
#endif
        public bool TruncatePrunedTree
        {
            get { return MLInvoke.CvDTreeParams_truncate_pruned_tree_get(_ptr); }
            set { MLInvoke.CvDTreeParams_truncate_pruned_tree_set(_ptr, value); }
        }

#if LANG_JP
        /// <summary>
        /// 別の終了条件 - 回帰木の場合のみ． 推定されたノード値が，そのノードの学習サンプルの応答に対して，
		/// このパラメータ値よりも低い精度を持つ場合，ノードはそれ以上分岐しなくなる．
        /// </summary>
#else
		/// <summary>
        /// Another stop criteria - only for regression trees. As soon as the estimated node value differs 
		/// from the node training samples responses by less than the parameter value, the node is not split further. 
        /// </summary>
#endif
        public float RegressionAccuracy
        {
            get { return MLInvoke.CvDTreeParams_regression_accuracy_get(_ptr); }
            set { MLInvoke.CvDTreeParams_regression_accuracy_set(_ptr, value); }
        }

#if LANG_JP
        /// <summary>
        /// クラスラベル値によって保存されたクラス事前確率の配列． 
		/// このパラメータは，ある特定のクラスに対する決定木の優先傾向を調整するために用いられる． 例えば，
		/// もしユーザがなんらかの珍しい例外的発生を検出したいと考えた場合，学習データは，おそらく例外的なケースよりも
		/// ずっと多くの正常なケースを含んでいるので， 全ケースが正常であるとみなすだけで，非常に優れた分類性能が実現されるだろう． 
		/// このように例外ケースを無視して分類性能を上げることを避けるために，事前確率を指定することができる． 
		/// 例外的なケースの確率を人工的に増加させる（0.5 まで，あるいはそれ以上に）ことで，分類に失敗した例外の重みがより大きくなり，木は適切に調節される． 
        /// </summary>
#else
		/// <summary>
        /// The array of a priori class probabilities, sorted by the class label value. 
		/// The parameter can be used to tune the decision tree preferences toward a certain class. 
		/// For example, if users want to detect some rare anomaly occurrence, the training base will likely contain much more normal cases
		/// than anomalies, so a very good classification performance will be achieved just by considering every case as normal. 
		/// To avoid this, the priors can be specified, where the anomaly probability is artificially increased (up to 0.5 or even greater), 
		/// so the weight of the misclassified anomalies becomes much bigger, and the tree is adjusted properly. 
        /// </summary>
#endif
        public float[] Priors
        {
            get { return _priors; }
            set 
            { 
                _priors = value;

                if (_handle.IsAllocated)
                {
                    _handle.Free();
                }
                if (value != null)
                {
                    _handle = GCHandle.Alloc(value, GCHandleType.Pinned);
                    unsafe
                    {
                        MLInvoke.CvDTreeParams_priors_set(_ptr, (float*)_handle.AddrOfPinnedObject());
                    }
                }
            }
        }
		#endregion
    }
}
