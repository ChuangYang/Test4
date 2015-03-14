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
    /// DataOperation
    /// </summary>
    [Pure]
    public static class EDataOperation
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
            Create = 1,

            /// <summary>
            /// 2
            /// </summary>
            Read = 2,

            /// <summary>
            /// 4
            /// </summary>
            GetAll = 4,

            /// <summary>
            /// 8
            /// </summary>
            Insert = 8,

            /// <summary>
            /// 16
            /// </summary>
            Add = 16,

            /// <summary>
            /// 32
            /// </summary>
            Update = 32,

            /// <summary>
            /// 64
            /// </summary>
            Delete = 64,

            /// <summary>
            /// 128
            /// </summary>
            Clear = 128,

            /// <summary>
            /// 256
            /// </summary>
            Destroy = 256,
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
            public const int Create = (int)Enum.Create;

            /// <summary>
            /// 2
            /// </summary>
            public const int Read = (int)Enum.Read;

            /// <summary>
            /// 4
            /// </summary>
            public const int GetAll = (int)Enum.GetAll;

            /// <summary>
            /// 8
            /// </summary>
            public const int Insert = (int)Enum.Insert;

            /// <summary>
            /// 16
            /// </summary>
            public const int Add = (int)Enum.Add;

            /// <summary>
            /// 32
            /// </summary>
            public const int Update = (int)Enum.Update;

            /// <summary>
            /// 64
            /// </summary>
            public const int Delete = (int)Enum.Delete;

            /// <summary>
            /// 128
            /// </summary>
            public const int Clear = (int)Enum.Clear;

            /// <summary>
            /// 256
            /// </summary>
            public const int Destroy = (int)Enum.Destroy;
        }

        /// <summary>
        /// Name
        /// </summary>
        [Pure]
        public static class Name
        {
            /// <summary>
            /// Create
            /// </summary>
            public const string Create = "Create";

            /// <summary>
            /// Read
            /// </summary>
            public const string Read = "Read";

            /// <summary>
            /// GetAll
            /// </summary>
            public const string GetAll = "GetAll";

            /// <summary>
            /// Insert
            /// </summary>
            public const string Insert = "Insert";

            /// <summary>
            /// Add
            /// </summary>
            public const string Add = "Add";

            /// <summary>
            /// Update
            /// </summary>
            public const string Update = "Update";

            /// <summary>
            /// Delete
            /// </summary>
            public const string Delete = "Delete";

            /// <summary>
            /// Clear
            /// </summary>
            public const string Clear = "Clear";

            /// <summary>
            /// Destroy
            /// </summary>
            public const string Destroy = "Destroy";
        }
    }
}
