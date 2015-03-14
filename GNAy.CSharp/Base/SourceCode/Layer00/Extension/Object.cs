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

namespace GNAy.CSharp.Base.Internal.L0_ObjectExtensions
{
    [Pure]
    internal static class CObjectExtensions
    {
        /// <summary>
        /// <para>Equals may be overridden.</para>
        /// <para>Structure may be nullable or be boxed like an object class.</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        internal static bool extIsNotNull<T>(this T ioSource)
        {
            //try
            //{
            //    ioSource.GetType();

            //    return true;
            //}
            //catch (Exception mException)
            //{
            //    return false;
            //}
            //finally
            //{ }

            return (ioSource is T);
        }

        /// <summary>
        /// <para>Equals may be overridden.</para>
        /// <para>Structure may be nullable or be boxed like an object class.</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioSource"></param>
        /// <returns></returns>
        internal static bool extIsNull<T>(this T ioSource)
        {
            //return !extIsNotNull(ioSource);
            return !(ioSource is T);
        }

        internal static bool extClassEquals<T, U>(this T ioSource, U ioTarget)
            where T : class
            where U : class
        {
            return (object.ReferenceEquals(ioSource, ioTarget) ? true : (ioSource == ioTarget));
        }

        internal static bool extStructEquals<T, U>(this T ioSource, U ioTarget)
            where T : struct
            where U : struct
        {
            if (ioSource.extIsNull())
            {
                return (ioTarget.extIsNull());
            }
            else if (ioTarget.extIsNull())
            {
                return false;
            }

            return ioSource.Equals(ioTarget);
        }

        internal static bool extEquals<T, U>(this T ioSource, U ioTarget)
        {
            if (object.ReferenceEquals(ioSource, ioTarget))
            {
                return true;
            }
            else if (ioSource.extIsNull())
            {
                return (ioTarget.extIsNull());
            }
            else if (ioTarget.extIsNull())
            {
                return false;
            }

            return ioSource.Equals(ioTarget);
        }

        internal static bool extClassNotEquals<T, U>(this T ioSource, U ioTarget)
            where T : class
            where U : class
        {
            return !extClassEquals(ioSource, ioTarget);
        }

        internal static bool extStructNotEquals<T, U>(this T ioSource, U ioTarget)
            where T : struct
            where U : struct
        {
            return !extStructEquals(ioSource, ioTarget);
        }

        internal static bool extNotEquals<T, U>(this T ioSource, U ioTarget)
        {
            return !extEquals(ioSource, ioTarget);
        }

        internal static string extToString<T>(this T ioSource, bool iToStringPool)
        {
            return (iToStringPool ? string.Intern(ioSource.ToString()) : ioSource.ToString());
        }

        internal static string extToStringPool<T>(this T ioSource)
        {
            return string.Intern(ioSource.ToString());
        }
    }
}
