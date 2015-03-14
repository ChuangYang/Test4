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
    /// Numeric
    /// </summary>
    [Pure]
    public static class ENumeric
    {
        /// <summary>
        /// Enumeration
        /// </summary>
        public enum Enum
        {
            /// <summary>
            /// <para>1</para>
            /// <para>sbyte</para>
            /// </summary>
            SByte,

            /// <summary>
            /// <para>2</para>
            /// <para>byte</para>
            /// </summary>
            Byte,

            /// <summary>
            /// <para>3</para>
            /// <para>short</para>
            /// </summary>
            Int16,

            /// <summary>
            /// <para>4</para>
            /// <para>ushort</para>
            /// </summary>
            UInt16,

            /// <summary>
            /// <para>5</para>
            /// <para>int</para>
            /// </summary>
            Int32,

            /// <summary>
            /// <para>6</para>
            /// <para>uint</para>
            /// </summary>
            UInt32,

            /// <summary>
            /// <para>7</para>
            /// <para>long</para>
            /// </summary>
            Int64,

            /// <summary>
            /// <para>8</para>
            /// <para>ulong</para>
            /// </summary>
            UInt64,

            /// <summary>
            /// <para>9</para>
            /// <para>float</para>
            /// </summary>
            Single,

            /// <summary>
            /// <para>10</para>
            /// <para>double</para>
            /// </summary>
            Double,

            /// <summary>
            /// <para>11</para>
            /// <para>decimal</para>
            /// </summary>
            Decimal,

            /// <summary>
            /// <para>12</para>
            /// <para>char</para>
            /// </summary>
            Char,

            /// <summary>
            /// <para>13</para>
            /// <para>DateTime</para>
            /// </summary>
            DateTime,
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
            public const int SByte = (int)Enum.SByte;

            /// <summary>
            /// 2
            /// </summary>
            public const int Byte = (int)Enum.Byte;

            /// <summary>
            /// 3
            /// </summary>
            public const int Int16 = (int)Enum.Int16;

            /// <summary>
            /// 4
            /// </summary>
            public const int UInt16 = (int)Enum.UInt16;

            /// <summary>
            /// 5
            /// </summary>
            public const int Int32 = (int)Enum.Int32;

            /// <summary>
            /// 6
            /// </summary>
            public const int UInt32 = (int)Enum.UInt32;

            /// <summary>
            /// 7
            /// </summary>
            public const int Int64 = (int)Enum.Int64;

            /// <summary>
            /// 8
            /// </summary>
            public const int UInt64 = (int)Enum.UInt64;

            /// <summary>
            /// 9
            /// </summary>
            public const int Single = (int)Enum.Single;

            /// <summary>
            /// 10
            /// </summary>
            public const int Double = (int)Enum.Double;

            /// <summary>
            /// 11
            /// </summary>
            public const int Decimal = (int)Enum.Decimal;

            /// <summary>
            /// 12
            /// </summary>
            public const int Char = (int)Enum.Char;

            /// <summary>
            /// 13
            /// </summary>
            public const int DateTime = (int)Enum.DateTime;
        }

        /// <summary>
        /// Name
        /// </summary>
        [Pure]
        public static class Name
        {
            /// <summary>
            /// SByte
            /// </summary>
            public const string SByte = "SByte";

            /// <summary>
            /// Byte
            /// </summary>
            public const string Byte = "Byte";

            /// <summary>
            /// Int16
            /// </summary>
            public const string Int16 = "Int16";

            /// <summary>
            /// UInt16
            /// </summary>
            public const string UInt16 = "UInt16";

            /// <summary>
            /// Int32
            /// </summary>
            public const string Int32 = "Int32";

            /// <summary>
            /// UInt32
            /// </summary>
            public const string UInt32 = "UInt32";

            /// <summary>
            /// Int64
            /// </summary>
            public const string Int64 = "Int64";

            /// <summary>
            /// UInt64
            /// </summary>
            public const string UInt64 = "UInt64";

            /// <summary>
            /// Single
            /// </summary>
            public const string Single = "Single";

            /// <summary>
            /// Double
            /// </summary>
            public const string Double = "Double";

            /// <summary>
            /// Decimal
            /// </summary>
            public const string Decimal = "Decimal";

            /// <summary>
            /// Char
            /// </summary>
            public const string Char = "Char";

            /// <summary>
            /// DateTime
            /// </summary>
            public const string DateTime = "DateTime";
        }
    }
}
