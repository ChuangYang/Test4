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
    /// ErrorMessage
    /// </summary>
    [Pure]
    public static class CErrorMessage
    {
        /// <summary>
        /// Unknown case.
        /// </summary>
        public const string UnknownCase = "Unknown case.";

        /// <summary>
        /// Condition is true.
        /// </summary>
        public const string ConditionIsTrue = "Condition is true.";

        /// <summary>
        /// Condition is false.
        /// </summary>
        public const string ConditionIsFalse = "Condition is false.";

        /// <summary>
        /// Object is null.
        /// </summary>
        public const string ObjectIsNull = "Object is null.";

        /// <summary>
        /// Object is not null.
        /// </summary>
        public const string ObjectIsNotNull = "Object is not null.";

        /// <summary>
        /// Object is T.
        /// </summary>
        public const string ObjectIsT = "Object is T.";

        /// <summary>
        /// Object is not T.
        /// </summary>
        public const string ObjectIsNotT = "Object is not T.";

        /// <summary>
        /// Object equals T.
        /// </summary>
        public const string ObjectEquals = "Object equals T.";

        /// <summary>
        /// Object not equals T.
        /// </summary>
        public const string ObjectNotEquals = "Object not equals T.";

        /// <summary>
        /// String is null or empty.
        /// </summary>
        public const string StringIsNullOrEmpty = "String is null or empty.";

        /// <summary>
        /// String is not empty.
        /// </summary>
        public const string StringIsNotEmpty = "String is not empty.";

        /// <summary>
        /// String is null or whitespace.
        /// </summary>
        public const string StringIsNullOrWhiteSpace = "String is null or whitespace.";

        /// <summary>
        /// String is not whitespace.
        /// </summary>
        public const string StringIsNotWhiteSpace = "String is not whitespace.";

        /// <summary>
        /// Collection is null or empty.
        /// </summary>
        public const string CollectionIsNullOrEmpty = "Collection is null or empty.";

        /// <summary>
        /// Collection is not empty.
        /// </summary>
        public const string CollectionIsNotEmpty = "Collection is not empty.";

        /// <summary>
        /// DateTimeKind is unspecified.
        /// </summary>
        public const string DateTimeIsUnspecified = "DateTimeKind is unspecified.";

        /// <summary>
        /// DateTimeKind is not unspecified.
        /// </summary>
        public const string DateTimeIsNotUnspecified = "DateTimeKind is not unspecified.";

        /// <summary>
        /// Task is completed.
        /// </summary>
        public const string TaskIsCompleted = "Task is completed.";

        /// <summary>
        /// Task is not completed.
        /// </summary>
        public const string TaskIsNotCompleted = "Task is not completed.";
    }
}
