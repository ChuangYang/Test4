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
    /// ExceptionFormat
    /// </summary>
    [Pure]
    public static class EExceptionFormat
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
            Time = 1,

            /// <summary>
            /// 2
            /// </summary>
            Type = 2,

            /// <summary>
            /// 4
            /// </summary>
            Message = 4,

            /// <summary>
            /// 8
            /// </summary>
            HResult = 8,

            /// <summary>
            /// 16
            /// </summary>
            ResponseString = 16,

            /// <summary>
            /// 32
            /// </summary>
            ResponseUri = 32,

            /// <summary>
            /// 64
            /// </summary>
            HelpLink = 64,

            /// <summary>
            /// 128
            /// </summary>
            Source = 128,

            /// <summary>
            /// 256
            /// </summary>
            StackTrace = 256,

            /// <summary>
            /// 512
            /// </summary>
            String = 512,
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
            public const int Time = (int)Enum.Time;

            /// <summary>
            /// 2
            /// </summary>
            public const int Type = (int)Enum.Type;

            /// <summary>
            /// 4
            /// </summary>
            public const int Message = (int)Enum.Message;

            /// <summary>
            /// 8
            /// </summary>
            public const int HResult = (int)Enum.HResult;

            /// <summary>
            /// 16
            /// </summary>
            public const int ResponseString = (int)Enum.ResponseString;

            /// <summary>
            /// 32
            /// </summary>
            public const int ResponseUri = (int)Enum.ResponseUri;

            /// <summary>
            /// 64
            /// </summary>
            public const int HelpLink = (int)Enum.HelpLink;

            /// <summary>
            /// 128
            /// </summary>
            public const int Source = (int)Enum.Source;

            /// <summary>
            /// 256
            /// </summary>
            public const int StackTrace = (int)Enum.StackTrace;

            /// <summary>
            /// 512
            /// </summary>
            public const int String = (int)Enum.String;
        }

        /// <summary>
        /// Name
        /// </summary>
        [Pure]
        public static class Name
        {
            /// <summary>
            /// Time
            /// </summary>
            public const string Time = "Time";

            /// <summary>
            /// Type
            /// </summary>
            public const string Type = "Type";

            /// <summary>
            /// Message
            /// </summary>
            public const string Message = "Message";

            /// <summary>
            /// HResult
            /// </summary>
            public const string HResult = "HResult";

            /// <summary>
            /// ResponseString
            /// </summary>
            public const string ResponseString = "ResponseString";

            /// <summary>
            /// ResponseUri
            /// </summary>
            public const string ResponseUri = "ResponseUri";

            /// <summary>
            /// HelpLink
            /// </summary>
            public const string HelpLink = "HelpLink";

            /// <summary>
            /// Source
            /// </summary>
            public const string Source = "Source";

            /// <summary>
            /// StackTrace
            /// </summary>
            public const string StackTrace = "StackTrace";

            /// <summary>
            /// String
            /// </summary>
            public const string String = "String";
        }
    }
}
