using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
using GNAy.CSharp.Base.Const;
using GNAy.CSharp.Base.Internal.L0_JsonHelper;
using GNAy.CSharp.Base.Internal.L0_ReservedWordCollection;
using GNAy.CSharp.Base.Internal.L0_XmlHelper;
using GNAy.CSharp.Base.Internal.L1_CharExtensions;
using GNAy.CSharp.Base.Internal.L1_TupleExtensions;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L2_StringExtensions
{
    [Pure]
    internal static class CStringExtensions
    {
        internal static Tuple<Version, string> extTryToGetVersion(this string iFilePath, bool iThrowException = false)
        {
            string mVersionString = CConst.StringEmpty;

            try
            {
                mVersionString = FileVersionInfo.GetVersionInfo(iFilePath).FileVersion;
            }
            catch //(Exception mException)
            {
                if (iThrowException)
                {
                    throw;
                }
            }
            finally
            { }

            if (string.IsNullOrWhiteSpace(mVersionString))
            {
                return null;
            }

            Version mVersion = null;

            try
            {
                mVersion = new Version(mVersionString);
            }
            catch //(Exception mException)
            {
                if (iThrowException)
                {
                    throw;
                }
            }
            finally
            { }

            return new Tuple<Version, string>(mVersion, mVersionString);
        }

        internal static string extTryToGetVersionString(this string iFilePath, bool iThrowException = false)
        {
            return extTryToGetVersion(iFilePath, iThrowException).extGetVersionString();
        }

        internal static byte[] extHexadecimalStringToBytes(this string iSource)
        {
            List<byte> mBytes = new List<byte>();

            for (int i = CConst.StartIndex; i < iSource.Length; i++)
            {
                if ((i + 1) >= iSource.Length)
                {
                    break;
                }

                int mIndex1 = iSource[i].extHexadecimalCharToInt();
                int mIndex2 = iSource[i + 1].extHexadecimalCharToInt();

                if ((mIndex1 < CConst.Zero) || (mIndex2 < CConst.Zero))
                {
                    continue;
                }

                mBytes.Add((byte)((mIndex1 * 16) + mIndex2));

                i++;
            }

            return mBytes.ToArray();
        }

        internal static object extHexadecimalStringToObject(this string iSource)
        {
            using (MemoryStream mMemoryStream = new MemoryStream(extHexadecimalStringToBytes(iSource)))
            {
                return new BinaryFormatter().Deserialize(mMemoryStream);
            }
        }

        internal static T extHexadecimalStringTo<T>(this string iSource)
        {
            return (T)extHexadecimalStringToObject(iSource);
        }

        internal static object extConvertTo(this string iSource, Type ioConversionType)
        {
            if (iSource == null)
            {
                if (ioConversionType.IsValueType)
                {
                    throw new InvalidCastException(ioConversionType.FullName);
                }

                return null;
            }
            else if (ioConversionType.Equals(typeof(string)))
            {
                return iSource;
            }
            else if (ioConversionType.IsEnum)
            {
                return Enum.Parse(ioConversionType, iSource, true);
            }
            else if (typeof(IConvertible).IsAssignableFrom(ioConversionType))
            {
                if (iSource.Equals(CReservedWordCollection.GetMin(), StringComparison.OrdinalIgnoreCase))
                {
                    if (ioConversionType.Equals(typeof(SByte)))
                    {
                        return SByte.MinValue;
                    }
                    else if (ioConversionType.Equals(typeof(Byte)))
                    {
                        return Byte.MinValue;
                    }
                    else if (ioConversionType.Equals(typeof(Int16)))
                    {
                        return Int16.MinValue;
                    }
                    else if (ioConversionType.Equals(typeof(UInt16)))
                    {
                        return UInt16.MinValue;
                    }
                    else if (ioConversionType.Equals(typeof(Int32)))
                    {
                        return Int32.MinValue;
                    }
                    else if (ioConversionType.Equals(typeof(UInt32)))
                    {
                        return UInt32.MinValue;
                    }
                    else if (ioConversionType.Equals(typeof(Int64)))
                    {
                        return Int64.MinValue;
                    }
                    else if (ioConversionType.Equals(typeof(UInt64)))
                    {
                        return UInt64.MinValue;
                    }
                    else if (ioConversionType.Equals(typeof(Single)))
                    {
                        return Single.MinValue;
                    }
                    else if (ioConversionType.Equals(typeof(Double)))
                    {
                        return Double.MinValue;
                    }
                    else if (ioConversionType.Equals(typeof(Decimal)))
                    {
                        return Decimal.MinValue;
                    }
                    else if (ioConversionType.Equals(typeof(Char)))
                    {
                        return Char.MinValue;
                    }
                    else if (ioConversionType.Equals(typeof(DateTime)))
                    {
                        return DateTime.MinValue;
                    }
                }
                else if (iSource.Equals(CReservedWordCollection.GetMax(), StringComparison.OrdinalIgnoreCase))
                {
                    if (ioConversionType.Equals(typeof(SByte)))
                    {
                        return SByte.MaxValue;
                    }
                    else if (ioConversionType.Equals(typeof(Byte)))
                    {
                        return Byte.MaxValue;
                    }
                    else if (ioConversionType.Equals(typeof(Int16)))
                    {
                        return Int16.MaxValue;
                    }
                    else if (ioConversionType.Equals(typeof(UInt16)))
                    {
                        return UInt16.MaxValue;
                    }
                    else if (ioConversionType.Equals(typeof(Int32)))
                    {
                        return Int32.MaxValue;
                    }
                    else if (ioConversionType.Equals(typeof(UInt32)))
                    {
                        return UInt32.MaxValue;
                    }
                    else if (ioConversionType.Equals(typeof(Int64)))
                    {
                        return Int64.MaxValue;
                    }
                    else if (ioConversionType.Equals(typeof(UInt64)))
                    {
                        return UInt64.MaxValue;
                    }
                    else if (ioConversionType.Equals(typeof(Single)))
                    {
                        return Single.MaxValue;
                    }
                    else if (ioConversionType.Equals(typeof(Double)))
                    {
                        return Double.MaxValue;
                    }
                    else if (ioConversionType.Equals(typeof(Decimal)))
                    {
                        return Decimal.MaxValue;
                    }
                    else if (ioConversionType.Equals(typeof(Char)))
                    {
                        return Char.MaxValue;
                    }
                    else if (ioConversionType.Equals(typeof(DateTime)))
                    {
                        return DateTime.MaxValue;
                    }
                }

                return Convert.ChangeType(iSource, ioConversionType);
            }

            //TODO: TypeConverter, extDeserializeJsonURL

            try
            {
                return extHexadecimalStringToObject(iSource);
            }
            catch //(Exception mException)
            { }
            finally
            { }

            try
            {
                return iSource.extDeserializeJsonString(ioConversionType);
            }
            catch //(Exception mException)
            { }
            finally
            { }

            try
            {
                return iSource.extDeserializeXmlString(ioConversionType);
            }
            catch //(Exception mException)
            { }
            finally
            { }

            try
            {
                return iSource.extDeserializeXmlURL(ioConversionType);
            }
            catch //(Exception mException)
            { }
            finally
            { }

            throw new NotSupportedException(string.Format("[{0}][{1}]", iSource, ioConversionType));
        }

        internal static T extConvertTo<T>(this string iSource, Type ioConversionType)
        {
            return (T)extConvertTo(iSource, ioConversionType);
        }

        internal static T extConvertTo<T>(this string iSource)
        {
            return (T)extConvertTo(iSource, typeof(T));
        }
    }
}
