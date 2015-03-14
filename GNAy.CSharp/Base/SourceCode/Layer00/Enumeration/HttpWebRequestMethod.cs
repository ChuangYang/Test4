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

namespace GNAy.CSharp.Base.Net
{
    /// <summary>
    /// HttpWebRequestMethod
    /// </summary>
    [Pure]
    public static class EHttpWebRequestMethod
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
            GET = 1,

            /// <summary>
            /// 2
            /// </summary>
            HEAD = 2,

            /// <summary>
            /// 4
            /// </summary>
            POST = 4,

            /// <summary>
            /// 8
            /// </summary>
            PUT = 8,

            /// <summary>
            /// 16
            /// </summary>
            DELETE = 16,

            /// <summary>
            /// 32
            /// </summary>
            OPTIONS = 32,

            /// <summary>
            /// 64
            /// </summary>
            TRACE = 64,
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
            public const int GET = (int)Enum.GET;

            /// <summary>
            /// 2
            /// </summary>
            public const int HEAD = (int)Enum.HEAD;

            /// <summary>
            /// 4
            /// </summary>
            public const int POST = (int)Enum.POST;

            /// <summary>
            /// 8
            /// </summary>
            public const int PUT = (int)Enum.PUT;

            /// <summary>
            /// 16
            /// </summary>
            public const int DELETE = (int)Enum.DELETE;

            /// <summary>
            /// 32
            /// </summary>
            public const int OPTIONS = (int)Enum.OPTIONS;

            /// <summary>
            /// 64
            /// </summary>
            public const int TRACE = (int)Enum.TRACE;
        }

        /// <summary>
        /// Name
        /// </summary>
        [Pure]
        public static class Name
        {
            /// <summary>
            /// GET
            /// </summary>
            public const string GET = "GET";

            /// <summary>
            /// HEAD
            /// </summary>
            public const string HEAD = "HEAD";

            /// <summary>
            /// POST
            /// </summary>
            public const string POST = "POST";

            /// <summary>
            /// PUT
            /// </summary>
            public const string PUT = "PUT";

            /// <summary>
            /// DELETE
            /// </summary>
            public const string DELETE = "DELETE";

            /// <summary>
            /// OPTIONS
            /// </summary>
            public const string OPTIONS = "OPTIONS";

            /// <summary>
            /// TRACE
            /// </summary>
            public const string TRACE = "TRACE";
        }
    }
}
