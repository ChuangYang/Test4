using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
using GNAy.CSharp.Base.Const;
using GNAy.CSharp.Base.Internal.L0_ArrayExtensions;
using GNAy.CSharp.Base.Internal.L0_ObjectExtensions;
using GNAy.CSharp.Base.Internal.L0_TypeHelper;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L1_ObjectExtensions
{
    [Pure]
    internal static class CObjectExtensions
    {
        internal static void extGetHashCodeWithoutChecking<T>(this T ioSource, ref int ioTargetHashCode)
        {
            ioTargetHashCode = (ioTargetHashCode ^ ioSource.GetHashCode());
        }

        internal static void extGetHashCode<T>(this T ioSource, ref int ioTargetHashCode)
        {
            ioTargetHashCode = ((ioTargetHashCode > CConst.Zero) ? (ioTargetHashCode ^ ioSource.GetHashCode()) : ioSource.GetHashCode());
        }

        internal static int extGetHashCodeWithoutChecking<T>(this T ioSource, int iTargetHashCode)
        {
            return (iTargetHashCode ^ ioSource.GetHashCode());
        }

        internal static int extGetHashCode<T>(this T ioSource, int iTargetHashCode = CConst.NotFound)
        {
            return ((iTargetHashCode > CConst.Zero) ? (iTargetHashCode ^ ioSource.GetHashCode()) : ioSource.GetHashCode());
        }

        internal static bool extIsDefault<T>(this T ioSource, Action<Exception> iExceptionHandler = null)
        {
            if (ioSource.extIsNull())
            {
                return true;
            }
            else if (ioSource.GetType().IsClass)
            {
                return false;
            }

            //IsValueType.
            return ioSource.Equals(CTypeHelper.GetDefault<T>());
        }

        [ContractVerification(false)]
        internal static MemoryStream extToMemoryStream<T>(this T ioSource)
        {
            if (!ioSource.GetType().IsSerializable)
            {
                return null;
            }

            MemoryStream mMemoryStream = new MemoryStream();

            (new BinaryFormatter()).Serialize(mMemoryStream, ioSource);

            mMemoryStream.Position = CConst.StartIndex;

            return mMemoryStream;
        }

        internal static byte[] extToBytes<T>(this T ioSource)
        {
            using (MemoryStream mMemoryStream = extToMemoryStream(ioSource))
            {
                return (mMemoryStream.extIsNull() ? null : mMemoryStream.ToArray());
            }
        }

        internal static string extToHexadecimalString<T>(this T ioSource)
        {
            byte[] mBytes = extToBytes(ioSource);

            return (mBytes.extIsNull() ? CConst.StringEmpty : mBytes.extToString());
        }

        internal static T extDeepCopy<T>(this T ioSource)
        {
            if (ioSource.extIsNull())
            {
                return CTypeHelper.GetDefault<T>();
            }
            else if (ioSource is string) //Call by Copy.
            {
                return ioSource;
            }

            Type mType = ioSource.GetType();

            if (mType.IsValueType) //The member(s) of the structure may not be serializable.
            {
                return ioSource;
            }
            else if (mType.IsPrimitive) //The primitive types are Boolean, Byte, SByte, Int16, UInt16, Int32, UInt32, Int64, UInt64, IntPtr, UIntPtr, Char, Double, and Single
            {
                return ioSource;
            }

            using (MemoryStream mMemoryStream = extToMemoryStream(ioSource))
            {
                return (T)(new BinaryFormatter()).Deserialize(mMemoryStream);
            }
        }
    }
}
