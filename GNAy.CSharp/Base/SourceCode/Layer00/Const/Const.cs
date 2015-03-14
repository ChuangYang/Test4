using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Diagnostics.Contracts;
using System.Threading;
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
    /// Const
    /// </summary>
    [Pure]
    public static class CConst
    {
        /// <summary>
        /// 0
        /// </summary>
        public const int Zero = 0;

        /// <summary>
        /// 0
        /// </summary>
        public const int Empty = Zero;

        /// <summary>
        /// 0
        /// </summary>
        public const int StartIndex = Zero;

        /// <summary>
        /// -1
        /// </summary>
        public const int AllItems = -1;

        /// <summary>
        /// -1
        /// </summary>
        public const int NotFound = (StartIndex - 1);

        /// <summary>
        /// -1
        /// </summary>
        public const int Infinite = Timeout.Infinite;

        /// <summary>
        /// ' '
        /// </summary>
        public const char CharBlank = ' ';

        /// <summary>
        /// ""
        /// </summary>
        public const string StringEmpty = "";

        /// <summary>
        /// " "
        /// </summary>
        public const string StringBlank = " ";

        /// <summary>
        /// "{"
        /// </summary>
        public const string FormatHead = "{";

        /// <summary>
        /// "}"
        /// </summary>
        public const string FormatTail = "}";

        /// <summary>
        /// "{0}"
        /// </summary>
        public const string FormatInitial = "{0}";

        /// <summary>
        /// "\r\n"
        /// </summary>
        public const string NewLine = "\r\n";
    }
}
