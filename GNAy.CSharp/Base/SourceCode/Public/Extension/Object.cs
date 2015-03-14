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
using GNAy.CSharp.Base.Const;
#endregion

#region Set the aliases.
using CL0ObjectExtensions = GNAy.CSharp.Base.Internal.L0_ObjectExtensions.CObjectExtensions;
using CL1ObjectExtensions = GNAy.CSharp.Base.Internal.L1_ObjectExtensions.CObjectExtensions;
#endregion

namespace GNAy.CSharp.Base.Spread.ObjectExtensions
{
    /// <summary>
    /// ObjectExtensions
    /// </summary>
    [Pure]
    public static class CObjectExtensions
    {
        /// <summary>
        /// <para>Equals may be overridden.</para>
        /// <para>Structure may be nullable or be boxed like an object class.</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static bool extIsNotNull<T>(this T ioSource)
        {
            return CL0ObjectExtensions.extIsNotNull(ioSource);
        }

        /// <summary>
        /// <para>Equals may be overridden.</para>
        /// <para>Structure may be nullable or be boxed like an object class.</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static bool extIsNull<T>(this T ioSource)
        {
            return CL0ObjectExtensions.extIsNull(ioSource);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="ioSource"></param>
        /// <param name="ioTarget"></param>
        /// <returns></returns>
        public static bool extEquals<T, U>(this T ioSource, U ioTarget)
        {
            return CL0ObjectExtensions.extEquals(ioSource, ioTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="ioSource"></param>
        /// <param name="ioTarget"></param>
        /// <returns></returns>
        public static bool extNotEquals<T, U>(this T ioSource, U ioTarget)
        {
            return CL0ObjectExtensions.extNotEquals(ioSource, ioTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <param name="iToStringPool"></param>
        /// <returns></returns>
        public static string extToString<T>(this T ioSource, bool iToStringPool)
        {
            return CL0ObjectExtensions.extToString(ioSource, iToStringPool);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        public static string extToStringPool<T>(this T ioSource)
        {
            return CL0ObjectExtensions.extToStringPool(ioSource);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <param name="ioTargetHashCode"></param>
        public static void extGetHashCode<T>(this T ioSource, ref int ioTargetHashCode)
        {
            CL1ObjectExtensions.extGetHashCode(ioSource, ref ioTargetHashCode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <param name="iTargetHashCode"></param>
        /// <returns></returns>
        public static int extGetHashCode<T>(this T ioSource, int iTargetHashCode = CConst.NotFound)
        {
            return CL1ObjectExtensions.extGetHashCode(ioSource, iTargetHashCode);
        }
    }
}
