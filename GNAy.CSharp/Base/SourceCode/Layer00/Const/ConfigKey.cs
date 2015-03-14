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

namespace GNAy.CSharp.Base.Const
{
    /// <summary>
    /// ConfigKey
    /// </summary>
    [Pure]
    public static class CConfigKey
    {
        /// <summary>
        /// TraceAutoFlush
        /// </summary>
        public const string TraceAutoFlush = "TraceAutoFlush";

        /// <summary>
        /// TraceFileName
        /// </summary>
        public const string TraceFileName = "TraceFileName";

        /// <summary>
        /// True
        /// </summary>
        public const string True = "True";

        /// <summary>
        /// False
        /// </summary>
        public const string False = "False";

        /// <summary>
        /// Min
        /// </summary>
        public const string Min = "Min";

        /// <summary>
        /// Max
        /// </summary>
        public const string Max = "Max";
    }
}
