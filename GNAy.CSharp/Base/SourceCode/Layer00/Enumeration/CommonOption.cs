using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Diagnostics.Contracts;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Enumeration
{
    /// <summary>
    /// CommonOption
    /// </summary>
    [Pure]
    public static class ECommonOption
    {
        /// <summary>
        /// Enumeration
        /// </summary>
        [Flags]
        public enum Enum
        {
            /// <summary>
            /// 1
            /// </summary>
            TryCatch = 1,

            /// <summary>
            /// 2
            /// </summary>
            WithoutChecking = 2,

            /// <summary>
            /// 4
            /// </summary>
            WithoutNull = 4,

            /// <summary>
            /// 8
            /// </summary>
            WithoutEmpty = 8,

            /// <summary>
            /// 16
            /// </summary>
            WithoutWhiteSpace = 16,

            /// <summary>
            /// 32
            /// </summary>
            IgnoreCase = 32,

            /// <summary>
            /// 64
            /// </summary>
            ParallelForeach = 64,
        }

        /// <summary>
        /// Value
        /// </summary>
        [Pure]
        public static class Value
        {
            /// <summary>
            /// 1
            /// </summary>
            public const int TryCatch = (int)Enum.TryCatch;

            /// <summary>
            /// 2
            /// </summary>
            public const int WithoutChecking = (int)Enum.WithoutChecking;

            /// <summary>
            /// 4
            /// </summary>
            public const int WithoutNull = (int)Enum.WithoutNull;

            /// <summary>
            /// 8
            /// </summary>
            public const int WithoutEmpty = (int)Enum.WithoutEmpty;

            /// <summary>
            /// 16
            /// </summary>
            public const int WithoutWhiteSpace = (int)Enum.WithoutWhiteSpace;

            /// <summary>
            /// 32
            /// </summary>
            public const int IgnoreCase = (int)Enum.IgnoreCase;

            /// <summary>
            /// 64
            /// </summary>
            public const int ParallelForeach = (int)Enum.ParallelForeach;
        }

        /// <summary>
        /// Name
        /// </summary>
        [Pure]
        public static class Name
        {
            /// <summary>
            /// TryCatch
            /// </summary>
            public const string TryCatch = "TryCatch";

            /// <summary>
            /// WithoutChecking
            /// </summary>
            public const string WithoutChecking = "WithoutChecking";

            /// <summary>
            /// WithoutNull
            /// </summary>
            public const string WithoutNull = "WithoutNull";

            /// <summary>
            /// WithoutEmpty
            /// </summary>
            public const string WithoutEmpty = "WithoutEmpty";

            /// <summary>
            /// WithoutWhiteSpace
            /// </summary>
            public const string WithoutWhiteSpace = "WithoutWhiteSpace";

            /// <summary>
            /// IgnoreCase
            /// </summary>
            public const string IgnoreCase = "IgnoreCase";

            /// <summary>
            /// ParallelForeach
            /// </summary>
            public const string ParallelForeach = "ParallelForeach";
        }
    }
}
