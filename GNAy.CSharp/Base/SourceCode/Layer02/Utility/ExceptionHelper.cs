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
using GNAy.CSharp.Base.Internal.L0_TypeHelper;
using GNAy.CSharp.Base.Internal.L1_ContractHelper;
using GNAy.CSharp.Base.Internal.L1_DateTimeHelper;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L2_ExceptionHelper
{
    [Pure]
    internal static class CExceptionHelper
    {
        internal static Tuple<Exception, DateTime, string> extToRecord(this Exception ioSource, DateTime iEventTime, string iStackTrace, bool iContractThis = true)
        {
            iContractThis.extRequireFalse();
            (iEventTime.Kind != DateTimeKind.Unspecified).extRequireOrThrow<ArgumentException>(CErrorMessage.DateTimeIsUnspecified);

            return new Tuple<Exception, DateTime, string>(ioSource, iEventTime, (string.IsNullOrWhiteSpace(iStackTrace) ? ioSource.StackTrace : iStackTrace));
        }

        internal static Tuple<Exception, DateTime, string> extToRecord(this Exception ioSource, string iStackTrace, bool iContractThis = true)
        {
            return extToRecord(ioSource, CDateTimeHelper.GetNow(), iStackTrace, iContractThis);
        }

        internal static Exception extGetException(this Tuple<Exception, DateTime, string> ioSource)
        {
            return ioSource.Item1;
        }

        internal static DateTime extGetEventTime(this Tuple<Exception, DateTime, string> ioSource)
        {
            (ioSource.Item2.Kind != DateTimeKind.Unspecified).extRequireOrThrow<ArgumentException>(CErrorMessage.DateTimeIsUnspecified);

            return ioSource.Item2;
        }

        internal static string extGetStackTrace(this Tuple<Exception, DateTime, string> ioSource)
        {
            return ioSource.Item3;
        }

        internal static void Ignore(Exception ioSource)
        {
        }

        internal static void Ignore(Tuple<Exception, DateTime, string> ioSource)
        {
        }

        internal static T extFactory<T>(this string iMessage, Exception ioInnerException = null, bool iContractThis = true) where T : Exception, new()
        {
            iContractThis.extRequireFalse();

            if (string.IsNullOrWhiteSpace(iMessage) && ioInnerException.extIsNull())
            {
                return new T();
            }
            else if (string.IsNullOrWhiteSpace(iMessage))
            {
                return typeof(T).extCreateInstance<T>(CConst.StringEmpty, ioInnerException);
            }
            else if (ioInnerException.extIsNull())
            {
                return typeof(T).extCreateInstance<T>(iMessage);
            }

            return typeof(T).extCreateInstance<T>(iMessage, ioInnerException);
        }

        internal static void extThrow(this Exception ioSource, bool iContractThis = true)
        {
            iContractThis.extRequireFalse();

            throw ioSource;
        }

        internal static void extThrow(this Tuple<Exception, DateTime, string> ioSource, bool iContractThis = true)
        {
            extThrow(extGetException(ioSource), iContractThis);
        }
    }
}
