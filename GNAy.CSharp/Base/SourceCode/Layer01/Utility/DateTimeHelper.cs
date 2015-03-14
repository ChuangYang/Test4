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
using GNAy.CSharp.Base.Internal.L0_ObjectExtensions;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L1_DateTimeHelper
{
    [Pure]
    internal static class CDateTimeHelper
    {
        #region Fields and properties.
        private static bool fIsSet;

        private static DateTimeKind fKind;
        private static string fSQLFormat;

        private static DateTime fMin;
        private static DateTime fMax;
        #endregion

        #region Singleton, factory or constructor.
        static CDateTimeHelper()
        {
            fIsSet = false;

            fKind = DateTimeKind.Local;
            fSQLFormat = "yyyy-MM-dd HH:mm:ss.fffffff";

            fMin = new DateTime(DateTime.MinValue.Ticks, GetKind());
            fMax = new DateTime(DateTime.MaxValue.Ticks, GetKind());
        }
        #endregion

        #region Methods.
        internal static bool IsSet()
        {
            return fIsSet;
        }

        /// <summary>
        /// Only for internal.
        /// </summary>
        /// <param name="iKind"></param>
        /// <param name="iSQLFormat"></param>
        internal static void Set(DateTimeKind iKind, string iSQLFormat)
        {
            if (IsSet())
            {
                throw new MethodAccessException(CErrorMessage.ConditionIsTrue);
            }
            else if (iKind == DateTimeKind.Unspecified)
            {
                throw new ArgumentException(CErrorMessage.DateTimeIsUnspecified);
            }
            else if (string.IsNullOrWhiteSpace(iSQLFormat))
            {
                throw new ArgumentException(CErrorMessage.StringIsNullOrWhiteSpace);
            }

            fIsSet = true;

            fKind = iKind;
            fSQLFormat = iSQLFormat;

            fMin = new DateTime(DateTime.MinValue.Ticks, GetKind());
            fMax = new DateTime(DateTime.MaxValue.Ticks, GetKind());
        }

        internal static DateTimeKind GetKind()
        {
            return fKind;
        }

        internal static string GetSQLFormat()
        {
            return fSQLFormat;
        }

        internal static DateTime GetMin()
        {
            return fMin;
        }

        internal static DateTime GetDefault()
        {
            return fMin;
        }

        internal static DateTime GetMax()
        {
            return fMax;
        }

        internal static DateTime GetNow()
        {
            return ((GetKind() == DateTimeKind.Utc) ? DateTime.UtcNow : DateTime.Now);
        }

        internal static bool extIsLeapYear(this DateTime iSource)
        {
            return DateTime.IsLeapYear(iSource.Year);
        }

        private static DateTime toKind(DateTime iSource, DateTimeKind iKind)
        {
            if (iKind == DateTimeKind.Unspecified)
            {
                throw new ArgumentException(CErrorMessage.DateTimeIsUnspecified);
            }

            return ((iKind == iSource.Kind) ? iSource : (iKind == DateTimeKind.Utc) ? iSource.ToUniversalTime() : iSource.ToLocalTime());
        }

        /// <summary>
        /// Do not use DateTimeKind.Unspecified.
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iKind"></param>
        /// <returns></returns>
        internal static DateTime extToKind(this DateTime iSource, DateTimeKind? iKind = null)
        {
            return toKind(iSource, (iKind ?? GetKind()));
        }

        /// <summary>
        /// Do not use DateTimeKind.Unspecified.
        /// </summary>
        /// <param name="iSource"></param>
        /// <param name="iKind"></param>
        /// <returns></returns>
        internal static string extToSQLDateTime(this DateTime iSource, DateTimeKind? iKind = null)
        {
            return extToKind(iSource, iKind).ToString(GetSQLFormat());
        }
        #endregion
    }
}
